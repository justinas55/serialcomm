/*
 * Created by SharpDevelop.
 * User: Justinas
 * Date: 2011.08.02
 * Time: 19:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Microsoft.Win32;
namespace serialcomm
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		AutoCompleteStringCollection	usedCmds = new AutoCompleteStringCollection();
		int	lastCmd = -1;
		SerialPort	ser = new SerialPort();
		Thread		rcvThread = null;
	    private List<byte> lineBuffer = new List<byte>();
		
		byte[]	Hex2Bytes(string hex)
		{
			try {
				string[]	bytesHex = hex.Split(' ', ',', ';');
				List<byte>	r = new List<byte>();
				foreach(string b in bytesHex)
					r.Add(Convert.ToByte(b, 16));
				return r.ToArray();
			} catch { return null; }
		}
		
		byte[]	EncodeInputMessage(string inpStr)
		{
			char	mode = inputModeCmb.Text[0];
			if(mode == 'L' || mode == 'T')
				return System.Text.Encoding.ASCII.GetBytes(inpStr + (mode == 'L' ? GetEOL() : ""));
			else if(mode == 'H')
				return Hex2Bytes(inpStr);
			else
			{
				List<byte>	rez = new List<byte>();
							
				for(int i = 0, ito = inpStr.Length; i < ito; i++)
				{
					if(inpStr[i] == '<')
					{
						int end = inpStr.IndexOf('>', i + 1);
						if(end == -1)
							return null;
						
						string	hexStr = inpStr.Substring(i + 1, end - i - 1);
						if(hexStr.Length == 0)
							return null;
						
						rez.AddRange(Hex2Bytes(hexStr));
						
						i = end;
					}
					else
						rez.Add((byte)inpStr[i]);
				}
				
				return rez.ToArray();
			}
		}
		
		string	DecodeMessage(byte[] msg)
		{
			string	s = "";
			foreach(byte b in msg)
			{
                if(lineBreakChk.Checked && (b == 0x0a || b == 0x0d))
                    s += (char) b;
                else if((b < 32 || b >= 128)
                    && !(b == '\t' && lineBreakChk.Checked))
					s += "<" + Convert.ToString(b, 16).ToUpper().PadLeft(2, '0') + ">";
				else
					s += (char)b;
			}
			
			return s;
		}
		
		void	ReceiveThread()
		{
			try {
				ser.ReadTimeout = 1000;
				while(ser.IsOpen)
				{
					byte[]	buffer = new byte[ser.BytesToRead];
					int bytes = 0;
					try { bytes = ser.Read(buffer, 0, buffer.Length); } catch { }
					
					if(bytes > 0)
						Invoke(new D_OnDataReceive(OnDataReceive), buffer, bytes);
				}
			} catch(ThreadAbortException) {
				
			}
		}
		
		delegate void	D_OnDataReceive(byte[] data, int len);
		
		void	LogColored(string text, Color fg, Color bg)
		{
			int end = logRtxt.Text.Length;
			
			logRtxt.AppendText(text);
			logRtxt.SelectionStart = end;
			logRtxt.SelectionLength = text.Length;
			if(fg != null)
				logRtxt.SelectionColor = fg;
			if(bg != null)
				logRtxt.SelectionBackColor = bg;
		}
		
		void	OnDataReceive(byte[] data, int len)
		{
		    data = data.Take(len).ToArray();
            if(lineBreakChk.Checked)
            {
                lineBuffer.AddRange(data);
                int i;
                while((i = lineBuffer.IndexOf(0x0a)) >= 0)
                {
                    LogMsg(lineBuffer.Take(i).ToArray(), true);
                    //lineBuffer.Clear();
                    //lineBuffer.AddRange(data.Skip(i+1));
                    lineBuffer.RemoveRange(0, i+1);
                }
            } else
            {
                LogMsg(data, true);
            }
		}
		
		void	CloseCom()
		{
			if(rcvThread != null)
			{
				rcvThread.Abort();
				rcvThread = null;
			}

            if (ser != null)
            {
                if (ser.IsOpen)
                    ser.Close();
                ser = null;
            }
		}
		
		void	LogMsg(byte[] data, bool rcv)
		{
            LimitLog();

			LogColored(String.Format("{0:HH:mm:ss:fff}: ", DateTime.Now), Color.Gray, Color.Black);
			LogColored(DecodeMessage(data), Color.White, rcv ? Color.DarkBlue : Color.DarkGreen);
			logRtxt.AppendText("\n");

			logRtxt.ScrollToCaret();
		}
		
		string	GetEOL()
		{
			string	sel = eolCmb.Text;
			if(sel == "LF")
				return "\n";
			else if(sel == "CR")
				return "\r";
			else if(sel == "CR LF")
				return "\r\n";
			else
				return "";
		}
		
		public MainForm()
		{
			InitializeComponent();
			
			try {
				RegistryKey	key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\serialcomm");
				portCmb.Text = (string)key.GetValue("COM_port");
				baudCmb.Text = (string)key.GetValue("Baud_rate");
				inputModeCmb.Text = (string)key.GetValue("Input_mode");
				eolCmb.Text = (string)key.GetValue("EOL");
			    lineBreakChk.Checked = (int) key.GetValue("LineBreak", 0) != 0;
                autoConnectChk.Checked = (int)key.GetValue("AutoConnect", 0) != 0;
			    logLimitCmb.Text = (string) key.GetValue("LogLimit");
				
				string list = (string)key.GetValue("CMDS");
				usedCmds.AddRange(list.Split((char)255));
				key.Close();
			} catch {}
			
			inputTxt.AutoCompleteSource = AutoCompleteSource.CustomSource;
			inputTxt.AutoCompleteCustomSource = usedCmds;

		    logLimitCmb.Items.Add("No log limit");
            foreach(var i in Enumerable.Range(1, 6))
            {
                logLimitCmb.Items.Add((1000*Math.Pow(2, i)) + " lines limit");
            }
		}

        private void LimitLog()
        {
            int limit = logLimitCmb.SelectedIndex;
            if(limit > 0)
            {
                limit *= 1000;
                int excess = logRtxt.Lines.Length - limit;
                if(excess > 0)
                {
                    logRtxt.Lines = logRtxt.Lines.Skip(excess).ToArray();
                }
            }
        }

	    void TextBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(inputTxt.Text.Length == 0)
					return;
				
				byte[]	msg = EncodeInputMessage(inputTxt.Text);
				if(msg == null)
				{
					System.Windows.Forms.MessageBox.Show("Incorrect format");
					return;
				}
				
				try { ser.Write(msg, 0, msg.Length); } 
				catch(Exception) { MessageBox.Show("Error writing to serial port");
					return;
				}
				LogMsg(msg, false);
				//richTextBox1.AppendText(DecodeMessage(msg) + '\n');
				if(usedCmds.Count == 0 || usedCmds[usedCmds.Count-1] != inputTxt.Text)
					usedCmds.Add(inputTxt.Text);
				while(usedCmds.Count >= 1000)
					usedCmds.RemoveAt(0);
				
				lastCmd = -1;
				
				inputTxt.Text = "";
			}
			else if(e.KeyCode == Keys.Up)
			{
				if(lastCmd == -1)
					lastCmd = usedCmds.Count-1;
				else if(lastCmd > 0)
					lastCmd--;
				
				if(lastCmd >= 0 && lastCmd < usedCmds.Count)
				{
					inputTxt.Text = usedCmds[lastCmd];
				}
			}
			else if(e.KeyCode == Keys.Down)
			{
				if(lastCmd == -1)
					return;
				else
					lastCmd++;
				
				if(lastCmd >= usedCmds.Count)
					lastCmd = usedCmds.Count - 1;
				
				if(lastCmd >= 0 && lastCmd < usedCmds.Count)
				{
					inputTxt.Text = usedCmds[lastCmd];
				}
			}
		}
		
		void ComboBox2MouseClick(object sender, MouseEventArgs e)
		{
			portCmb.Items.Clear();
			try {
				portCmb.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
			} catch(Exception) {
				
			}
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(connectBtn.Text[0] == 'C')
			{
				if(portCmb.Text.Length == 0)
					return;
				
				int baud = 0;
				try { baud = Convert.ToInt32(baudCmb.Text); } catch {}
				if(baud == 0)
				{
					MessageBox.Show("Choose baud rate");
					return;
				}

                ser = new SerialPort();
				
				ser.BaudRate = baud;
				ser.DataBits = 8;
				ser.Handshake = Handshake.None;
				ser.Parity = Parity.None;
				ser.StopBits = StopBits.One;
				ser.PortName = portCmb.Text;
				ser.DtrEnable = false;
				ser.RtsEnable = false;
			    ser.DiscardNull = false;
				
				try { ser.Open(); }
				catch(Exception ex) {
					MessageBox.Show("Port open failed: " + ex.Message);
                    CloseCom();
                    return;
				}
				
				connectBtn.Text = "Disconnect";
				inputTxt.Enabled = true;
				
				rcvThread = new Thread((ThreadStart)ReceiveThread);
				rcvThread.Start();
			}
			else
			{
				CloseCom();
				connectBtn.Text = "Connect";
				inputTxt.Enabled = false;
			}
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			CloseCom();
			
			try {
				RegistryKey	key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\serialcomm");
				key.SetValue("COM_port", portCmb.Text);
				key.SetValue("Baud_rate", baudCmb.Text);
				key.SetValue("Input_mode", inputModeCmb.Text);
				key.SetValue("EOL", eolCmb.Text);
				string	list = "";
				for(int i = usedCmds.Count - 1, c = 0; i >= 0 && c < 100; i--, c++)
				{
					if(c != 0)
						list += (char)255;
					list += usedCmds[i];
				}
				key.SetValue("CMDS", list);
                key.SetValue("LineBreak", lineBreakChk.Checked ? 1 : 0);
                key.SetValue("AutoConnect", autoConnectChk.Checked ? 1 : 0);
                key.SetValue("LogLimit", logLimitCmb.Text);
				key.Close();
			} catch {}
		}
		
		void ComboBox4SelectedIndexChanged(object sender, EventArgs e)
		{
			char	mode = inputModeCmb.Text[0];
			eolCmb.Enabled = mode == 'L';
		}

        private void MainFormActivated(object sender, EventArgs e)
        {
            if(ser == null && autoConnectChk.Checked)
                Button1Click(null,null);
        }

        private void MainFormDeactivate(object sender, EventArgs e)
        {
            if (ser != null && autoConnectChk.Checked)
                Button1Click(null, null);
        }

        private void Button2Click(object sender, EventArgs e)
        {
            logRtxt.Text = "";
        }
	}
}

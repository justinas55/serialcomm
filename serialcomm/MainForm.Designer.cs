/*
 * Created by SharpDevelop.
 * User: Justinas
 * Date: 2011.08.02
 * Time: 19:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace serialcomm
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.baudCmb = new System.Windows.Forms.ComboBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portCmb = new System.Windows.Forms.ComboBox();
            this.logRtxt = new System.Windows.Forms.RichTextBox();
            this.inputTxt = new System.Windows.Forms.TextBox();
            this.eolCmb = new System.Windows.Forms.ComboBox();
            this.inputModeCmb = new System.Windows.Forms.ComboBox();
            this.autoConnectChk = new System.Windows.Forms.CheckBox();
            this.clearLogBtn = new System.Windows.Forms.Button();
            this.lineBreakChk = new System.Windows.Forms.CheckBox();
            this.logLimitCmb = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // baudCmb
            // 
            this.baudCmb.BackColor = System.Drawing.Color.Black;
            this.baudCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baudCmb.ForeColor = System.Drawing.Color.White;
            this.baudCmb.FormattingEnabled = true;
            this.baudCmb.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.baudCmb.Location = new System.Drawing.Point(287, 14);
            this.baudCmb.Name = "baudCmb";
            this.baudCmb.Size = new System.Drawing.Size(71, 21);
            this.baudCmb.TabIndex = 0;
            this.baudCmb.Text = "115200";
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.Black;
            this.connectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectBtn.ForeColor = System.Drawing.Color.White;
            this.connectBtn.Location = new System.Drawing.Point(12, 12);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(95, 23);
            this.connectBtn.TabIndex = 1;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.Button1Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(224, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Baud rate:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(113, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // portCmb
            // 
            this.portCmb.BackColor = System.Drawing.Color.Black;
            this.portCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.portCmb.ForeColor = System.Drawing.Color.White;
            this.portCmb.FormattingEnabled = true;
            this.portCmb.Location = new System.Drawing.Point(152, 14);
            this.portCmb.Name = "portCmb";
            this.portCmb.Size = new System.Drawing.Size(66, 21);
            this.portCmb.TabIndex = 4;
            this.portCmb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ComboBox2MouseClick);
            // 
            // logRtxt
            // 
            this.logRtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logRtxt.BackColor = System.Drawing.Color.Black;
            this.logRtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logRtxt.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.logRtxt.ForeColor = System.Drawing.Color.White;
            this.logRtxt.Location = new System.Drawing.Point(12, 41);
            this.logRtxt.Name = "logRtxt";
            this.logRtxt.Size = new System.Drawing.Size(923, 316);
            this.logRtxt.TabIndex = 5;
            this.logRtxt.Text = "";
            // 
            // inputTxt
            // 
            this.inputTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTxt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.inputTxt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.inputTxt.BackColor = System.Drawing.Color.Black;
            this.inputTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputTxt.ForeColor = System.Drawing.Color.White;
            this.inputTxt.Location = new System.Drawing.Point(12, 363);
            this.inputTxt.Name = "inputTxt";
            this.inputTxt.Size = new System.Drawing.Size(762, 20);
            this.inputTxt.TabIndex = 6;
            this.inputTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1KeyDown);
            // 
            // eolCmb
            // 
            this.eolCmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.eolCmb.BackColor = System.Drawing.Color.Black;
            this.eolCmb.Enabled = false;
            this.eolCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eolCmb.ForeColor = System.Drawing.Color.White;
            this.eolCmb.FormattingEnabled = true;
            this.eolCmb.Items.AddRange(new object[] {
            "None",
            "LF",
            "CR",
            "CR LF"});
            this.eolCmb.Location = new System.Drawing.Point(873, 363);
            this.eolCmb.Name = "eolCmb";
            this.eolCmb.Size = new System.Drawing.Size(62, 21);
            this.eolCmb.TabIndex = 8;
            this.eolCmb.Text = "LF";
            this.toolTip1.SetToolTip(this.eolCmb, "End of line symbol for \"Line mode\"");
            // 
            // inputModeCmb
            // 
            this.inputModeCmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.inputModeCmb.BackColor = System.Drawing.Color.Black;
            this.inputModeCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inputModeCmb.ForeColor = System.Drawing.Color.White;
            this.inputModeCmb.FormattingEnabled = true;
            this.inputModeCmb.Items.AddRange(new object[] {
            "Line mode",
            "Text mode",
            "Hex mode",
            "Mixed mode"});
            this.inputModeCmb.Location = new System.Drawing.Point(780, 363);
            this.inputModeCmb.Name = "inputModeCmb";
            this.inputModeCmb.Size = new System.Drawing.Size(87, 21);
            this.inputModeCmb.TabIndex = 9;
            this.inputModeCmb.Text = "Hex mode";
            this.toolTip1.SetToolTip(this.inputModeCmb, "Hex mode - for ex. \"40 41 1A\"\r\nLine mode - for ex. \"Line text\" (automatically sen" +
        "ds end of line byte(s))\r\nMixed mode - for ex. \"Line text<0d 0a>\" (sends text and" +
        " Hex data enclosed in <>)");
            this.inputModeCmb.SelectedIndexChanged += new System.EventHandler(this.ComboBox4SelectedIndexChanged);
            // 
            // autoConnectChk
            // 
            this.autoConnectChk.AutoSize = true;
            this.autoConnectChk.ForeColor = System.Drawing.SystemColors.Control;
            this.autoConnectChk.Location = new System.Drawing.Point(364, 16);
            this.autoConnectChk.Name = "autoConnectChk";
            this.autoConnectChk.Size = new System.Drawing.Size(90, 17);
            this.autoConnectChk.TabIndex = 10;
            this.autoConnectChk.Text = "Auto connect";
            this.toolTip1.SetToolTip(this.autoConnectChk, "Auto connect when serialcomm window is activated and auto disconnect when deactiv" +
        "ated");
            this.autoConnectChk.UseVisualStyleBackColor = true;
            // 
            // clearLogBtn
            // 
            this.clearLogBtn.BackColor = System.Drawing.Color.Black;
            this.clearLogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearLogBtn.ForeColor = System.Drawing.Color.White;
            this.clearLogBtn.Location = new System.Drawing.Point(544, 12);
            this.clearLogBtn.Name = "clearLogBtn";
            this.clearLogBtn.Size = new System.Drawing.Size(95, 23);
            this.clearLogBtn.TabIndex = 11;
            this.clearLogBtn.Text = "Clear log";
            this.clearLogBtn.UseVisualStyleBackColor = false;
            this.clearLogBtn.Click += new System.EventHandler(this.Button2Click);
            // 
            // lineBreakChk
            // 
            this.lineBreakChk.AutoSize = true;
            this.lineBreakChk.ForeColor = System.Drawing.SystemColors.Control;
            this.lineBreakChk.Location = new System.Drawing.Point(458, 16);
            this.lineBreakChk.Name = "lineBreakChk";
            this.lineBreakChk.Size = new System.Drawing.Size(76, 17);
            this.lineBreakChk.TabIndex = 12;
            this.lineBreakChk.Text = "Line break";
            this.toolTip1.SetToolTip(this.lineBreakChk, "Parse line breaks. \r\nIf enabled waits for full line and then prints it.\r\nIf disab" +
        "led data is printed as it\'s received including line break bytes.");
            this.lineBreakChk.UseVisualStyleBackColor = true;
            // 
            // logLimitCmb
            // 
            this.logLimitCmb.BackColor = System.Drawing.Color.Black;
            this.logLimitCmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logLimitCmb.ForeColor = System.Drawing.Color.White;
            this.logLimitCmb.FormattingEnabled = true;
            this.logLimitCmb.Location = new System.Drawing.Point(702, 14);
            this.logLimitCmb.Name = "logLimitCmb";
            this.logLimitCmb.Size = new System.Drawing.Size(121, 21);
            this.logLimitCmb.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(645, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Log limit:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(941, 391);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logLimitCmb);
            this.Controls.Add(this.lineBreakChk);
            this.Controls.Add(this.clearLogBtn);
            this.Controls.Add(this.autoConnectChk);
            this.Controls.Add(this.inputModeCmb);
            this.Controls.Add(this.eolCmb);
            this.Controls.Add(this.inputTxt);
            this.Controls.Add(this.logRtxt);
            this.Controls.Add(this.portCmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.baudCmb);
            this.MinimumSize = new System.Drawing.Size(456, 143);
            this.Name = "MainForm";
            this.Text = "serialcomm";
            this.Activated += new System.EventHandler(this.MainFormActivated);
            this.Deactivate += new System.EventHandler(this.MainFormDeactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ComboBox inputModeCmb;
		private System.Windows.Forms.ComboBox eolCmb;
		private System.Windows.Forms.TextBox inputTxt;
		private System.Windows.Forms.RichTextBox logRtxt;
		private System.Windows.Forms.ComboBox portCmb;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button connectBtn;
		private System.Windows.Forms.ComboBox baudCmb;
        private System.Windows.Forms.CheckBox autoConnectChk;
        private System.Windows.Forms.Button clearLogBtn;
        private System.Windows.Forms.CheckBox lineBreakChk;
        private System.Windows.Forms.ComboBox logLimitCmb;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
	}
}

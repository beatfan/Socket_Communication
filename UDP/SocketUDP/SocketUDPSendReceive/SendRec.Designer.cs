namespace SocketUDPSendReceive
{
    partial class SendRec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbRemotePort = new System.Windows.Forms.TextBox();
            this.tbLocalPort = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartUDP = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.IPBox = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStopUdp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(109, 264);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "定时发送";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbRemotePort
            // 
            this.tbRemotePort.Location = new System.Drawing.Point(274, 66);
            this.tbRemotePort.Name = "tbRemotePort";
            this.tbRemotePort.Size = new System.Drawing.Size(47, 21);
            this.tbRemotePort.TabIndex = 26;
            this.tbRemotePort.Text = "33582";
            // 
            // tbLocalPort
            // 
            this.tbLocalPort.Location = new System.Drawing.Point(91, 66);
            this.tbLocalPort.Name = "tbLocalPort";
            this.tbLocalPort.Size = new System.Drawing.Size(47, 21);
            this.tbLocalPort.TabIndex = 27;
            this.tbLocalPort.Text = "1111";
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(91, 221);
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(297, 21);
            this.tbSend.TabIndex = 28;
            // 
            // tbReceive
            // 
            this.tbReceive.Location = new System.Drawing.Point(91, 103);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReceive.Size = new System.Drawing.Size(297, 112);
            this.tbReceive.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "RemotePort:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "LocalPort:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "Send:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "Receive:";
            // 
            // btnStartUDP
            // 
            this.btnStartUDP.Location = new System.Drawing.Point(262, 21);
            this.btnStartUDP.Name = "btnStartUDP";
            this.btnStartUDP.Size = new System.Drawing.Size(75, 23);
            this.btnStartUDP.TabIndex = 19;
            this.btnStartUDP.Text = "StartUDP";
            this.btnStartUDP.UseVisualStyleBackColor = true;
            this.btnStartUDP.Click += new System.EventHandler(this.btnStartUDP_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(254, 260);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 20;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // IPBox
            // 
            this.IPBox.FormattingEnabled = true;
            this.IPBox.Location = new System.Drawing.Point(62, 24);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(127, 20);
            this.IPBox.TabIndex = 18;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStopUdp
            // 
            this.btnStopUdp.Location = new System.Drawing.Point(348, 22);
            this.btnStopUdp.Name = "btnStopUdp";
            this.btnStopUdp.Size = new System.Drawing.Size(75, 23);
            this.btnStopUdp.TabIndex = 21;
            this.btnStopUdp.Text = "StopUDP";
            this.btnStopUdp.UseVisualStyleBackColor = true;
            this.btnStopUdp.Click += new System.EventHandler(this.btnStopUdp_Click);
            // 
            // SendRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 310);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tbRemotePort);
            this.Controls.Add(this.tbLocalPort);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tbReceive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartUDP);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.btnStopUdp);
            this.Name = "SendRec";
            this.Text = "SendRec";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tbRemotePort;
        private System.Windows.Forms.TextBox tbLocalPort;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartUDP;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ComboBox IPBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStopUdp;
    }
}
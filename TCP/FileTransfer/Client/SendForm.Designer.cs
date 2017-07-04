namespace Client
{
    partial class SendForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pbState = new System.Windows.Forms.ProgressBar();
            this.tbRemoteIP = new System.Windows.Forms.TextBox();
            this.tbRemotePort = new System.Windows.Forms.TextBox();
            this.lbResult = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(28, 89);
            this.tbFilePath.Multiline = true;
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(233, 58);
            this.tbFilePath.TabIndex = 0;
            this.tbFilePath.Text = "双击选择文件";
            this.tbFilePath.TextChanged += new System.EventHandler(this.tbFilePath_TextChanged);
            this.tbFilePath.DoubleClick += new System.EventHandler(this.tbFilePath_DoubleClick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(64, 163);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(73, 21);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pbState
            // 
            this.pbState.Location = new System.Drawing.Point(28, 210);
            this.pbState.Name = "pbState";
            this.pbState.Size = new System.Drawing.Size(233, 23);
            this.pbState.TabIndex = 2;
            // 
            // tbRemoteIP
            // 
            this.tbRemoteIP.Location = new System.Drawing.Point(18, 25);
            this.tbRemoteIP.Name = "tbRemoteIP";
            this.tbRemoteIP.Size = new System.Drawing.Size(107, 21);
            this.tbRemoteIP.TabIndex = 0;
            this.tbRemoteIP.Text = "192.168.10.";
            // 
            // tbRemotePort
            // 
            this.tbRemotePort.Location = new System.Drawing.Point(142, 25);
            this.tbRemotePort.Name = "tbRemotePort";
            this.tbRemotePort.Size = new System.Drawing.Size(40, 21);
            this.tbRemotePort.TabIndex = 0;
            this.tbRemotePort.Text = "5001";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(167, 167);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(41, 12);
            this.lbResult.TabIndex = 3;
            this.lbResult.Text = "label1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(206, 24);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(55, 21);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.pbState);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tbRemotePort);
            this.Controls.Add(this.tbRemoteIP);
            this.Controls.Add(this.tbFilePath);
            this.Name = "SendForm";
            this.Text = "SendFile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ProgressBar pbState;
        private System.Windows.Forms.TextBox tbRemoteIP;
        private System.Windows.Forms.TextBox tbRemotePort;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button btnConnect;
    }
}


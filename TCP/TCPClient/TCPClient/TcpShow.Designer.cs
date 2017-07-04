namespace TCPClientTest
{
    partial class TcpShow
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
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRemotePort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReceive = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbRemoteIP = new System.Windows.Forms.ComboBox();
            this.cbCommanList = new System.Windows.Forms.ComboBox();
            this.cbState = new System.Windows.Forms.ComboBox();
            this.tbValueA = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbValueB = new System.Windows.Forms.TextBox();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(324, 159);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:";
            // 
            // tbRemotePort
            // 
            this.tbRemotePort.Location = new System.Drawing.Point(220, 22);
            this.tbRemotePort.Name = "tbRemotePort";
            this.tbRemotePort.Size = new System.Drawing.Size(38, 21);
            this.tbRemotePort.TabIndex = 1;
            this.tbRemotePort.Text = "1024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // tbReceive
            // 
            this.tbReceive.Location = new System.Drawing.Point(23, 60);
            this.tbReceive.Multiline = true;
            this.tbReceive.Name = "tbReceive";
            this.tbReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReceive.Size = new System.Drawing.Size(247, 67);
            this.tbReceive.TabIndex = 1;
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(297, 120);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(124, 26);
            this.tbSend.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(286, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(62, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbRemoteIP
            // 
            this.cbRemoteIP.FormattingEnabled = true;
            this.cbRemoteIP.Location = new System.Drawing.Point(52, 23);
            this.cbRemoteIP.Name = "cbRemoteIP";
            this.cbRemoteIP.Size = new System.Drawing.Size(107, 20);
            this.cbRemoteIP.TabIndex = 3;
            // 
            // cbCommanList
            // 
            this.cbCommanList.FormattingEnabled = true;
            this.cbCommanList.Location = new System.Drawing.Point(299, 63);
            this.cbCommanList.Name = "cbCommanList";
            this.cbCommanList.Size = new System.Drawing.Size(121, 20);
            this.cbCommanList.TabIndex = 4;
            this.cbCommanList.SelectedIndexChanged += new System.EventHandler(this.cbCommanList_SelectedIndexChanged);
            // 
            // cbState
            // 
            this.cbState.FormattingEnabled = true;
            this.cbState.Items.AddRange(new object[] {
            "Set",
            "Get",
            "SendFile"});
            this.cbState.Location = new System.Drawing.Point(299, 92);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(63, 20);
            this.cbState.TabIndex = 4;
            this.cbState.Text = "Set";
            this.cbState.SelectedIndexChanged += new System.EventHandler(this.cbState_SelectedIndexChanged);
            // 
            // tbValueA
            // 
            this.tbValueA.Location = new System.Drawing.Point(368, 92);
            this.tbValueA.Multiline = true;
            this.tbValueA.Name = "tbValueA";
            this.tbValueA.Size = new System.Drawing.Size(27, 20);
            this.tbValueA.TabIndex = 1;
            this.tbValueA.Text = " = ";
            this.tbValueA.TextChanged += new System.EventHandler(this.tbValueA_TextChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(368, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(73, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbValueB
            // 
            this.tbValueB.Location = new System.Drawing.Point(397, 92);
            this.tbValueB.Multiline = true;
            this.tbValueB.Name = "tbValueB";
            this.tbValueB.Size = new System.Drawing.Size(27, 20);
            this.tbValueB.TabIndex = 1;
            this.tbValueB.TextChanged += new System.EventHandler(this.tbValueB_TextChanged);
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(23, 133);
            this.tbFilePath.Multiline = true;
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(247, 54);
            this.tbFilePath.TabIndex = 1;
            this.tbFilePath.Text = "双击此处选择发送的文件";
            this.tbFilePath.DoubleClick += new System.EventHandler(this.tbFilePath_DoubleClick);
            // 
            // TcpShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 199);
            this.Controls.Add(this.cbState);
            this.Controls.Add(this.cbCommanList);
            this.Controls.Add(this.cbRemoteIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRemotePort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbValueB);
            this.Controls.Add(this.tbValueA);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.tbSend);
            this.Controls.Add(this.tbReceive);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSend);
            this.Name = "TcpShow";
            this.Text = "Tcp Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRemotePort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbReceive;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbRemoteIP;
        private System.Windows.Forms.ComboBox cbCommanList;
        private System.Windows.Forms.ComboBox cbState;
        private System.Windows.Forms.TextBox tbValueA;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbValueB;
        private System.Windows.Forms.TextBox tbFilePath;
    }
}


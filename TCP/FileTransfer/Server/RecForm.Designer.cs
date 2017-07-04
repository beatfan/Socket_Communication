namespace Server
{
    partial class Receive
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
            this.btnBegin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbIPBox = new System.Windows.Forms.ComboBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstbxMsgView = new System.Windows.Forms.ListBox();
            this.listbOnline = new System.Windows.Forms.ListBox();
            this.pbState = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(233, 24);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(53, 23);
            this.btnBegin.TabIndex = 0;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "接收进度：";
            // 
            // cbIPBox
            // 
            this.cbIPBox.FormattingEnabled = true;
            this.cbIPBox.Location = new System.Drawing.Point(16, 25);
            this.cbIPBox.Name = "cbIPBox";
            this.cbIPBox.Size = new System.Drawing.Size(121, 20);
            this.cbIPBox.TabIndex = 2;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(161, 24);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(50, 21);
            this.tbPort.TabIndex = 3;
            this.tbPort.Text = "5001";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(303, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstbxMsgView
            // 
            this.lstbxMsgView.FormattingEnabled = true;
            this.lstbxMsgView.ItemHeight = 12;
            this.lstbxMsgView.Location = new System.Drawing.Point(12, 90);
            this.lstbxMsgView.Name = "lstbxMsgView";
            this.lstbxMsgView.Size = new System.Drawing.Size(242, 88);
            this.lstbxMsgView.TabIndex = 4;
            // 
            // listbOnline
            // 
            this.listbOnline.FormattingEnabled = true;
            this.listbOnline.ItemHeight = 12;
            this.listbOnline.Location = new System.Drawing.Point(275, 90);
            this.listbOnline.Name = "listbOnline";
            this.listbOnline.Size = new System.Drawing.Size(117, 88);
            this.listbOnline.TabIndex = 4;
            // 
            // pbState
            // 
            this.pbState.Location = new System.Drawing.Point(102, 189);
            this.pbState.Name = "pbState";
            this.pbState.Size = new System.Drawing.Size(184, 23);
            this.pbState.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "消息：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "客户机";
            // 
            // Receive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 230);
            this.Controls.Add(this.pbState);
            this.Controls.Add(this.listbOnline);
            this.Controls.Add(this.lstbxMsgView);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.cbIPBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBegin);
            this.Name = "Receive";
            this.Text = "Receicw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbIPBox;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstbxMsgView;
        private System.Windows.Forms.ListBox listbOnline;
        private System.Windows.Forms.ProgressBar pbState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}


namespace TOFSensorSampleGetResult
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.cmbCOMList = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCommand81 = new System.Windows.Forms.Button();
            this.btnCommand80 = new System.Windows.Forms.Button();
            this.btnCommand82 = new System.Windows.Forms.Button();
            this.chkRepeat = new System.Windows.Forms.CheckBox();
            this._folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.chkOutputCSV = new System.Windows.Forms.CheckBox();
            this.txtOutputCSVPath = new System.Windows.Forms.RichTextBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.btnRefresh.Location = new System.Drawing.Point(176, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(158, 31);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.btnDisconnect.Location = new System.Drawing.Point(176, 46);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(158, 31);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnet";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // cmbCOMList
            // 
            this.cmbCOMList.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.cmbCOMList.FormattingEnabled = true;
            this.cmbCOMList.Location = new System.Drawing.Point(12, 12);
            this.cmbCOMList.Name = "cmbCOMList";
            this.cmbCOMList.Size = new System.Drawing.Size(158, 21);
            this.cmbCOMList.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.btnConnect.Location = new System.Drawing.Point(12, 46);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(158, 31);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCommand81
            // 
            this.btnCommand81.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.btnCommand81.Location = new System.Drawing.Point(176, 111);
            this.btnCommand81.Name = "btnCommand81";
            this.btnCommand81.Size = new System.Drawing.Size(158, 31);
            this.btnCommand81.TabIndex = 5;
            this.btnCommand81.Text = "Stop measurement";
            this.btnCommand81.UseVisualStyleBackColor = true;
            this.btnCommand81.Click += new System.EventHandler(this.btnCommand81_Click);
            // 
            // btnCommand80
            // 
            this.btnCommand80.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.btnCommand80.Location = new System.Drawing.Point(12, 111);
            this.btnCommand80.Name = "btnCommand80";
            this.btnCommand80.Size = new System.Drawing.Size(158, 31);
            this.btnCommand80.TabIndex = 4;
            this.btnCommand80.Text = "Start measurement";
            this.btnCommand80.UseVisualStyleBackColor = true;
            this.btnCommand80.Click += new System.EventHandler(this.btnCommand80_Click);
            // 
            // btnCommand82
            // 
            this.btnCommand82.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.btnCommand82.Location = new System.Drawing.Point(176, 174);
            this.btnCommand82.Name = "btnCommand82";
            this.btnCommand82.Size = new System.Drawing.Size(158, 31);
            this.btnCommand82.TabIndex = 7;
            this.btnCommand82.Text = "Get result";
            this.btnCommand82.UseVisualStyleBackColor = true;
            this.btnCommand82.Click += new System.EventHandler(this.btnCommand82_Click);
            // 
            // chkRepeat
            // 
            this.chkRepeat.AutoSize = true;
            this.chkRepeat.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.chkRepeat.Location = new System.Drawing.Point(102, 182);
            this.chkRepeat.Name = "chkRepeat";
            this.chkRepeat.Size = new System.Drawing.Size(68, 17);
            this.chkRepeat.TabIndex = 6;
            this.chkRepeat.Text = "Repeat";
            this.chkRepeat.UseVisualStyleBackColor = true;
            this.chkRepeat.CheckedChanged += new System.EventHandler(this.chkRepeat_CheckedRepeat);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLog.Location = new System.Drawing.Point(340, 12);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(715, 502);
            this.txtLog.TabIndex = 13;
            this.txtLog.Text = "";
            // 
            // chkOutputCSV
            // 
            this.chkOutputCSV.AutoSize = true;
            this.chkOutputCSV.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.chkOutputCSV.Location = new System.Drawing.Point(12, 324);
            this.chkOutputCSV.Name = "chkOutputCSV";
            this.chkOutputCSV.Size = new System.Drawing.Size(96, 17);
            this.chkOutputCSV.TabIndex = 11;
            this.chkOutputCSV.Text = "Output CSV";
            this.chkOutputCSV.UseVisualStyleBackColor = true;
            this.chkOutputCSV.CheckedChanged += new System.EventHandler(this.chkOutputCSV_CheckedChanged);
            // 
            // txtOutputCSVPath
            // 
            this.txtOutputCSVPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOutputCSVPath.Enabled = false;
            this.txtOutputCSVPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.txtOutputCSVPath.Location = new System.Drawing.Point(12, 347);
            this.txtOutputCSVPath.Name = "txtOutputCSVPath";
            this.txtOutputCSVPath.Size = new System.Drawing.Size(322, 167);
            this.txtOutputCSVPath.TabIndex = 12;
            this.txtOutputCSVPath.Text = "";
            // 
            // txtResult
            // 
            this.txtResult.Enabled = false;
            this.txtResult.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.txtResult.Location = new System.Drawing.Point(12, 211);
            this.txtResult.Multiline = false;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(322, 26);
            this.txtResult.TabIndex = 8;
            this.txtResult.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F);
            this.btnClear.Location = new System.Drawing.Point(176, 243);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(158, 31);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Log clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 526);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtOutputCSVPath);
            this.Controls.Add(this.chkOutputCSV);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.chkRepeat);
            this.Controls.Add(this.btnCommand82);
            this.Controls.Add(this.btnCommand81);
            this.Controls.Add(this.btnCommand80);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.cmbCOMList);
            this.Controls.Add(this.btnConnect);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TOF Sensor sample source. Get result. Ver. 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ComboBox cmbCOMList;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCommand81;
        private System.Windows.Forms.Button btnCommand80;
        private System.Windows.Forms.Button btnCommand82;
        private System.Windows.Forms.CheckBox chkRepeat;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialog;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.CheckBox chkOutputCSV;
        private System.Windows.Forms.RichTextBox txtOutputCSVPath;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnClear;
    }
}


namespace osuRingtoneRipper
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_saveRingtone = new System.Windows.Forms.Button();
            this.songsList = new System.Windows.Forms.ListBox();
            this.songImage = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_random = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.songImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_saveRingtone
            // 
            this.btn_saveRingtone.Location = new System.Drawing.Point(804, 429);
            this.btn_saveRingtone.Name = "btn_saveRingtone";
            this.btn_saveRingtone.Size = new System.Drawing.Size(106, 23);
            this.btn_saveRingtone.TabIndex = 1;
            this.btn_saveRingtone.Text = "儲存為手機鈴聲";
            this.btn_saveRingtone.UseVisualStyleBackColor = true;
            this.btn_saveRingtone.Click += new System.EventHandler(this.btn_saveRingtone_Click);
            // 
            // songsList
            // 
            this.songsList.BackColor = System.Drawing.SystemColors.Window;
            this.songsList.FormattingEnabled = true;
            this.songsList.ItemHeight = 12;
            this.songsList.Location = new System.Drawing.Point(12, 40);
            this.songsList.Name = "songsList";
            this.songsList.Size = new System.Drawing.Size(294, 412);
            this.songsList.TabIndex = 2;
            this.songsList.SelectedIndexChanged += new System.EventHandler(this.songsList_SelectedValueChanged);
            this.songsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.songsList_MouseDoubleClick);
            // 
            // songImage
            // 
            this.songImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.songImage.Image = global::osuRingtoneRipper.Properties.Resources.img1452816;
            this.songImage.Location = new System.Drawing.Point(323, 16);
            this.songImage.Name = "songImage";
            this.songImage.Size = new System.Drawing.Size(587, 436);
            this.songImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.songImage.TabIndex = 3;
            this.songImage.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "敬請期待篩選功能";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn_random
            // 
            this.btn_random.Location = new System.Drawing.Point(723, 429);
            this.btn_random.Name = "btn_random";
            this.btn_random.Size = new System.Drawing.Size(75, 23);
            this.btn_random.TabIndex = 5;
            this.btn_random.Text = "隨機歌曲";
            this.btn_random.UseVisualStyleBackColor = true;
            this.btn_random.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.ControlDark;
            this.linkLabel1.Location = new System.Drawing.Point(12, 455);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(282, 12);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "osu! RingtoneRipper 0.1 beta © 2011 Lackneets 小耀博士";
            this.linkLabel1.VisitedLinkColor = System.Drawing.SystemColors.ControlDark;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(922, 474);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_random);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.songsList);
            this.Controls.Add(this.btn_saveRingtone);
            this.Controls.Add(this.songImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "osu! RingtoneRipper ";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.songImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_saveRingtone;
        private System.Windows.Forms.ListBox songsList;
        private System.Windows.Forms.PictureBox songImage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_random;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}


namespace AssetEncryptionTool
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            WorkDirField = new TextBox();
            SaveDirField = new TextBox();
            BrowseWorkDirBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            BrowseSaveDir = new Button();
            DecryptionBtn = new Button();
            EncryptionBtn = new Button();
            Log = new Panel();
            label4 = new Label();
            label3 = new Label();
            txt_key = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            Log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // WorkDirField
            // 
            WorkDirField.Font = new Font("Microsoft Sans Serif", 9.75F);
            WorkDirField.Location = new Point(58, 193);
            WorkDirField.Margin = new Padding(3, 4, 3, 4);
            WorkDirField.Multiline = true;
            WorkDirField.Name = "WorkDirField";
            WorkDirField.Size = new Size(393, 63);
            WorkDirField.TabIndex = 0;
            WorkDirField.WordWrap = false;
            // 
            // SaveDirField
            // 
            SaveDirField.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SaveDirField.Location = new Point(58, 288);
            SaveDirField.Margin = new Padding(3, 4, 3, 4);
            SaveDirField.Multiline = true;
            SaveDirField.Name = "SaveDirField";
            SaveDirField.Size = new Size(393, 63);
            SaveDirField.TabIndex = 1;
            SaveDirField.WordWrap = false;
            // 
            // BrowseWorkDirBtn
            // 
            BrowseWorkDirBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BrowseWorkDirBtn.ForeColor = SystemColors.ControlDarkDark;
            BrowseWorkDirBtn.Location = new Point(457, 193);
            BrowseWorkDirBtn.Margin = new Padding(3, 4, 3, 4);
            BrowseWorkDirBtn.Name = "BrowseWorkDirBtn";
            BrowseWorkDirBtn.Size = new Size(64, 63);
            BrowseWorkDirBtn.TabIndex = 2;
            BrowseWorkDirBtn.Text = "Find Path";
            BrowseWorkDirBtn.UseVisualStyleBackColor = true;
            BrowseWorkDirBtn.Click += BrowseWorkDirBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(54, 163);
            label1.Name = "label1";
            label1.Size = new Size(144, 24);
            label1.TabIndex = 3;
            label1.Text = "Input folder path";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(54, 260);
            label2.Name = "label2";
            label2.Size = new Size(159, 24);
            label2.TabIndex = 4;
            label2.Text = "Output folder path";
            // 
            // BrowseSaveDir
            // 
            BrowseSaveDir.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BrowseSaveDir.ForeColor = SystemColors.ControlDarkDark;
            BrowseSaveDir.Location = new Point(457, 288);
            BrowseSaveDir.Margin = new Padding(3, 4, 3, 4);
            BrowseSaveDir.Name = "BrowseSaveDir";
            BrowseSaveDir.Size = new Size(64, 63);
            BrowseSaveDir.TabIndex = 5;
            BrowseSaveDir.Text = "Find Path";
            BrowseSaveDir.UseVisualStyleBackColor = true;
            BrowseSaveDir.Click += BrowseSaveDir_Click;
            // 
            // DecryptionBtn
            // 
            DecryptionBtn.Font = new Font("Microsoft Sans Serif", 10F);
            DecryptionBtn.ForeColor = SystemColors.ControlDarkDark;
            DecryptionBtn.Location = new Point(818, 430);
            DecryptionBtn.Margin = new Padding(3, 4, 3, 4);
            DecryptionBtn.Name = "DecryptionBtn";
            DecryptionBtn.Size = new Size(92, 34);
            DecryptionBtn.TabIndex = 6;
            DecryptionBtn.Text = "decryption";
            DecryptionBtn.UseVisualStyleBackColor = true;
            DecryptionBtn.Click += DecryptionBtn_Click;
            // 
            // EncryptionBtn
            // 
            EncryptionBtn.FlatAppearance.BorderColor = Color.White;
            EncryptionBtn.FlatAppearance.BorderSize = 0;
            EncryptionBtn.Font = new Font("Microsoft Sans Serif", 10F);
            EncryptionBtn.ForeColor = SystemColors.ControlDarkDark;
            EncryptionBtn.Location = new Point(818, 376);
            EncryptionBtn.Margin = new Padding(3, 4, 3, 4);
            EncryptionBtn.Name = "EncryptionBtn";
            EncryptionBtn.Size = new Size(92, 36);
            EncryptionBtn.TabIndex = 7;
            EncryptionBtn.Text = "encryption";
            EncryptionBtn.UseVisualStyleBackColor = true;
            EncryptionBtn.Click += EncryptionBtn_Click;
            // 
            // Log
            // 
            Log.AccessibleDescription = "";
            Log.AccessibleName = "";
            Log.Controls.Add(label4);
            Log.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Log.Location = new Point(1150, 41);
            Log.Margin = new Padding(3, 4, 3, 4);
            Log.Name = "Log";
            Log.Size = new Size(270, 273);
            Log.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 15F);
            label4.Location = new Point(4, 4);
            label4.Name = "label4";
            label4.Size = new Size(45, 25);
            label4.TabIndex = 0;
            label4.Text = "Log";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 14.25F);
            label3.Location = new Point(605, 376);
            label3.Name = "label3";
            label3.Size = new Size(85, 24);
            label3.TabIndex = 10;
            label3.Text = "AES Key";
            // 
            // txt_key
            // 
            txt_key.Location = new Point(605, 403);
            txt_key.Multiline = true;
            txt_key.Name = "txt_key";
            txt_key.Size = new Size(207, 61);
            txt_key.TabIndex = 9;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.DevLabLogo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(-160, 250);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(906, 360);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.UnityWhite;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(630, 258);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(280, 91);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("맑은 고딕", 42F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(234, 45);
            label5.Name = "label5";
            label5.Size = new Size(578, 74);
            label5.TabIndex = 13;
            label5.Text = "AssetEncryptionTool";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(971, 533);
            Controls.Add(label5);
            Controls.Add(txt_key);
            Controls.Add(label3);
            Controls.Add(Log);
            Controls.Add(EncryptionBtn);
            Controls.Add(DecryptionBtn);
            Controls.Add(BrowseSaveDir);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BrowseWorkDirBtn);
            Controls.Add(SaveDirField);
            Controls.Add(WorkDirField);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.AppWorkspace;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "AssetEncryptionTool";
            Log.ResumeLayout(false);
            Log.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WorkDirField;
        private System.Windows.Forms.TextBox SaveDirField;
        private System.Windows.Forms.Button BrowseWorkDirBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseSaveDir;
        private System.Windows.Forms.Button DecryptionBtn;
        private System.Windows.Forms.Button EncryptionBtn;
        private System.Windows.Forms.Panel Log;
        private TextBox txt_key;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label5;
    }
}

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
            components = new System.ComponentModel.Container();
            WorkDirField = new TextBox();
            SaveDirField = new TextBox();
            BrowseWorkDirBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            BrowseSaveDir = new Button();
            DecryptionBtn = new Button();
            EncryptionBtn = new Button();
            Log = new Panel();
            txt_key = new TextBox();
            bindingSource1 = new BindingSource(components);
            Log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // WorkDirField
            // 
            WorkDirField.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            WorkDirField.Location = new Point(16, 41);
            WorkDirField.Margin = new Padding(3, 4, 3, 4);
            WorkDirField.Name = "WorkDirField";
            WorkDirField.Size = new Size(620, 29);
            WorkDirField.TabIndex = 0;
            WorkDirField.WordWrap = false;
            // 
            // SaveDirField
            // 
            SaveDirField.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            SaveDirField.Location = new Point(16, 110);
            SaveDirField.Margin = new Padding(3, 4, 3, 4);
            SaveDirField.Name = "SaveDirField";
            SaveDirField.Size = new Size(620, 29);
            SaveDirField.TabIndex = 1;
            SaveDirField.WordWrap = false;
            // 
            // BrowseWorkDirBtn
            // 
            BrowseWorkDirBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BrowseWorkDirBtn.Location = new Point(642, 39);
            BrowseWorkDirBtn.Margin = new Padding(3, 4, 3, 4);
            BrowseWorkDirBtn.Name = "BrowseWorkDirBtn";
            BrowseWorkDirBtn.Size = new Size(100, 40);
            BrowseWorkDirBtn.TabIndex = 2;
            BrowseWorkDirBtn.Text = "찾아보기";
            BrowseWorkDirBtn.UseVisualStyleBackColor = true;
            BrowseWorkDirBtn.Click += BrowseWorkDirBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(125, 24);
            label1.TabIndex = 3;
            label1.Text = "작업할 에셋 폴더";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(12, 80);
            label2.Name = "label2";
            label2.Size = new Size(125, 24);
            label2.TabIndex = 4;
            label2.Text = "저장할 에셋 폴더";
            // 
            // BrowseSaveDir
            // 
            BrowseSaveDir.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            BrowseSaveDir.Location = new Point(642, 108);
            BrowseSaveDir.Margin = new Padding(3, 4, 3, 4);
            BrowseSaveDir.Name = "BrowseSaveDir";
            BrowseSaveDir.Size = new Size(100, 40);
            BrowseSaveDir.TabIndex = 5;
            BrowseSaveDir.Text = "찾아보기";
            BrowseSaveDir.UseVisualStyleBackColor = true;
            BrowseSaveDir.Click += BrowseSaveDir_Click;
            // 
            // DecryptionBtn
            // 
            DecryptionBtn.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            DecryptionBtn.Location = new Point(16, 152);
            DecryptionBtn.Margin = new Padding(3, 4, 3, 4);
            DecryptionBtn.Name = "DecryptionBtn";
            DecryptionBtn.Size = new Size(187, 88);
            DecryptionBtn.TabIndex = 6;
            DecryptionBtn.Text = "복호화";
            DecryptionBtn.UseVisualStyleBackColor = true;
            DecryptionBtn.Click += DecryptionBtn_Click;
            // 
            // EncryptionBtn
            // 
            EncryptionBtn.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 129);
            EncryptionBtn.Location = new Point(209, 152);
            EncryptionBtn.Margin = new Padding(3, 4, 3, 4);
            EncryptionBtn.Name = "EncryptionBtn";
            EncryptionBtn.Size = new Size(187, 88);
            EncryptionBtn.TabIndex = 7;
            EncryptionBtn.Text = "암호화";
            EncryptionBtn.UseVisualStyleBackColor = true;
            EncryptionBtn.Click += EncryptionBtn_Click;
            // 
            // Log
            // 
            Log.AccessibleDescription = "";
            Log.AccessibleName = "";
            Log.Controls.Add(txt_key);
            Log.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
            Log.Location = new Point(402, 152);
            Log.Margin = new Padding(3, 4, 3, 4);
            Log.Name = "Log";
            Log.Size = new Size(340, 88);
            Log.TabIndex = 8;
            // 
            // txt_key
            // 
            txt_key.Location = new Point(5, 64);
            txt_key.Name = "txt_key";
            txt_key.Size = new Size(332, 21);
            txt_key.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 255);
            Controls.Add(Log);
            Controls.Add(EncryptionBtn);
            Controls.Add(DecryptionBtn);
            Controls.Add(BrowseSaveDir);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BrowseWorkDirBtn);
            Controls.Add(SaveDirField);
            Controls.Add(WorkDirField);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "AssetEncryptionTool";
            Log.ResumeLayout(false);
            Log.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
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
        private BindingSource bindingSource1;
    }
}

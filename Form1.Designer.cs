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
            this.WorkDirField = new System.Windows.Forms.TextBox();
            this.SaveDirField = new System.Windows.Forms.TextBox();
            this.BrowseWorkDirBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseSaveDir = new System.Windows.Forms.Button();
            this.DecryptionBtn = new System.Windows.Forms.Button();
            this.EncryptionBtn = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // WorkDirField
            // 
            this.WorkDirField.Font = new System.Drawing.Font("Yoon 윤고딕 330", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WorkDirField.Location = new System.Drawing.Point(16, 33);
            this.WorkDirField.Name = "WorkDirField";
            this.WorkDirField.Size = new System.Drawing.Size(620, 28);
            this.WorkDirField.TabIndex = 0;
            this.WorkDirField.WordWrap = false;
            // 
            // SaveDirField
            // 
            this.SaveDirField.Font = new System.Drawing.Font("Yoon 윤고딕 330", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SaveDirField.Location = new System.Drawing.Point(16, 88);
            this.SaveDirField.Name = "SaveDirField";
            this.SaveDirField.Size = new System.Drawing.Size(620, 28);
            this.SaveDirField.TabIndex = 1;
            this.SaveDirField.WordWrap = false;
            // 
            // BrowseWorkDirBtn
            // 
            this.BrowseWorkDirBtn.Font = new System.Drawing.Font("Yoon 윤고딕 330", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BrowseWorkDirBtn.Location = new System.Drawing.Point(642, 31);
            this.BrowseWorkDirBtn.Name = "BrowseWorkDirBtn";
            this.BrowseWorkDirBtn.Size = new System.Drawing.Size(100, 32);
            this.BrowseWorkDirBtn.TabIndex = 2;
            this.BrowseWorkDirBtn.Text = "찾아보기";
            this.BrowseWorkDirBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yoon 윤고딕 330", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "작업할 에셋 폴더";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yoon 윤고딕 330", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "저장할 에셋 폴더";
            // 
            // BrowseSaveDir
            // 
            this.BrowseSaveDir.Font = new System.Drawing.Font("Yoon 윤고딕 330", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BrowseSaveDir.Location = new System.Drawing.Point(642, 86);
            this.BrowseSaveDir.Name = "BrowseSaveDir";
            this.BrowseSaveDir.Size = new System.Drawing.Size(100, 32);
            this.BrowseSaveDir.TabIndex = 5;
            this.BrowseSaveDir.Text = "찾아보기";
            this.BrowseSaveDir.UseVisualStyleBackColor = true;
            // 
            // DecryptionBtn
            // 
            this.DecryptionBtn.Font = new System.Drawing.Font("Yoon 윤고딕 330", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DecryptionBtn.Location = new System.Drawing.Point(16, 122);
            this.DecryptionBtn.Name = "DecryptionBtn";
            this.DecryptionBtn.Size = new System.Drawing.Size(187, 70);
            this.DecryptionBtn.TabIndex = 6;
            this.DecryptionBtn.Text = "복호화";
            this.DecryptionBtn.UseVisualStyleBackColor = true;
            // 
            // EncryptionBtn
            // 
            this.EncryptionBtn.Font = new System.Drawing.Font("Yoon 윤고딕 330", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EncryptionBtn.Location = new System.Drawing.Point(209, 122);
            this.EncryptionBtn.Name = "EncryptionBtn";
            this.EncryptionBtn.Size = new System.Drawing.Size(187, 70);
            this.EncryptionBtn.TabIndex = 7;
            this.EncryptionBtn.Text = "암호화";
            this.EncryptionBtn.UseVisualStyleBackColor = true;
            // 
            // Log
            // 
            this.Log.AccessibleDescription = "";
            this.Log.AccessibleName = "";
            this.Log.Font = new System.Drawing.Font("Yoon 윤고딕 330", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Log.Location = new System.Drawing.Point(402, 122);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(340, 70);
            this.Log.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 204);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.EncryptionBtn);
            this.Controls.Add(this.DecryptionBtn);
            this.Controls.Add(this.BrowseSaveDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrowseWorkDirBtn);
            this.Controls.Add(this.SaveDirField);
            this.Controls.Add(this.WorkDirField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}


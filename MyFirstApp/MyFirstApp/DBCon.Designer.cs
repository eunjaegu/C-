namespace MyFirstApp
{
    partial class DBCon
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBCon));
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            txtServer = new TextBox();
            txtDatabase = new TextBox();
            txtUserId = new TextBox();
            txtPassword = new TextBox();
            groupBox1 = new GroupBox();
            txtPort = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.Location = new Point(113, 196);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(185, 27);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 39);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Sever:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 75);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 3;
            label2.Text = "Database:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 116);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 4;
            label3.Text = "User ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 156);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 5;
            label4.Text = "Password:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(27, 177);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(59, 46);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // txtServer
            // 
            txtServer.Location = new Point(120, 36);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(129, 23);
            txtServer.TabIndex = 7;
            // 
            // txtDatabase
            // 
            txtDatabase.Location = new Point(120, 72);
            txtDatabase.Name = "txtDatabase";
            txtDatabase.Size = new Size(185, 23);
            txtDatabase.TabIndex = 8;
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(113, 105);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(185, 23);
            txtUserId.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 153);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(185, 23);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtUserId);
            groupBox1.Controls.Add(txtPort);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Location = new Point(7, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(333, 246);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "DB Info";
            // 
            // txtPort
            // 
            txtPort.ImeMode = ImeMode.NoControl;
            txtPort.Location = new Point(248, 28);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(50, 23);
            txtPort.TabIndex = 12;
            txtPort.KeyPress += textPort_KeyPress;
            // 
            // DBCon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtPassword);
            Controls.Add(txtDatabase);
            Controls.Add(txtServer);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Name = "DBCon";
            Size = new Size(348, 263);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private TextBox txtServer;
        private TextBox txtDatabase;
        private TextBox txtUserId;
        private TextBox txtPassword;
        private GroupBox groupBox1;
        private TextBox txtPort;
    }
}

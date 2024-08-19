namespace MyFirstApp
{
    partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            userControl11 = new AboutCon();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(229, 379);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(497, 363);
            button1.Name = "button1";
            button1.Size = new Size(87, 28);
            button1.TabIndex = 1;
            button1.Text = "확인(&O)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // userControl11
            // 
            userControl11.Location = new Point(247, 12);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(349, 345);
            userControl11.TabIndex = 2;
            // 
            // DBInformatino2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 403);
            Controls.Add(userControl11);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "DBInformatino2";
            Text = "About MyDB";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private AboutCon userControl11;
    }
}
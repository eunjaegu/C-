namespace MyFirstApp
{
    partial class DBInformation
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
            dbCon1 = new DBCon();
            SuspendLayout();
            // 
            // dbCon1
            // 
            dbCon1.Location = new Point(0, 0);
            dbCon1.Name = "dbCon1";
            dbCon1.Size = new Size(348, 263);
            dbCon1.TabIndex = 0;
            dbCon1.Load += dbCon1_Load;
            // 
            // DBInformation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 258);
            Controls.Add(dbCon1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DBInformation";
            Text = "사용자";
            ResumeLayout(false);
        }

        #endregion

        private DBCon dbCon1;
    }
}
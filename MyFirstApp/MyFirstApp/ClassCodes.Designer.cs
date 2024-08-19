using System.Windows.Forms;
using System.Xml;

namespace MyFirstApp
{
    partial class classCodes
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
            components = new System.ComponentModel.Container();
            txtFilter = new TextBox();
            txtClsName = new TextBox();
            newButton = new Button();
            saveButton = new Button();
            txtClsNum = new TextBox();
            dataGridView = new DataGridView();
            contextMenuStrip = new ContextMenuStrip(components);
            newToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            searchButton = new Button();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(3, 4);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(300, 23);
            txtFilter.TabIndex = 0;
            // 
            // txtClsName
            // 
            txtClsName.Location = new Point(55, 33);
            txtClsName.Name = "txtClsName";
            txtClsName.Size = new Size(167, 23);
            txtClsName.TabIndex = 1;
            // 
            // newButton
            // 
            newButton.Location = new Point(228, 32);
            newButton.Name = "newButton";
            newButton.Size = new Size(59, 23);
            newButton.TabIndex = 3;
            newButton.Text = "New";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(293, 32);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(61, 23);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // txtClsNum
            // 
            txtClsNum.Enabled = false;
            txtClsNum.Location = new Point(3, 33);
            txtClsNum.Name = "txtClsNum";
            txtClsNum.Size = new Size(46, 23);
            txtClsNum.TabIndex = 5;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ContextMenuStrip = contextMenuStrip;
            dataGridView.Location = new Point(3, 62);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.Size = new Size(381, 268);
            dataGridView.TabIndex = 8;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { newToolStripMenuItem, deleteToolStripMenuItem, saveToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(181, 92);
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newButton_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteButton_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveButton_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(309, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 23);
            searchButton.TabIndex = 9;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(360, 32);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(24, 23);
            deleteButton.TabIndex = 10;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // classCodes
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 342);
            Controls.Add(deleteButton);
            Controls.Add(searchButton);
            Controls.Add(dataGridView);
            Controls.Add(txtClsNum);
            Controls.Add(saveButton);
            Controls.Add(newButton);
            Controls.Add(txtClsName);
            Controls.Add(txtFilter);
            Name = "classCodes";
            Text = "Class Codes";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private void LoadDataGridViewColumns(string xmlFilePath)
        {
            // 1. XML 파일 로드
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // 2. 컬럼 노드 리스트 선택
            XmlNodeList colList = xmlDoc.SelectNodes("/DataGridViewColumns/Column");

            // 3. 노드 리스트 null 여부 확인
            if (colList != null)
            {

                foreach (XmlNode node in colList)
                {
                    //< DataPropertyName > date </ DataPropertyName >
                    //< HeaderText > Date </ HeaderText >
                    //< MinimumWidth > 8 </ MinimumWidth >
                    //< Width > 300 </ Width >


                    string dataPropertyName = node["DataPropertyName"].InnerText;
                    string headerText = node["HeaderText"].InnerText;
                    int minimumWidth = int.Parse(node["MinimumWidth"].InnerText);
                    int width = int.Parse(node["Width"].InnerText);
                    bool readOnly = bool.Parse(node["ReadOnly"]?.InnerText ?? "false");
                    

                    // 고전적인 방식
                    /*
                    DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
                    column2.MinimumWidth = minimumWidth;
                    column2.Width = width;
                    column2.Name = dataPropertyName;
                    column2.HeaderText = headerText;
                    */

                    // 요즘 방식
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn
                    {
                        MinimumWidth = minimumWidth,
                        Width = width,
                        DataPropertyName = dataPropertyName,
                        HeaderText = headerText,
                        ReadOnly = readOnly
                    };

                    dataGridView.Columns.Add(column);


                }
            }




        }

        private TextBox txtFilter;
        private TextBox txtClsName;
        private Button newButton;
        private Button saveButton;
        private TextBox txtClsNum;
        private DataGridView dataGridView;
        private Button searchButton;
        private Button deleteButton;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
    }
}
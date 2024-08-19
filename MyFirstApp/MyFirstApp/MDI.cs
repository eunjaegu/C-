using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstApp
{
    public partial class MDI : Form
    {
        private int childFormNumber = 0;
        private Form dbInformation;
        private Form dbInformatino2;
        private Form classCodes;


        public MDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "창 " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void detectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form monitoringForm = new Monitoring();
            monitoringForm.MdiParent = this;
            monitoringForm.Show();
        }

        private void DBInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dbInformation == null || dbInformation.IsDisposed)
            {
                dbInformation = new DBInformation();
                dbInformation.MdiParent = this;
                dbInformation.FormClosed += dbInformation_FormClosed;
                dbInformation.Show();
            }
            else
            {
                dbInformation.Activate();
            }
        }
        private void dbInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbInformation = null;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dbInformatino2 == null || dbInformatino2.IsDisposed)
            {
                dbInformatino2 = new AboutBox();
                dbInformatino2.MdiParent = this;
                dbInformatino2.Show();
            }
            else
            {
                dbInformatino2.Activate();
            }
        }

        private void clsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (classCodes == null || classCodes.IsDisposed)
            {
                classCodes = new classCodes();
                classCodes.MdiParent = this;
                classCodes.Show();
            }else
            {
                classCodes.Activate();
            }


        }
    }
}

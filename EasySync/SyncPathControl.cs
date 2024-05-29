using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasySync
{
    public partial class SyncPathControl : UserControl
    {
        private string SourcePath = String.Empty;
        private string TargetPath = String.Empty;

        public SyncPathControl()
        {
            InitializeComponent();
        }

        public string sourcePath
        {
            get { return SourcePath; }
            set
            {
                SourcePath = value;
                lblSourcePath.Text = value;    
            }
        }
        public string targetPath
        {
            get { return TargetPath; }
            set
            {
                TargetPath = value;
                lblTargetPath.Text = value;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblSourcePath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    lblSourcePath.Text = folderBrowserDialog.SelectedPath;
                    sourcePath = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void lblTargetPath_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    lblTargetPath.Text = folderBrowserDialog.SelectedPath;
                    targetPath = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}

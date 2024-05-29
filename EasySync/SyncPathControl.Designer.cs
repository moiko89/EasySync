namespace EasySync
{
    partial class SyncPathControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            pnlRight = new Panel();
            btnDelete = new Button();
            pnlLeft = new Panel();
            splitContainer1 = new SplitContainer();
            lblSourcePath = new Label();
            lblTargetPath = new Label();
            pnlRight.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(btnDelete);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(592, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(40, 34);
            pnlRight.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(40, 34);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "X";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(splitContainer1);
            pnlLeft.Dock = DockStyle.Fill;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(592, 34);
            pnlLeft.TabIndex = 2;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblSourcePath);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblTargetPath);
            splitContainer1.Size = new Size(592, 34);
            splitContainer1.SplitterDistance = 294;
            splitContainer1.SplitterWidth = 2;
            splitContainer1.TabIndex = 0;
            // 
            // lblSourcePath
            // 
            lblSourcePath.Location = new Point(0, 0);
            lblSourcePath.Name = "lblSourcePath";
            lblSourcePath.Size = new Size(400, 34);
            lblSourcePath.TabIndex = 3;
            lblSourcePath.Text = "...";
            lblSourcePath.Click += lblSourcePath_Click;
            // 
            // lblTargetPath
            // 
            lblTargetPath.Dock = DockStyle.Fill;
            lblTargetPath.Location = new Point(0, 0);
            lblTargetPath.Name = "lblTargetPath";
            lblTargetPath.Size = new Size(296, 34);
            lblTargetPath.TabIndex = 2;
            lblTargetPath.Text = "...";
            lblTargetPath.Click += lblTargetPath_Click;
            // 
            // SyncPathControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(pnlLeft);
            Controls.Add(pnlRight);
            Name = "SyncPathControl";
            Size = new Size(632, 34);
            pnlRight.ResumeLayout(false);
            pnlLeft.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRight;
        private Button btnDelete;
        private Panel pnlLeft;
        private SplitContainer splitContainer1;
        private Label lblTargetPath;
        private Label lblSourcePath;
    }
}

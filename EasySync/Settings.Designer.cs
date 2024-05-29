namespace EasySync
{
    partial class Settings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpSyncPathControll = new FlowLayoutPanel();
            btnAddSyncPathControl = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // flpSyncPathControll
            // 
            flpSyncPathControll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpSyncPathControll.AutoScroll = true;
            flpSyncPathControll.Location = new Point(12, 12);
            flpSyncPathControll.Name = "flpSyncPathControll";
            flpSyncPathControll.Size = new Size(776, 286);
            flpSyncPathControll.TabIndex = 1;
            // 
            // btnAddSyncPathControl
            // 
            btnAddSyncPathControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddSyncPathControl.Location = new Point(12, 304);
            btnAddSyncPathControl.Name = "btnAddSyncPathControl";
            btnAddSyncPathControl.Size = new Size(75, 23);
            btnAddSyncPathControl.TabIndex = 2;
            btnAddSyncPathControl.Text = "Add";
            btnAddSyncPathControl.UseVisualStyleBackColor = true;
            btnAddSyncPathControl.Click += btnAddSyncPathControl_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.Location = new Point(93, 304);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 339);
            Controls.Add(btnSave);
            Controls.Add(btnAddSyncPathControl);
            Controls.Add(flpSyncPathControll);
            Name = "Settings";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpSyncPathControll;
        private Button btnAddSyncPathControl;
        private Button btnSave;
    }
}
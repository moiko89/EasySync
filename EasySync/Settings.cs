using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;
using System.Xml.Serialization;

namespace EasySync
{
    public partial class Settings : Form
    {
        public List<EasySyncObject> SyncQueue;
        private string SettingsFilePath;
        
        public Settings(List<EasySyncObject> syncQueue, string settingsFilePath)
        {
            InitializeComponent();
            SyncQueue = syncQueue;
            SettingsFilePath = settingsFilePath;
            if (syncQueue != null )
            {
                flpSyncPathControll.Controls.Clear();
                foreach ( EasySyncObject syncObject in syncQueue )
                {
                    SyncPathControl c = new SyncPathControl();
                    c.sourcePath = syncObject.SourcePath;
                    c.targetPath = syncObject.TargetPath;
                    c.Dock = DockStyle.Top;
                    flpSyncPathControll.Controls.Add(c);
                }
            }
            
        }

        private void btnAddSyncPathControl_Click(object sender, EventArgs e)
        {
            SyncPathControl c = new SyncPathControl();
            c.Dock = DockStyle.Top;
            flpSyncPathControll.Controls.Add(c);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SyncQueue.Clear();
            foreach (SyncPathControl c in flpSyncPathControll.Controls)
            {
                SyncQueue.Add(new EasySyncObject(c.sourcePath, c.targetPath));
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<EasySyncObject>));
            using (TextWriter writer = new StreamWriter(SettingsFilePath))
            {
                serializer.Serialize(writer, SyncQueue);
            }
        }

        
    }
}
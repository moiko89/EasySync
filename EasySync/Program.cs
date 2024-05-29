using System;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.DataFormats;
using System.Timers;
using System.Xml.Serialization;

namespace EasySync
{
    internal static class Program
    {
        private static Mutex mutex = new Mutex(true, "{B9EE5475-8A68-4C5F-BF69-40A91576E554}");

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new EasySyncBase());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Anwendung läuft bereits.", "EasySync", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class EasySyncBase : ApplicationContext
    {
        private NotifyIcon notifyIcon;
        private Settings settingsForm;
        private List<EasySyncObject> SyncQueue = new List<EasySyncObject>();
    
        string SettingsFilePath;
        string SettingsFileName = "syncQueue.xml";

        public EasySyncBase()
        {
            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                ContextMenuStrip = new ContextMenuStrip()
            };

            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", null, Exit);
            notifyIcon.ContextMenuStrip.Items.Add(exitMenuItem);

            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;

            SettingsFilePath = GetAppDataFilePath(SettingsFileName);
            LoadFromXml(SettingsFilePath);

            //notifyIcon.ShowBalloonTip(1000, "EasySync", "Application started", ToolTipIcon.Info);
        }
        
        public static string GetAppDataFilePath(string fileName)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(appDataFolder, "EasySync");
            Directory.CreateDirectory(folderPath);
            return Path.Combine(folderPath, fileName);
        }

        public void LoadFromXml(string filePath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<EasySyncObject>));
                using (TextReader reader = new StreamReader(filePath))
                {
                    SyncQueue = (List<EasySyncObject>)serializer.Deserialize(reader);
                }
            } catch (Exception ex) { }
            
        }

        void Exit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (settingsForm == null || settingsForm.IsDisposed)
            {
                settingsForm = new Settings(SyncQueue, SettingsFilePath);
            }
            settingsForm.Show();
            settingsForm.BringToFront();
        }
    }
    [Serializable]
    public class EasySyncObject
    {
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        private System.Timers.Timer timer;

        public EasySyncObject(string sourcePath, string targetPath)
        {
            SourcePath = sourcePath;
            TargetPath = targetPath;
            InitializeTimer();
        }

        public EasySyncObject()
        {
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer(10 * 1000);
            timer.Elapsed += async (sender, e) => await OnTimerElapsedAsync(sender, e);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void StartSync()
        {
            if (timer != null)
                timer.Start();
        }

        public void StopSync()
        {
            if (timer != null)
                timer.Stop();
        }

        private async Task OnTimerElapsedAsync(object sender, ElapsedEventArgs e)
        {
            await SynchronizeAsync(SourcePath, TargetPath);
        }

        private async Task SynchronizeAsync(string sourcePath, string targetPath)
        {
            try
            {
                DirectoryInfo source = new DirectoryInfo(sourcePath);
                DirectoryInfo target = new DirectoryInfo(targetPath);

                if (!source.Exists)
                    return;

                if (!target.Exists)
                    target.Create();

                foreach (FileInfo file in target.GetFiles())
                {
                    string sourceFilePath = Path.Combine(source.FullName, file.Name);
                    if (!File.Exists(sourceFilePath))
                        file.Delete();
                }

                foreach (DirectoryInfo subDir in target.GetDirectories())
                {
                    string sourceSubDirPath = Path.Combine(source.FullName, subDir.Name);
                    if (!Directory.Exists(sourceSubDirPath))
                        subDir.Delete(true);
                }

                foreach (FileInfo file in source.GetFiles())
                {
                    string destFile = Path.Combine(target.FullName, file.Name);
                    try
                    {
                        await Task.Run(() => file.CopyTo(destFile, true));
                    } catch (Exception ex) { }
                    
                }

                foreach (DirectoryInfo subDir in source.GetDirectories())
                {
                    string targetSubDir = Path.Combine(target.FullName, subDir.Name);
                    await SynchronizeAsync(subDir.FullName, targetSubDir);
                }
            }
            catch (Exception ex) { }
        }

        public void Dispose()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }
    }

}

using Newtonsoft.Json;
using ShortWhisper.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortWhisper
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string configText;
            try
            {
                configText = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".shortwhisper.config.json"));
            }
            catch (Exception e)
            {
                MessageBox.Show($"Config file not found! Should be in ~/.shortwhisper.config.json. Error: {e}");
                return;
            }

            Config configObject;
            try
            {
                configObject = JsonConvert.DeserializeObject<Config>(configText);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Cannot deserialize config file: ${e}");
                return;
            }

            var form = new Form1(configObject)
            {
                ShowInTaskbar = false
            };
            form.Hide();

            var trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "ShortWhisper is working",
                ContextMenuStrip = new ContextMenuStrip()
            };
            trayIcon.ContextMenuStrip.Items.Add("Record", null, (a, b) => { form.Init(); form.Show(); });
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, (a, b) => Application.Exit());

            Process whisperServer;
            try
            {
                whisperServer = Process.Start(new ProcessStartInfo(configObject.BinaryPath, $"-m {configObject.ModelPath} --port {configObject.ServerPort}")
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                });
            }
            catch (Exception e)
            {
                MessageBox.Show($"Cannot start whisper server: {e}");
                return;
            }

            Application.ApplicationExit += (a, b) => whisperServer.Kill();

            Application.Run();
        }
    }
}

using ShortWhisper.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
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

            var hotkey = new HotkeyWindow(() => new MainForm().Show());

            var trayIcon = new NotifyIcon
            {
                Icon = SystemIcons.Application,
                Visible = true,
                Text = "ShortWhisper is working",
                ContextMenuStrip = new ContextMenuStrip()
            };
            trayIcon.MouseClick += (a, b) => { if (b.Button == MouseButtons.Left) new MainForm().Show(); };
            trayIcon.ContextMenuStrip.Items.Add("Settings", null, (a, b) => new SettingsForm().Show());
            trayIcon.ContextMenuStrip.Items.Add("Restart server", null, (a, b) => WhisperController.Start());
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, (a, b) => Application.Exit());

            WhisperController.Start();

            Application.ApplicationExit += (a, b) =>
            {
                hotkey.Dispose();
                WhisperController.Kill();
            };

            Application.Run();
        }
    }
}

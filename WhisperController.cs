using DesktopWhisper.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DesktopWhisper
{
    internal class WhisperController
    {
        private static Process _process = null;

        public static void Start()
        {
            Kill();
            try
            {
                _process = Process.Start(new ProcessStartInfo(
                        Settings.Default.ServerBinaryPath,
                        $"-m {Settings.Default.ModelPath} --port {Settings.Default.ServerPort}"
                )
                { WindowStyle = ProcessWindowStyle.Hidden });
            }
            catch (Exception e)
            {
                MessageBox.Show($"Cannot start whisper server. Perhaps, you need to fill settings. Then save and restart server.\nInner error: {e.Message}");
            }
        }

        public static void Kill()
        {
            if (_process != null && !_process.HasExited)
            {
                _process.Kill();
                _process = null;
            }
        }
    }
}

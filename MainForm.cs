using NAudio.Wave;
using DesktopWhisper.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DesktopWhisper
{
    public partial class MainForm : Form
    {
        private WaveInEvent _waveIn = new WaveInEvent();
        private string _filePath = Path.GetTempFileName() + ".wav";
        private FileStream _innerFileStream;
        private WaveFileWriter _waveFileStream;

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        public MainForm()
        {
            InitializeComponent();

            var cursor = Cursor.Position;

            StartPosition = FormStartPosition.Manual;
            Location = new Point(
                cursor.X - 92,
                cursor.Y - 30
            );
            TopMost = true;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.None;
            _innerFileStream = new FileStream(_filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            _waveFileStream = new WaveFileWriter(_innerFileStream, _waveIn.WaveFormat);
            _waveIn.DataAvailable += WaveIn_DataAvailable;
            _waveIn.RecordingStopped += WaveIn_RecordingStopped;
            _waveIn.StartRecording();
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            _waveFileStream.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => WaveIn_RecordingStopped(sender, e)));
                return;
            }
            Hide();
            _waveFileStream.Flush();
            _innerFileStream.Seek(0, SeekOrigin.Begin);
            var client = new HttpClient();
            var formData = new MultipartFormDataContent
            {
                { new StreamContent(_innerFileStream), "file", Path.GetFileName(_filePath) },
                { new StringContent("0"), "temperature" },
                { new StringContent(Settings.Default.Language), "language" },
                { new StringContent("text"), "response_format" }
            };
            var resp = client.PostAsync($"http://localhost:{Settings.Default.ServerPort}/inference", formData).Result;
            var content = resp.Content.ReadAsStringAsync().Result;
            Clipboard.SetText(Regex.Replace(content, "\\s+", " ").Trim());
            if (Settings.Default.PasteImmediately) SendKeys.Send("^{v}");
            if (Settings.Default.ShowPopup) new NotificationForm().Show();
            _waveFileStream = null;
            Close();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            _waveIn.StopRecording();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            _waveIn.DataAvailable -= WaveIn_DataAvailable;
            _waveIn.RecordingStopped -= WaveIn_RecordingStopped;
            _waveIn.StopRecording();
            _waveFileStream?.Dispose();
            File.Delete(_filePath);
        }
    }
}

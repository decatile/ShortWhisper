using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShortWhisper
{
    public partial class Form1 : Form
    {
        private Config _config;

        private WaveInEvent _waveIn = new WaveInEvent();
        private string _waveFilePath;
        private WaveFileWriter _waveFileWriter;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        public Form1(Config config)
        {
            _config = config;
            InitializeComponent();
            bool ok = RegisterHotKey(Handle, 1, 0, (int)Keys.F12);
            if (!ok)
            {
                MessageBox.Show($"Hotkey error: {Marshal.GetLastWin32Error()}");
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                if (id == 1)
                {
                    Init();
                    Show();
                }
            }
            base.WndProc(ref m);
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            _waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => WaveIn_RecordingStopped(sender, e)));
                return;
            }
            _waveFileWriter.Close();
            _waveFileWriter = null;
            using (var stream = new FileStream(_waveFilePath, FileMode.Open))
            {
                var client = new HttpClient();
                var formData = new MultipartFormDataContent
                    {
                        { new StreamContent(stream), "file", Path.GetFileName(_waveFilePath) },
                        { new StringContent("0"), "temperature" },
                        { new StringContent(_config.Language), "language" },
                        { new StringContent("text"), "response_format" }
                    };
                var resp = client.PostAsync($"http://localhost:{_config.ServerPort}/inference", formData).Result;
                var content = resp.Content.ReadAsStringAsync().Result;
                Clipboard.SetText(content);
            }
            Close();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            _waveIn.StopRecording();
        }

        public void Init()
        {
            _waveFilePath = Path.GetTempFileName() + ".wav";
            _waveFileWriter = new WaveFileWriter(_waveFilePath, _waveIn.WaveFormat);
            _waveIn.DataAvailable += WaveIn_DataAvailable;
            _waveIn.RecordingStopped += WaveIn_RecordingStopped;
            _waveIn.StartRecording();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _waveIn.DataAvailable -= WaveIn_DataAvailable;
            _waveIn.RecordingStopped -= WaveIn_RecordingStopped;
            _waveIn.StopRecording();
            _waveFileWriter?.Close();
            File.Delete(_waveFilePath);
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {

            }
            else
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShortWhisper
{
    public partial class NotificationForm : Form
    {
        protected override bool ShowWithoutActivation => true;

        public NotificationForm()
        {
            InitializeComponent();
            var screen = Screen.PrimaryScreen.WorkingArea;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(
                screen.Right - Width - 20,
                screen.Bottom - Height - 20
            );
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (a, b) =>
            {
                timer.Stop();
                Close();
            };
            timer.Start();
        }
    }
}

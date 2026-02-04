using DesktopWhisper.Properties;
using System;
using System.Windows.Forms;

namespace DesktopWhisper
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            serverPathTextBox.Text = Settings.Default.ServerBinaryPath;
            modelPathTextBox.Text = Settings.Default.ModelPath;
            portTextBox.Text = Convert.ToString(Settings.Default.ServerPort);
            langTextBox.Text = Settings.Default.Language;
            popupTextBox.Text = Convert.ToString(Settings.Default.ShowPopup);
            pasteTextBox.Text = Convert.ToString(Settings.Default.PasteImmediately);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.ServerBinaryPath = serverPathTextBox.Text;
            Settings.Default.ModelPath = modelPathTextBox.Text;
            Settings.Default.ServerPort = Convert.ToInt32(portTextBox.Text);
            Settings.Default.Language = langTextBox.Text;
            Settings.Default.ShowPopup = Convert.ToBoolean(popupTextBox.Text);
            Settings.Default.PasteImmediately = Convert.ToBoolean(pasteTextBox.Text);
            Settings.Default.Save();
        }
    }
}

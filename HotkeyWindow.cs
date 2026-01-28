using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShortWhisper
{
    internal class HotkeyWindow : NativeWindow, IDisposable
    {
        private const int HOTKEY_ID = 1;
        private const int WM_HOTKEY = 0x0312;
        private readonly Action _onHotkey;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public HotkeyWindow(Action onHotkey)
        {
            CreateHandle(new CreateParams());
            _onHotkey = onHotkey;
            RegisterHotKey(Handle, HOTKEY_ID, 0x0008 | 0x0001, (int)Keys.P);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                _onHotkey();
                return;
            }
            base.WndProc(ref m);
        }

        public void Dispose()
        {
            UnregisterHotKey(Handle, HOTKEY_ID);
        }
    }
}

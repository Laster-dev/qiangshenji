using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using 枪神纪.通知;

namespace 枪神纪
{
    internal static class Program
    {
        static NotifyIcon notifyIcon = new NotifyIcon();
        public static void ShowNotification(string text, int duration)
        {
            MessageForm messageForm = new MessageForm(text,duration);
            messageForm.Show();
        }
        public static IntPtr Qsj { get; set; }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

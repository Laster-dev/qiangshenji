﻿using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 枪神纪.Properties;

namespace 枪神纪.九职业
{
    public partial class Form5 : MyForm
    {
        Thread thread { get; set; }
        public Form5()
        {
            InitializeComponent();
            BackgroundImage = Resources.dd;
        }

        private async void 自动背刺ToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }
            if (自动背刺ToolStripMenuItem.Checked)
            {
                //await Task.Delay(3000);
                thread = new Thread(dd);
                thread.Start();
            }

        }

        async void dd() 
        {
            while (true)
            {
                if (WinApi.IsKeyPressed(5))
                {
                    WinApi.MoveMouse(0, 300);                                   //向下
                    await Task.Delay(0);
                    WinApi.keybd_event(17, 0, WinApi.KEYEVENTF_KEYDOWN, 0);
                    WinApi.Key(32);                                                 //空格
                                 
                    await Task.Delay(10);
                    WinApi.LeftMouseClick();
                    await Task.Delay(5);
                    WinApi.MoveMouse(0, -300);
                    WinApi.keybd_event(17, 0, WinApi.KEYEVENTF_KEYUP, 0); // 抬起      
                }
                Thread.Sleep(5);
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

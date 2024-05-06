using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 枪神纪.Properties;

namespace 枪神纪.九职业
{
    public partial class Form8 : MyForm
    {
        Thread thread { get; set; }
        int M { get; set; }
        public Form8()
        {
            InitializeComponent();
            BackgroundImage = Resources.ld;
        }

        private void 自动背刺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            M = int.Parse(toolStripTextBox1.Text);
            if (thread != null)
            {
                thread.Abort();
            }
            if (自动背刺ToolStripMenuItem.Checked)
            {
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
                    /*
                    WinApi.MoveMouse(M, 700);                                 //向下/后
                    await Task.Delay(5);
                    WinApi.LeftMouseClick();                                    //左
                    await Task.Delay(15);
                    WinApi.MoveMouse(-M, -700);                                 //回反向
                    WinApi.Key(32);                                             //空格
                    await Task.Delay(15);
                    WinApi.RightMouseClick();                                     // 模拟鼠标右键
                    await Task.Delay(15);
                    */

                    WinApi.MoveMouse(M, 00);                                 //向下/后
                    await Task.Delay(0);
                    WinApi.Key(32);                                             //空格
                    WinApi.LeftMouseClick();                                    //左
                    await Task.Delay(10);
                    WinApi.RightMouseClick();                                     // 模拟鼠标右键
                    WinApi.MoveMouse(-M, -00);                                 //回反向

                    await Task.Delay(500);


                }
                Thread.Sleep(5);
            }
        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thread != null)
            {
                thread.Abort();
                
            }
        }
    }
}

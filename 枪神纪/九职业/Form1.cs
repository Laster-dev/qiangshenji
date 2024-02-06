using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using 枪神纪.Properties;

namespace 枪神纪.九职业
{
    public partial class Form1 : MyForm
    {
        List<Point> points = new List<Point>();
        List<Point> points2 = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            BackgroundImage = Resources.df;
            //contextMenuStrip1.Renderer = new CustomContextMenuStripRenderer();
        }
        Color GameColor = Color.FromArgb(12, 230, 0);
        //12,230,0
        private void timer1_Tick(object sender, EventArgs e)
        {
            IntPtr hWnd = WinApi.GetForegroundWindow();
            if (hWnd == Program.Qsj)
            {
                int i = 0;
                Random random = new Random();
                Point selectedPoint = points[random.Next(points.Count)];
                Point selectedPoint2 = points2[random.Next(points.Count)];
                for (int j = 0; j < 3; j++)
                {
                    if (WinApi.GetPixelColor(Program.Qsj, selectedPoint2.X, selectedPoint2.Y) == Color.Black)
                    {
                        return;
                    }
                    if (WinApi.GetPixelColor(Program.Qsj, selectedPoint2.X, selectedPoint2.Y) == GameColor)
                    {
                        return;
                    }
                }
                WinApi.LeftMouseClick();
            }
        }

        private async void 自动背刺ToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            points.Clear();
            if (自动背刺ToolStripMenuItem.Checked)
            {
                //MessageBox.Show("");
                Program.ShowNotification("即将开始初始化扫描色彩，预估10秒", 3000);
                await Task.Delay(3000);
                var size = WinApi.GetWindowSize(Program.Qsj);
                int centerX = size.Width / 2; int centerY = size.Height / 2;// 创建一个宽度和高度都是100像素的扫描区域，中心与窗口中心对齐
                Rectangle scanArea = new Rectangle(centerX - 50, centerY - 50, 100, 100); // 扫描区域
                points = await WinApi.ScanColorAsync(Program.Qsj, Color.FromArgb(0, 0, 0), scanArea);
                points2 = await WinApi.ScanColorAsync(Program.Qsj, Color.FromArgb(12, 230, 0), scanArea);
                Program.ShowNotification($"扫描完毕！获取到{points2.Count}个关键点，{points.Count}个辅助点", 3000);
                if (points2.Count > 1)
                {
                    timer1.Enabled = true;
                }
                else
                {
                    await Task.Delay(3000);
                    Program.ShowNotification($"===关键点不足===", 3000);
                    自动背刺ToolStripMenuItem.Checked = false;
                }
                
            }
            else { timer1.Enabled = false; }
        }
    }
}

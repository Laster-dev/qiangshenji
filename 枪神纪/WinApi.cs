using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static 枪神纪.WinApi;

namespace 枪神纪
{
    internal class WinApi
    {
        [DllImport("gdi32.dll")] 
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc); 
        [DllImport("gdi32.dll")] 
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight); 
        [DllImport("gdi32.dll")] 
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject); 
        [DllImport("gdi32.dll")] 
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop); 
        [DllImport("gdi32.dll")] 
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow(); 
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("gdi32.dll")] 
        public static extern bool DeleteDC(IntPtr hdc); // 导入DeleteDC函数
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern uint GetPixel(IntPtr hDC, int nXPos, int nYPos);
        [DllImport("gdi32.dll")]
        public static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("gdi32.dll")]
        public static extern bool SetPixel(IntPtr hdc, int X, int Y, uint crColor); 
        // 用于将Color对象转换为COLORREF格式
        public static uint ColorToCOLORREF(Color color)    {        return (uint)((color.R | (color.G << 8)) | (color.B << 16));    }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; // x position of upper-left corner
            public int Top; // y position of upper-left corner
            public int Right; // x position of lower-right corner
            public int Bottom; // y position of lower-right corner
        }
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey); 
        /// <summary>
        /// 判断某个键有没有被按下
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        public static bool IsKeyPressed(int vKey) 
        { 
            return (GetAsyncKeyState(vKey) & 0x8000) != 0; 
        }
        [DllImport("user32.dll")] 
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        private const uint MOUSEEVENTF_MOVE = 0x0001;
        /// <summary>
        /// 相对移动鼠标位置
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public static void MoveMouse(int dx, int dy) 
        { 
            mouse_event(MOUSEEVENTF_MOVE, (uint)dx, (uint)dy, 0, 0);
        }
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002; // 左键按下
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;   // 左键抬起
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008; // 右键按下
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010;   // 右键抬起
        public static void LeftMouseClick(){    
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0); // 模拟左键按下
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);   // 模拟左键抬起
        }
        public static void RightMouseClick(){  
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0); // 模拟右键按下
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);   // 模拟右键抬起
        }
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        public const uint KEYEVENTF_KEYDOWN = 0x0000; // 按下键
        public const uint KEYEVENTF_KEYUP = 0x0002; // 抬起键
        public static void Key(byte key){ 
            keybd_event(key, 0, KEYEVENTF_KEYDOWN, 0); 
            keybd_event(key, 0, KEYEVENTF_KEYUP, 0); // 抬起
        }
        public const int KEYEVENTF_EXTENDEDKEY = 0x1; 
  
        public static Size GetWindowSize(IntPtr hWnd)
        {
            WinApi.RECT rect;
            if (WinApi.GetWindowRect(hWnd, out rect))
            { 
                return new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);
            } 
            else
            { 
                throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        /// <summary>
        /// 取像素
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static Color GetPixelColor(IntPtr hWnd, int x, int y)
        {
            IntPtr hDC = WinApi.GetDC(hWnd); // 获取窗口的设备上下文
            uint pixel = WinApi.GetPixel(hDC, x, y); // 获取指定坐标的像素值
            WinApi.ReleaseDC(hWnd, hDC); // 释放设备上下文
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
            (int)(pixel & 0x0000FF00) >> 8,
            (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }
        /// <summary>
        /// 异步扫描指定色
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="targetColor"></param>
        /// <param name="scanArea"></param>
        /// <returns></returns>
        public static async Task<List<Point>> ScanColorAsync(IntPtr hWnd, Color color, Rectangle scanArea) { return await Task.Run(() => WinApi.ScanColor(hWnd, color, scanArea)); }
        /// <summary>
        /// 扫描指定色
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="targetColor"></param>
        /// <param name="scanArea"></param>
        /// <returns></returns>
        public static List<Point> ScanColor(IntPtr hWnd, Color targetColor, Rectangle scanArea)
        {

            List<Point> foundPoints = new List<Point>();
            IntPtr hDC = WinApi.GetDC(hWnd);
            
            for (int x = scanArea.Left; x < scanArea.Right; x++)
            {
                for (int y = scanArea.Top; y < scanArea.Bottom; y++)
                {
                    // Rectangle(hDC,scanArea.Left,scanArea.Top,scanArea.Right,scanArea.Bottom);

                    uint pixel = WinApi.GetPixel(hDC, x, y);
                    SetPixel(hDC, x, y, ColorToCOLORREF(Color.Black));


                    Color color = Color.FromArgb((int)(pixel & 0x000000FF), (int)(pixel & 0x0000FF00) >> 8, (int)(pixel & 0x00FF0000) >> 16);
                    if (color == targetColor)
                    {
                        foundPoints.Add(new Point(x, y));
                    }
                }
            }
            WinApi.ReleaseDC(hWnd, hDC);
            return foundPoints;
        }
        /// <summary>
        /// 绘制矩形的方法
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="penWidth"></param>
        public static void DrawRectangle(IntPtr hWnd, Rectangle rect, Color color, int penWidth)    {        IntPtr hDC = GetDC(hWnd);        using (Graphics g = Graphics.FromHdc(hDC))        {            using (Pen pen = new Pen(color, penWidth))            {                g.DrawRectangle(pen, rect);            }        }        ReleaseDC(hWnd, hDC);    }
    }
}

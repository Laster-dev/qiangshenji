using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 枪神纪
{
    internal class FormUI
    {
        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);



        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        public static void DarkThemeTitleBar(IntPtr hwnd)
        {
            if (DwmSetWindowAttribute(hwnd, 19, new[] { 1 }, 4) != 0)
            {
                DwmSetWindowAttribute(hwnd, 20, new[] { 1 }, 4);
            }
        }
        // 定义边距结构
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        public static void UI_标题栏纯色(IntPtr hwnd)
        {
            MARGINS margins = new MARGINS()
            {
                leftWidth = 0,
                rightWidth = 0,
                topHeight = 20,
                bottomHeight = 0,

            };
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
        }
        public static void UI_标题栏原生(IntPtr hwnd)
        {
            MARGINS margins = new MARGINS()
            {
                leftWidth = 0,
                rightWidth = 0,
                topHeight = 0,
                bottomHeight = 0,

            };
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
        }
        public static void UI_全局透明(IntPtr hwnd)
        {
            MARGINS margins = new MARGINS()
            {
                leftWidth = 0,
                rightWidth = 20000000,
                topHeight = 0,
                bottomHeight = 0,

            };
            DwmExtendFrameIntoClientArea(hwnd, ref margins);
        }
    }
}

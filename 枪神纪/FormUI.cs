using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 枪神纪
{
    //contextMenuStrip1.Renderer = new CustomContextMenuStripRenderer();
    public class CustomContextMenuStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
            {
                if (e.Item.Selected) // 如果当前项被选中（鼠标悬停）
                {
                    // 设置鼠标悬停时的背景色
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, 100, 255)), e.Item.ContentRectangle);
                }
                else
                {
                    // 设置默认的背景色
                    base.OnRenderMenuItemBackground(e);
                }
            }
        }
    }
    internal class FormUI
    {
        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        public static bool Theme = false;
        public static void DarkThemeTitleBar(IntPtr hwnd)
        {
            // 根据当前主题反转设置
            int[] attributeValue = Theme ? new[] { 0 } : new[] { 1 }; // 如果当前是暗色主题，则切换到亮色，反之亦然

            if (DwmSetWindowAttribute(hwnd, 19, attributeValue, 4) != 0)
            {
                DwmSetWindowAttribute(hwnd, 20, attributeValue, 4);
            }
            Theme = !Theme;
        }
        // 定义边距结构
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        public static void UI_标题栏纯色(IntPtr hwnd)
        {
            MARGINS margins = new MARGINS()
            {
                leftWidth = 0,
                rightWidth = 0,
                topHeight = 1,
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 枪神纪.Properties;

namespace 枪神纪
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormUI.DarkThemeTitleBar(this.Handle);
            FormUI.UI_全局透明(this.Handle);
            FormUI.InvalidateRect(this.Handle, IntPtr.Zero, true);
            this.MouseWheel += new MouseEventHandler(this.MainForm_MouseWheel);
        }
        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            // 获取当前字体
            Font currentFont = this.Font;

            // 定义字体大小调整的步长
            float fontSizeChange = e.Delta > 0 ? 0.3f : -0.3f;//大小

            // 计算新的字体大小，确保字体大小至少为1
            float newFontSize = Math.Max(1, currentFont.Size + fontSizeChange);

            // 设置新的字体大小
            this.Font = new Font(currentFont.FontFamily, newFontSize, currentFont.Style);

            // 可选：如果你有特定的控件需要更新字体，可以在这里设置
            // 如：label1.Font = new Font(label1.Font.FontFamily, newFontSize, label1.Font.Style);
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.df;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.ly;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.sq;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.jq;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.dd;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.jj;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.ys;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.ld;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Resources.gcs;
        }
    }
}

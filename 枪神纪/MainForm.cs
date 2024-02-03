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
using 枪神纪.九职业;

namespace 枪神纪
{
    public partial class MainForm : MyForm
    {
        static Form ActiveForm { get; set; }
        static Panel ActivePanel { get; set; }
        public MainForm()
        {
            InitializeComponent();
            ActivePanel = panel2;
            ActiveForm = null;
            this.MouseWheel += new MouseEventHandler(this.MainForm_MouseWheel);
            contextMenuStrip1.Renderer = new CustomContextMenuStripRenderer();
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
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDBLCLK = 0xA3;
            const int WM_NCRBUTTONDOWN = 0x00A4;

            switch (m.Msg)
            {
                case WM_NCLBUTTONDBLCLK: // 双击
                    FormUI.DarkThemeTitleBar(this.Handle);
                    return;
                case WM_NCRBUTTONDOWN: // 右键
                    ShowMyContextMenu();
                    return; // 可能需要移除，取决于是否需要默认行为
            }
            base.WndProc(ref m);
        }
        public void ShowMyContextMenu()
        {
            contextMenuStrip1.Show(Cursor.Position); // 显示在鼠标位置
        }
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
        private static void LoadForm() 
        {
            ActivePanel.Controls.Clear();
            ActiveForm.TopLevel = false;
            ActiveForm.FormBorderStyle = FormBorderStyle.None;
            ActiveForm.Dock = DockStyle.Fill;
            ActivePanel.Controls.Add(ActiveForm);
            ActiveForm.Show();
            GC.Collect();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            ActiveForm = form1;
            LoadForm();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            ActiveForm = form;
            LoadForm();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            ActiveForm = form;
            LoadForm();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            var form = new Form4();
            ActiveForm = form;
            LoadForm();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            var form = new Form5();
            ActiveForm = form;
            LoadForm();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            var form = new Form6();
            ActiveForm = form;
            LoadForm();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            var form = new Form7();
            ActiveForm = form;
            LoadForm();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            var form = new Form8();
            ActiveForm = form;
            LoadForm();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            var form = new Form9();
            ActiveForm = form;
            LoadForm();
        }

        private void 主题切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null) 
                ActiveForm.ForeColor = FormUI.Theme ? Color.Black : Color.White;
            FormUI.DarkThemeTitleBar(this.Handle);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormUI.UI_全局透明(this.Handle);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormUI.UI_标题栏纯色(this.Handle);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FormUI.UI_标题栏原生(this.Handle);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Program.Qsj = WinApi.FindWindow(null,"枪神纪");
            this.Text = "游戏窗口句柄：" + Program.Qsj.ToString();
        }
    }
}

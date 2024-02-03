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
    }
}

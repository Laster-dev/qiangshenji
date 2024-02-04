using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 枪神纪
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            FormUI.DarkThemeTitleBar(this.Handle);
            FormUI.UI_全局透明(this.Handle);
            FormUI.InvalidateRect(this.Handle, IntPtr.Zero, true);
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;
            this.BackgroundImageLayout = ImageLayout.Center;
        }
    }
}

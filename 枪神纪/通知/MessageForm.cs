using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 枪神纪.通知
{
    public partial class MessageForm : MyForm
    {
        public MessageForm(string str,int time)
        {
            InitializeComponent();
            this.TopMost = true;
            label1.Text = str;
            timer1.Interval = time; 
            timer1.Enabled = true;
            WinApi.RECT rect;
            WinApi.GetWindowRect(Program.Qsj,out rect);
            this.Location = new Point((rect.Left+this.Width)/2,(rect.Top+this.Height)/2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

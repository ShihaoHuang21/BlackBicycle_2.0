using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 自行车租赁系统
{
    public partial class 游客 : Form
    {
        public 游客()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            会员注册 form = new 会员注册();
            form.Show();
            this.Hide();
         
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            label1.Visible = false;
            pictureBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     

     
    }
}

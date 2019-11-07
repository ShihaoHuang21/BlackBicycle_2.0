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
    public partial class 打分 : Form
    {
        public 打分()
        {
            InitializeComponent();
        }
       
        private void button8_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox2.Text)<5)
            {
                MessageBox.Show("打分失败，我们不接受任何批评！");
            }
            else
            {
              richTextBox1.Text = "  感谢您的支持  ";
            }
            comboBox2.Visible = false;
          
            button8.Visible = false;
          
            
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否关闭本窗体？（点击‘否’跳转到登录界面！）","提示",MessageBoxButtons .YesNo,MessageBoxIcon.Question );
            if (result == DialogResult.Yes)
            {

            }
            else
            {
                Login form = new Login();
                form.Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
    }
}

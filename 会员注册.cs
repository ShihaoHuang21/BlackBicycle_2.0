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
    public partial class 会员注册 : Form
    {
        public 会员注册()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//提交 会员注册
        {
            string id = txt_name.Text.Trim();
            string pwd = txt_password.Text.Trim();
            string name = txt_xingzi.Text.Trim();
            string phone = txt_phone.Text.Trim();
            string s = string.Format("insert into 会员表(账号,密码,姓名,电话) values('{0}','{1}','{2}','{3}')", id, pwd, name, phone);
            if (id == "" || pwd == "" || name == "" || phone == "")
            {
                MessageBox.Show("有选项为空，请填写完整注册信息");
            }
            else
            {
                if (SqlHelper.ExecuteNonQuery(s) > 0)
                {
                    MessageBox.Show("注册成功");
                    this.Close();
                    Login form = new Login();
                    form.Show();
                } this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
          
            游客 form = new 游客();
            form.Show();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.txt_name.Text = "";
            this.txt_password.Text = "";
            this.txt_xingzi.Text = "";
            this.txt_phone.Text = "";
        }
          
    }
}

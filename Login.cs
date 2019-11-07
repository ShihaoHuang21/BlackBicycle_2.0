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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            rb_huiyuan.Checked = true;
            txt_Nmae.Focus();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public static string userId;
        private void button1_Click(object sender, EventArgs e)//登录
        {
            string id = txt_Nmae.Text.Trim();
            string pwd = txt_Password.Text.Trim();
            if (id==""||pwd=="")
            {
                MessageBox.Show("用户名或密码不能为空");
            }
            else
            {
                if (rb_huiyuan.Checked == true)//会员登录
                {
                    string s = string.Format("select * from 会员表 where 账号='{0}' and 密码='{1}'", id, pwd);
                    DataTable dt = SqlHelper.ExecuteDataTable(s);
                    if (dt.Rows.Count > 0)
                    {
                        //MessageBox.Show("登录成功");
                        userId = id;
                        会员 form = new 会员();
                        form.Show();
                        txt_Nmae.Text = "";
                        txt_Password.Text = ""; this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码有误");
                    }
                }
                else if (rb_guanliyuan.Checked == true)//管理员登录
                {
                    string s = string.Format("select * from 管理员表 where 登录账号='{0}' and 登录密码='{1}'", id, pwd);
                    DataTable dt = SqlHelper.ExecuteDataTable(s);
                    if (dt.Rows.Count > 0)
                    {
                        //MessageBox.Show("登录成功");
                        userId = id;
                        管理员 form = new 管理员();
                        form.Show();
                        txt_Nmae.Text = "";
                        txt_Password.Text = ""; this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码有误");
                    }
                }
                else if (rb_chaojiguanliyuan.Checked==true)
                {
                    string s = string.Format("select * from 超级管理员表 where 登录账号='{0}' and 登录密码='{1}'", id, pwd);
                    DataTable dt = SqlHelper.ExecuteDataTable(s);
                    if (dt.Rows.Count > 0)
                    {
                        //MessageBox.Show("登录成功");
                        userId = id;
                        超级管理员 form = new 超级管理员();
                        form.Show();
                        txt_Nmae.Text = "";
                        txt_Password.Text = ""; this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码有误");
                    }
                   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//会员注册
        {
            txt_Nmae.Clear();
            txt_Password.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();

        }
    }
}

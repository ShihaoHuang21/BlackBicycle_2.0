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
    public partial class 超级管理员 : Form
    {
        public 超级管理员()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//
            dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 管理员表");
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            panel1.Visible = false;
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            string s = string.Format(@"select * from 租车登记表 where DateDiff(dd,租出时间,getdate())=0");
            DataTable d = SqlHelper.ExecuteDataTable("select * from 租车登记表");
            int sum=0;
            for (int i = 0; i < d.Rows.Count; i++)
            {
                int n = int.Parse(d.Rows[i]["押金"].ToString());
                sum += n;
            }
            yaJin = sum;
        }
        public static string oldId;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex==0)
            {
                textBox1.Text = dataGridView1.Rows[rowIndex].Cells["登录账号"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[rowIndex].Cells["登录密码"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[rowIndex].Cells["姓名"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[rowIndex].Cells["电话"].Value.ToString();
                oldId = dataGridView1.Rows[rowIndex].Cells["登录账号"].Value.ToString().Trim();
                panel1.Visible = true;
            }
            if (e.ColumnIndex==1)
            {
                string s = string.Format("delete from 管理员表 where 登录账号='{0}'",dataGridView1.Rows[rowIndex].Cells["登录账号"].Value.ToString().Trim());
                if (SqlHelper.ExecuteNonQuery(s)>0)
                {
                    MessageBox.Show("删除管理员成功");
                    dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 管理员表");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//确定编辑
        {
            string s = string.Format(@"update 管理员表 set 登录账号='{0}',登录密码='{1}',
姓名='{2}',电话='{3}' where 登录账号='{4}'", textBox1.Text.Trim(), textBox2.Text.Trim(), 
    textBox3.Text.Trim(), textBox4.Text.Trim(),oldId);
            if (SqlHelper.ExecuteNonQuery(s)>0)
            {
                MessageBox.Show("编辑成功");
                dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 管理员表");
                panel1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)//取消编辑
        {
            panel1.Visible = false;
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            tabPage1.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage1;
            dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 管理员表 ");
        }

        private void button4_Click(object sender, EventArgs e)//查看收入页面
        {
            label7.Visible = false;
            label8.Visible = false;
            label10.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            tabPage2.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage2;
        }

        private void button7_Click(object sender, EventArgs e)//新增管理员
        {
            string managerId = textBox5.Text.Trim();
            string managerPwd = textBox6.Text.Trim();
            string managerName = textBox7.Text.Trim();
            string managerPhone = textBox8.Text.Trim();
            string s = string.Format("insert into 管理员表 values('{0}','{1}','{2}','{3}')",managerId,managerPwd,managerName,managerPhone);
            if (SqlHelper.ExecuteNonQuery(s)>0)
            {
                MessageBox.Show("新增管理员成功");
                dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 管理员表 ");
            }
        }
        public static int yaJin;
        private void button5_Click(object sender, EventArgs e)//查看未完成
        {
            label7.Visible = true;
            label8.Visible = true;
            label10.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label6.Text = "未完成的订单：";
            string s = string.Format(@"select * from 租车登记表 where DateDiff(dd,租出时间,getdate())=0");
            dataGridView2.DataSource = SqlHelper.ExecuteDataTable(s);
            int sum=0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
			{
			    int n=int.Parse(dataGridView2.Rows[i].Cells["押金"].Value.ToString().Trim());
                sum+=n;
			}
            label8.Text = sum.ToString();//当天押金总收入
        }

        private void button6_Click(object sender, EventArgs e)//查看当天已完成
        {
           
            label6.Text = "已完成的订单：";
            string s = string.Format(@"select * from 已完成订单表 where DateDiff(dd,租出时间,getdate())=0");
            dataGridView2.DataSource = SqlHelper.ExecuteDataTable(s);
            int sum = 0;
            int sum1=0;//已完成订单表里 租价的总数
            int sum2 = 0;////已完成订单表里 应退押金的总数
            int sum3 = 0;
            int sum4 = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                int n = int.Parse(dataGridView2.Rows[i].Cells["押金"].Value.ToString().Trim());
                int n1 = int.Parse(dataGridView2.Rows[i].Cells["租价"].Value.ToString().Trim());
                int n2 = int.Parse(dataGridView2.Rows[i].Cells["押金"].Value.ToString().Trim());
                sum += n;
                sum1 += n1;
                sum2 += n2;
            }
             sum3 = sum1 - sum2;
            sum4 = sum3 + sum;
            label8.Text = sum.ToString();//当天押金总收入
            label10.Text = sum3.ToString();//总租价减去总押金
            label12.Text = sum4.ToString();
            label7.Visible = true;
            label8.Visible = true;
            label10.Visible = true;
            label9.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

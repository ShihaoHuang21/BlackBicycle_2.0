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
    public partial class 会员 : Form
    {
        public 会员()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text ="会员 "+ Login.userId+",欢迎您";
            timer1.Enabled = true;
            panel1.Visible = false;//这个面板里放着 几个控件，用来提交修改个人信息
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView4.DataSource = false;
        }

        private void 会员_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)//打开 修改个人信息 页面
        {
            tabPage1.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage1;
            string s = string.Format("select * from 会员表 where 账号='{0}'",Login.userId.Trim());
            dataGridView1.DataSource = SqlHelper.ExecuteDataTable(s);
        }

        private void button2_Click(object sender, EventArgs e)//查看可租自行车信息
        {
            tabPage2.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage2;
            string s = string.Format("select * from 自行车表 where 状态='{0}'", "空闲");
            dataGridView2.DataSource = SqlHelper.ExecuteDataTable(s);
        }

        private void button3_Click(object sender, EventArgs e)//打开 个人租车记录 页面
        {
            tabPage3.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage3;
            string s1 = string.Format("select * from 租车登记表 where 租借人账号='{0}' ",Login.userId.Trim());
            string s2 = string.Format("select * from 已完成订单表 where 租借人账号='{0}' ", Login.userId.Trim());
            dataGridView3.DataSource = SqlHelper.ExecuteDataTable(s1);
            dataGridView4.DataSource = SqlHelper.ExecuteDataTable(s2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex==0)//点击选中了【编辑】
            {
                panel1.Visible = true;
                textBox1.Text = dataGridView1.Rows[rowIndex].Cells["账号"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[rowIndex].Cells["密码"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[rowIndex].Cells["姓名"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[rowIndex].Cells["电话"].Value.ToString();
                oldUserId = dataGridView1.Rows[rowIndex].Cells["账号"].Value.ToString();
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        private void button5_Click(object sender, EventArgs e)// 取消 修改个人信息
        {
            panel1.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public static string oldUserId;
        private void button4_Click(object sender, EventArgs e)//提交 修改个人信息
        {
            string id = textBox1.Text.Trim();
            string pwd = textBox2.Text.Trim();
            string name = textBox3.Text.Trim();
            string phone = textBox4.Text.Trim();
            //个人信息修改后，得更新 会员表、租车登记表、已完成订单表 里的该会员信息
            string s1 = string.Format(@"update 会员表 set 账号='{0}',密码='{1}',姓名='{2}',电话='{3}'
where 账号='{4}'", id, pwd, name, phone, oldUserId);
            string s2 = string.Format(@"update 租车登记表 set 租借人账号='{0}',租借人姓名='{1}',租借人电话='{2}'
where 租借人账号='{3}'", id, pwd, name, oldUserId);
            string s3 = string.Format(@"update 已完成订单表 set 租借人账号='{0}',租借人姓名='{1}',租借人电话='{2}'
where 租借人账号='{3}'", id, pwd, name, oldUserId);

            int r1 = SqlHelper.ExecuteNonQuery(s1);
            int r2 = SqlHelper.ExecuteNonQuery(s2);
            int r3 = SqlHelper.ExecuteNonQuery(s3);
            if (r1>0&&r2>=0&&r3>=0)
            {
                MessageBox.Show("修改成功！");
                string sql = string.Format("select * from 会员表 where 账号='{0}'", Login.userId.Trim());
                dataGridView1.DataSource = SqlHelper.ExecuteDataTable(sql);
            }
        }
  
        private void button6_Click(object sender, EventArgs e)
        { 
            打分 form = new 打分();
            form.Show();
            this.Hide();
           
        } 

    }
}

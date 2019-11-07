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
    public partial class 管理员 : Form
    {
        public 管理员()
        {
            InitializeComponent();
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            tabPage4.Parent = null;
            tabPage5.Parent = null;
            comboBox1.Items.AddRange(new object[]{"空闲","已出租","维修"});
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectAll();
            comboBox2.Items.AddRange(new object[] { "空闲", "已出租", "维修" });
            comboBox2.SelectedIndex = 0;
            comboBox2.SelectAll();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView4.AllowUserToAddRows = false;
            dataGridView5.AllowUserToAddRows = false;
            dataGridView6.AllowUserToAddRows = false;
            dataGridView7.AllowUserToAddRows = false;
            dataGridView8.AllowUserToAddRows = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            panel1.Visible = false;//隐藏 编辑面板
            panel2.Visible = false;
            label1.Text = "管理员"+Login.userId+"，欢迎您";
        }

        private void button1_Click(object sender, EventArgs e)//打开 自行车管理 页面
        {
            tabPage1.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage1;
            dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 自行车表");
        }

        private void button2_Click(object sender, EventArgs e)//打开 会员管理 页面
        {
            tabPage2.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage2;
            dataGridView2.DataSource = SqlHelper.ExecuteDataTable("select * from 会员表");
        }

        private void button3_Click(object sender, EventArgs e)//打开 租车 页面
        {
            tabPage3.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage3;
            string s = string.Format("select * from 自行车表 where 状态='{0}'", "空闲");
            dataGridView3.DataSource = SqlHelper.ExecuteDataTable(s);
            dataGridView4.DataSource = null;
        }

        private void button4_Click(object sender, EventArgs e)//打开 还车 页面
        {
            tabPage4.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage4;
            string s = string.Format("select * from 租车登记表");
            dataGridView5.DataSource = SqlHelper.ExecuteDataTable(s);
        }

        private void button5_Click(object sender, EventArgs e)// 新增自行车
        {
            string id = textBox1.Text.Trim();//车牌
            string brand = textBox2.Text.Trim();//品牌
            string productType = textBox3.Text.Trim();//型号
            string price = textBox4.Text.Trim();//租价
            string status = comboBox1.SelectedItem.ToString().Trim();//状态
            string s = string.Format("insert into 自行车表 values('{0}','{1}','{2}','{3}','{4}')",id,brand,productType,price,status);
            //插入到数据库之前先判断是否已存在相同的车牌号
            string str = string.Format("select * from 自行车表 where 车牌='{0}'",id);
            DataTable dt = SqlHelper.ExecuteDataTable(str);
            if (dt.Rows.Count>0)
            {
                MessageBox.Show("已存在相同的车牌号，请输入别的");
            }
            else
            {
                if (SqlHelper.ExecuteNonQuery(s)>0)
                {
                    MessageBox.Show("新增自行车成功");
                    dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 自行车表");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//点击datagridview单元格
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex==0)//点击的单元格位于第一列，说明点的是 编辑
            {
                panel1.Visible = true;//显示 编辑面板               
                textBox5.Text = dataGridView1.Rows[rowIndex].Cells["车牌"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[rowIndex].Cells["品牌"].Value.ToString();
                textBox7.Text = dataGridView1.Rows[rowIndex].Cells["型号"].Value.ToString();
                textBox8.Text = dataGridView1.Rows[rowIndex].Cells["租价"].Value.ToString();
                comboBox2.SelectedItem = dataGridView1.Rows[rowIndex].Cells["状态"].Value.ToString();
                oldId = dataGridView1.Rows[rowIndex].Cells["车牌"].Value.ToString().Trim();
            }
            if (e.ColumnIndex==1)
            {
                string s = string.Format("delete from 自行车表 where 车牌='{0}'",dataGridView1.Rows[rowIndex].Cells["车牌"].Value.ToString().Trim());
                if (SqlHelper.ExecuteNonQuery(s)>0)
                {
                    MessageBox.Show("删除成功");
                    dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 自行车表");
                }
            }
        }
        public static string oldId;//原车牌
        private void button6_Click(object sender, EventArgs e)//更新 自行车信息
        {
            string id = textBox5.Text.Trim();//车牌
            string brand = textBox6.Text.Trim();//品牌
            string productType = textBox7.Text.Trim();//型号
            string price = textBox8.Text.Trim();//租价
            string status = comboBox2.SelectedItem.ToString().Trim();//状态
            string s = string.Format("update 自行车表 set 车牌='{0}',品牌='{1}',型号='{2}',租价='{3}',状态='{4}' where 车牌='{5}'",id,brand,productType,price,status,oldId);
            if (SqlHelper.ExecuteNonQuery(s)>0)
            {
                MessageBox.Show("编辑成功");
                dataGridView1.DataSource = SqlHelper.ExecuteDataTable("select * from 自行车表");
                panel1.Visible = false;
            }
            //if ()
            //{
                
            //}
        }

        private void button7_Click(object sender, EventArgs e)//取消 更新
        {

        }

        private void button8_Click(object sender, EventArgs e)// 新增会员
        {
            string id = textBox9.Text.Trim();
            string pwd = textBox10.Text.Trim();
            string name = textBox11.Text.Trim();
            string phone = textBox12.Text.Trim();
            string s = string.Format("insert into 会员表 values('{0}','{1}','{2}','{3}')",id,pwd,name,phone);
            if (id==""||pwd==""||name==""||phone=="")
            {
                MessageBox.Show("会员信息不能为空，请填写");
            }
            else
            {
                if (SqlHelper.ExecuteNonQuery(s) > 0)
                {
                    MessageBox.Show("新增会员成功");
                    dataGridView2.DataSource = SqlHelper.ExecuteDataTable("select * from 会员表");
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)//点击datagridview2单元格
        {
            int rowIndex = e.RowIndex;
            if (e.ColumnIndex==0)//"编辑"
            {
                panel2.Visible = true;
                oldId2 = dataGridView2.Rows[rowIndex].Cells["账号"].Value.ToString().Trim();
                textBox13.Text = dataGridView2.Rows[rowIndex].Cells["账号"].Value.ToString().Trim();
                textBox14.Text = dataGridView2.Rows[rowIndex].Cells["密码"].Value.ToString().Trim();
                textBox15.Text = dataGridView2.Rows[rowIndex].Cells["姓名"].Value.ToString().Trim();
                textBox16.Text = dataGridView2.Rows[rowIndex].Cells["电话"].Value.ToString().Trim();
                textBox13.Focus();
                textBox13.SelectAll();
            }
            if (e.ColumnIndex==1)
            {
                string s = string.Format("delete from 会员表 where 账号='{0}'",dataGridView2.Rows[rowIndex].Cells["账号"].Value.ToString().Trim());
                if (SqlHelper.ExecuteNonQuery(s)>0)
                {
                    MessageBox.Show("删除会员"+dataGridView2.Rows[rowIndex].Cells["账号"].Value.ToString()+"成功");
                    dataGridView2.DataSource = SqlHelper.ExecuteDataTable("select * from 会员表");
                }
            }
        }
        public static string oldId2;//原 会员账号
        private void button9_Click(object sender, EventArgs e)//编辑会员信息
        {
             string id = textBox13.Text.Trim();
             string pwd = textBox14.Text.Trim();
             string name = textBox15.Text.Trim();
             string phone = textBox16.Text.Trim();
             string s = string.Format("update 会员表 set 账号='{0}',密码='{1}',姓名='{2}',电话='{3}' where 账号='{4}'",id,pwd,name,phone,oldId2);
             if (SqlHelper.ExecuteNonQuery(s)>0)
             {
                 MessageBox.Show("编辑会员成功");
                 dataGridView2.DataSource = SqlHelper.ExecuteDataTable("select * from 会员表");
                 panel2.Visible = false;
             }
        }

        private void button10_Click(object sender, EventArgs e)//取消编辑
        {
            panel2.Visible = false;
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)//确定租车
        {
            string bikeId = textBox17.Text.Trim();//租借的车牌
            string userId = textBox18.Text.Trim();//租借人的会员账号
            if (bikeId==""||userId=="")
            {
                MessageBox.Show("自行车车牌或会员账号不能为空");
            }
            else
            {
                string s1 = string.Format("select * from 自行车表 where 车牌='{0}'",bikeId);
                DataTable dt1 = SqlHelper.ExecuteDataTable(s1);//要租借的自行车的信息
                string s2 = string.Format("select * from 会员表 where 账号='{0}'", userId);
                DataTable dt2 = SqlHelper.ExecuteDataTable(s2);//租借人 的 会员信息
                if (dt1.Rows.Count==0||dt2.Rows.Count==0)
                {
                    MessageBox.Show("不存在该自行车或会员");
                }
                else
                {
                   //先确定订单号，订单号格式：日期_时间_序号，每天的序号都是从1开始
                    string orderNum;//订单号
                    DataTable d = SqlHelper.ExecuteDataTable("select * from 租车登记表");
                    if (d.Rows.Count==0)//登记表里还没有任何订单记录
                    {
                        orderNum = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString() + "_" + 1.ToString();
                    }
                    else
                    {
                        string str = d.Rows[d.Rows.Count - 1]["订单号"].ToString();
                        string[] nums = str.Split(new char[] { '_' });
                        if (nums[0].Trim() == DateTime.Now.ToShortDateString().Trim())
                        {
                            //租车登记表里最后一个订单的日期等于当前日期,序号就紧接着排下去
                            int n = int.Parse(nums[nums.Length - 1].Trim());
                            orderNum = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString() + "_" + (n + 1).ToString();
                        }
                        else//租车登记表里最后一个订单的日期等于当前日期,序号就从1开始
                        {
                            orderNum = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString() + "_" + 1.ToString();
                        }
                    }
                    //在租车之前，先确定该车牌没有被出租
                    string sqlBike = string.Format("select * from 自行车表 where 车牌='{0}'",bikeId);
                    DataTable dtBike = SqlHelper.ExecuteDataTable(sqlBike);
                    if (dtBike.Rows[0]["状态"].ToString().Trim()!="空闲")
                    {
                        MessageBox.Show("该车已出租或正在维修，请选别的");
                    }
                    else
                    {
                        string brand = dt1.Rows[0]["品牌"].ToString().Trim();//品牌
                        string productType = dt1.Rows[0]["型号"].ToString().Trim();//型号
                        string price = dt1.Rows[0]["租价"].ToString().Trim();//租价
                        string userName = dt2.Rows[0]["姓名"].ToString().Trim();//租借人姓名
                        string userPhone = dt2.Rows[0]["电话"].ToString().Trim();//租借人电话
                        DateTime time = DateTime.Now;//租借时间
                        string manager = Login.userId.Trim();//经手管理员
                        string yajin = textBox20.Text.Trim();//押金
                        string sql1 = string.Format(@"insert into 租车登记表
(订单号,车牌,品牌,型号,租价,租借人账号,租借人姓名,租借人电话,租出时间,经手管理员,押金) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')"
    , orderNum, bikeId, brand, productType, price, userId, userName, userPhone, time, manager, yajin);

                        //往 租车登记表里录入 一条租车信息
                        int r1 = SqlHelper.ExecuteNonQuery(sql1);

                        //设置 自行车表 里该车牌的状态为 已出租
                        string sql2 = string.Format("update 自行车表 set 状态='{0}' where 车牌='{1}'", "已出租", bikeId);
                        int r2 = SqlHelper.ExecuteNonQuery(sql2);
                        if (r1 > 0 && r2 > 0)
                        {
                            MessageBox.Show("租车登记成功！");
                            string sql = string.Format("select * from 租车登记表 where 车牌='{0}'", textBox17.Text.Trim());
                            dataGridView4.DataSource = SqlHelper.ExecuteDataTable(sql);
                            textBox17.Text = "";
                            textBox18.Text = "";
                            string s = string.Format("select * from 自行车表 where 状态='{0}'", "空闲");
                            dataGridView3.DataSource = SqlHelper.ExecuteDataTable(s);
                        }
                    }
                    
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void button12_Click(object sender, EventArgs e)//确定还车
        {
            string bikeId = textBox19.Text.Trim();//车牌
            string sql = string.Format("select * from 租车登记表 where 车牌='{0}'", textBox19.Text.Trim());
            DataTable dt = SqlHelper.ExecuteDataTable(sql);
            //从 租车登记表里 移除该条租车记录，并往 已完成订单表  里录入该条租车记录,
            //并在 自行车表 里设置 该车的状态为空闲
            string s1 = string.Format("delete  from 租车登记表 where 车牌='{0}'", bikeId);
            int r1 = SqlHelper.ExecuteNonQuery(s1);

            string orderId=dt.Rows[0]["订单号"].ToString();
            string brand = dt.Rows[0]["品牌"].ToString();
            string productType = dt.Rows[0]["型号"].ToString();
            string price = dt.Rows[0]["租价"].ToString();
            string userId = dt.Rows[0]["租借人账号"].ToString();
            string userName = dt.Rows[0]["租借人姓名"].ToString();
            string userPhone = dt.Rows[0]["租借人电话"].ToString();
            string yajin = dt.Rows[0]["押金"].ToString().Trim();
            DateTime time1;
            DateTime.TryParse(dt.Rows[0]["租出时间"].ToString(),out time1);
            DateTime time2 = DateTime.Now;//归还时间
            int days=time2.Subtract(time1).Days;//共租借的天数
            
            string moneyIn = (int.Parse(price)*(1+days)).ToString();//应 收款额
            string manager = dt.Rows[0]["经手管理员"].ToString();
            string s2 = string.Format(@"insert into 已完成订单表(订单号,车牌,品牌,型号,租价,租借人账号,
租借人姓名,租借人电话,租出时间,归还时间,共借天数,应收款额,经手管理员,押金) values('{0}','{1}','{2}','{3}','{4}','{5}',
'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')",orderId,bikeId,brand,productType,price,userId,userName,
                                       userPhone,time1,time2,days+1,moneyIn,manager,yajin);
            int r2 = SqlHelper.ExecuteNonQuery(s2);
            string s3 = string.Format("update 自行车表 set 状态='{0}' where 车牌='{1}'","空闲",bikeId);
            int r3 = SqlHelper.ExecuteNonQuery(s3);
            if (r1>0&&r2>0&&r3>0)
            {
                MessageBox.Show("还车成功");
                string s = string.Format("select * from 租车登记表");
                dataGridView5.DataSource = SqlHelper.ExecuteDataTable(s);
                dataGridView6.DataSource = null;
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text != "")
            {
                string s = string.Format("select * from 租车登记表 where 车牌='{0}'", textBox19.Text.Trim());
                dataGridView6.DataSource = SqlHelper.ExecuteDataTable(s);
                if (dataGridView6.Rows.Count == 0)
                {
                    MessageBox.Show("没有这款租车信息，请重新输入");
                }
                else
                {
                    string sql = string.Format("select * from 租车登记表 where 车牌='{0}'", textBox19.Text.Trim());
                    DataTable dt = SqlHelper.ExecuteDataTable(sql);
                    DateTime time1;
                    DateTime.TryParse(dt.Rows[0]["租出时间"].ToString(), out time1);
                    DateTime time2 = DateTime.Now;//归还时间
                    int days = time2.Subtract(time1).Days;//共租借的天数
                    string price = dt.Rows[0]["租价"].ToString().Trim();
                    string yajin = dt.Rows[0]["押金"].ToString().Trim();
                    string zujin = (int.Parse(price) * (days + 1)).ToString();//应收租金
                    label38.Text = zujin;
                    string moneyIn = "";//应收款额
                    if (yajin == "")
                    {
                        moneyIn = zujin;
                    }
                    else
                    {
                        moneyIn = (int.Parse(zujin) - int.Parse(yajin)).ToString();
                    }

                    label22.Text = (days + 1).ToString();
                    label27.Text = yajin;
                    label24.Text = moneyIn;
                    if (dataGridView6.Rows.Count == 0)
                    {
                        MessageBox.Show("没有该车的租出信息，请核实");
                    }
                }
            }
           
        }

        private void button13_Click(object sender, EventArgs e)//该管理员经手费用 页面
        {
            tabPage5.Parent = tabControl1;
            tabControl1.SelectedTab = tabPage5;
            string s1 = string.Format(@"select * from 租车登记表 where 经手管理员='{0}' and  DateDiff
(dd,租出时间,getdate())=0  ", Login.userId);
            string s2 = string.Format(@"select * from 已完成订单表 where 经手管理员='{0}' and  DateDiff
(dd,租出时间,getdate())=0  ", Login.userId);
            dataGridView7.DataSource = SqlHelper.ExecuteDataTable(s1);
            dataGridView8.DataSource = SqlHelper.ExecuteDataTable(s2);
            int sum1 = 0;//租车登记表里的租金总数
            int sum2 = 0;//已完成订单表里的应收款额总数
            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                int n = int.Parse(dataGridView7.Rows[i].Cells["押金"].Value.ToString());
                sum1 += n;
            }
            for (int i = 0; i < dataGridView8.Rows.Count; i++)
            {
                int m = int.Parse(dataGridView8.Rows[i].Cells["应收款额"].Value.ToString());
                sum2 += m;

            }
            label32.Text = sum1.ToString();
            label34.Text = sum2.ToString();
            label36.Text = (sum1 + sum2).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}

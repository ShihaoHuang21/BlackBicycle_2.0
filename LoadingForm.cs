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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            for (int i = 0; i < 3000; i++)
            {
                progressBar1.PerformStep();
                label1.Text = "进度值：" + progressBar1.Value.ToString();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            new 游客().Show();
            this.Hide();
            this.timer1.Enabled = false;
        }



    }
}

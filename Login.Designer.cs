namespace 自行车租赁系统
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Nmae = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cencel = new System.Windows.Forms.Button();
            this.rb_huiyuan = new System.Windows.Forms.RadioButton();
            this.rb_guanliyuan = new System.Windows.Forms.RadioButton();
            this.rb_chaojiguanliyuan = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(191, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "账号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(191, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码：";
            // 
            // txt_Nmae
            // 
            this.txt_Nmae.Location = new System.Drawing.Point(290, 81);
            this.txt_Nmae.Multiline = true;
            this.txt_Nmae.Name = "txt_Nmae";
            this.txt_Nmae.Size = new System.Drawing.Size(209, 24);
            this.txt_Nmae.TabIndex = 3;
            this.txt_Nmae.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txt_Password
            // 
            this.txt_Password.Location = new System.Drawing.Point(290, 136);
            this.txt_Password.Multiline = true;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(209, 24);
            this.txt_Password.TabIndex = 4;
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(214, 271);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(87, 33);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "登录";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cencel
            // 
            this.btn_cencel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cencel.Location = new System.Drawing.Point(390, 271);
            this.btn_cencel.Name = "btn_cencel";
            this.btn_cencel.Size = new System.Drawing.Size(87, 33);
            this.btn_cencel.TabIndex = 6;
            this.btn_cencel.Text = "重填";
            this.btn_cencel.UseVisualStyleBackColor = true;
            this.btn_cencel.Click += new System.EventHandler(this.button2_Click);
            // 
            // rb_huiyuan
            // 
            this.rb_huiyuan.BackColor = System.Drawing.Color.Transparent;
            this.rb_huiyuan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_huiyuan.ForeColor = System.Drawing.Color.Black;
            this.rb_huiyuan.Location = new System.Drawing.Point(202, 197);
            this.rb_huiyuan.Name = "rb_huiyuan";
            this.rb_huiyuan.Size = new System.Drawing.Size(60, 28);
            this.rb_huiyuan.TabIndex = 7;
            this.rb_huiyuan.TabStop = true;
            this.rb_huiyuan.Text = "会员";
            this.rb_huiyuan.UseVisualStyleBackColor = false;
            // 
            // rb_guanliyuan
            // 
            this.rb_guanliyuan.BackColor = System.Drawing.Color.Transparent;
            this.rb_guanliyuan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_guanliyuan.ForeColor = System.Drawing.Color.Black;
            this.rb_guanliyuan.Location = new System.Drawing.Point(290, 197);
            this.rb_guanliyuan.Name = "rb_guanliyuan";
            this.rb_guanliyuan.Size = new System.Drawing.Size(84, 28);
            this.rb_guanliyuan.TabIndex = 8;
            this.rb_guanliyuan.TabStop = true;
            this.rb_guanliyuan.Text = "管理员";
            this.rb_guanliyuan.UseVisualStyleBackColor = false;
            // 
            // rb_chaojiguanliyuan
            // 
            this.rb_chaojiguanliyuan.BackColor = System.Drawing.Color.Transparent;
            this.rb_chaojiguanliyuan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rb_chaojiguanliyuan.ForeColor = System.Drawing.Color.Black;
            this.rb_chaojiguanliyuan.Location = new System.Drawing.Point(402, 197);
            this.rb_chaojiguanliyuan.Name = "rb_chaojiguanliyuan";
            this.rb_chaojiguanliyuan.Size = new System.Drawing.Size(109, 28);
            this.rb_chaojiguanliyuan.TabIndex = 9;
            this.rb_chaojiguanliyuan.TabStop = true;
            this.rb_chaojiguanliyuan.Text = "超级管理员";
            this.rb_chaojiguanliyuan.UseVisualStyleBackColor = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.Maroon;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.linkLabel1.Location = new System.Drawing.Point(635, 395);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(76, 16);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "退出系统";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::自行车租赁系统.Properties.Resources.weq;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(733, 420);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.rb_chaojiguanliyuan);
            this.Controls.Add(this.rb_guanliyuan);
            this.Controls.Add(this.rb_huiyuan);
            this.Controls.Add(this.btn_cencel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_Password);
            this.Controls.Add(this.txt_Nmae);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Nmae;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cencel;
        private System.Windows.Forms.RadioButton rb_huiyuan;
        private System.Windows.Forms.RadioButton rb_guanliyuan;
        private System.Windows.Forms.RadioButton rb_chaojiguanliyuan;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}


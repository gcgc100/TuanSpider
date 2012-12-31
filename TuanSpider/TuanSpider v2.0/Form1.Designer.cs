namespace TuanSpider_v2._0
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mainstatus = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nametextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.urltextbox = new System.Windows.Forms.TextBox();
            this.dnuomiCheck = new System.Windows.Forms.CheckBox();
            this.dlashouCheck = new System.Windows.Forms.CheckBox();
            this.dmeituanCheck = new System.Windows.Forms.CheckBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.indexstatusLabel = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.inuomiCheck = new System.Windows.Forms.CheckBox();
            this.ilashouCheck = new System.Windows.Forms.CheckBox();
            this.imeituanCheck = new System.Windows.Forms.CheckBox();
            this.button8 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.databaseText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.passwdText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(278, 237);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mainstatus);
            this.tabPage1.Controls.Add(this.progressBar2);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(270, 211);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主窗口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mainstatus
            // 
            this.mainstatus.AutoSize = true;
            this.mainstatus.Location = new System.Drawing.Point(6, 196);
            this.mainstatus.Name = "mainstatus";
            this.mainstatus.Size = new System.Drawing.Size(0, 12);
            this.mainstatus.TabIndex = 6;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(6, 170);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(250, 23);
            this.progressBar2.TabIndex = 5;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 114);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 50);
            this.button6.TabIndex = 3;
            this.button6.Text = "构建索引";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(136, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 50);
            this.button5.TabIndex = 1;
            this.button5.Text = "下载XML";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(136, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 50);
            this.button4.TabIndex = 4;
            this.button4.Text = "设置";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 50);
            this.button3.TabIndex = 0;
            this.button3.Text = "一键完成";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dnuomiCheck);
            this.tabPage2.Controls.Add(this.dlashouCheck);
            this.tabPage2.Controls.Add(this.dmeituanCheck);
            this.tabPage2.Controls.Add(this.statusLabel);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(270, 211);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "下载xml文件";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(202, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "自定义";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nametextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.urltextbox);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(22, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 80);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自定义下载";
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(44, 51);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(180, 21);
            this.nametextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "名称:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "url:";
            // 
            // urltextbox
            // 
            this.urltextbox.Location = new System.Drawing.Point(44, 20);
            this.urltextbox.Name = "urltextbox";
            this.urltextbox.Size = new System.Drawing.Size(180, 21);
            this.urltextbox.TabIndex = 8;
            // 
            // dnuomiCheck
            // 
            this.dnuomiCheck.AutoSize = true;
            this.dnuomiCheck.Location = new System.Drawing.Point(142, 61);
            this.dnuomiCheck.Name = "dnuomiCheck";
            this.dnuomiCheck.Size = new System.Drawing.Size(60, 16);
            this.dnuomiCheck.TabIndex = 6;
            this.dnuomiCheck.Text = "糯米网";
            this.dnuomiCheck.UseVisualStyleBackColor = true;
            // 
            // dlashouCheck
            // 
            this.dlashouCheck.AutoSize = true;
            this.dlashouCheck.Location = new System.Drawing.Point(82, 61);
            this.dlashouCheck.Name = "dlashouCheck";
            this.dlashouCheck.Size = new System.Drawing.Size(60, 16);
            this.dlashouCheck.TabIndex = 5;
            this.dlashouCheck.Text = "拉手网";
            this.dlashouCheck.UseVisualStyleBackColor = true;
            // 
            // dmeituanCheck
            // 
            this.dmeituanCheck.AutoSize = true;
            this.dmeituanCheck.Location = new System.Drawing.Point(22, 61);
            this.dmeituanCheck.Name = "dmeituanCheck";
            this.dmeituanCheck.Size = new System.Drawing.Size(60, 16);
            this.dmeituanCheck.TabIndex = 4;
            this.dmeituanCheck.Text = "美团网";
            this.dmeituanCheck.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(41, 26);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 12);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "无任务";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.progressBar1);
            this.tabPage3.Controls.Add(this.indexstatusLabel);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.inuomiCheck);
            this.tabPage3.Controls.Add(this.ilashouCheck);
            this.tabPage3.Controls.Add(this.imeituanCheck);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(270, 211);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "构建索引";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 14);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(264, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // indexstatusLabel
            // 
            this.indexstatusLabel.AutoSize = true;
            this.indexstatusLabel.Location = new System.Drawing.Point(30, 55);
            this.indexstatusLabel.Name = "indexstatusLabel";
            this.indexstatusLabel.Size = new System.Drawing.Size(53, 12);
            this.indexstatusLabel.TabIndex = 6;
            this.indexstatusLabel.Text = "已索引：";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(153, 146);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 5;
            this.button9.Text = "取消";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // inuomiCheck
            // 
            this.inuomiCheck.AutoSize = true;
            this.inuomiCheck.Location = new System.Drawing.Point(196, 85);
            this.inuomiCheck.Name = "inuomiCheck";
            this.inuomiCheck.Size = new System.Drawing.Size(60, 16);
            this.inuomiCheck.TabIndex = 4;
            this.inuomiCheck.Text = "糯米网";
            this.inuomiCheck.UseVisualStyleBackColor = true;
            // 
            // ilashouCheck
            // 
            this.ilashouCheck.AutoSize = true;
            this.ilashouCheck.Location = new System.Drawing.Point(107, 84);
            this.ilashouCheck.Name = "ilashouCheck";
            this.ilashouCheck.Size = new System.Drawing.Size(60, 16);
            this.ilashouCheck.TabIndex = 3;
            this.ilashouCheck.Text = "拉手网";
            this.ilashouCheck.UseVisualStyleBackColor = true;
            // 
            // imeituanCheck
            // 
            this.imeituanCheck.AutoSize = true;
            this.imeituanCheck.Location = new System.Drawing.Point(23, 85);
            this.imeituanCheck.Name = "imeituanCheck";
            this.imeituanCheck.Size = new System.Drawing.Size(60, 16);
            this.imeituanCheck.TabIndex = 2;
            this.imeituanCheck.Text = "美团网";
            this.imeituanCheck.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(43, 146);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 1;
            this.button8.Text = "开始";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(270, 211);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "设置";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(88, 139);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "保存";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.databaseText);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.passwdText);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.userText);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 114);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库";
            // 
            // databaseText
            // 
            this.databaseText.Location = new System.Drawing.Point(82, 79);
            this.databaseText.Name = "databaseText";
            this.databaseText.Size = new System.Drawing.Size(160, 21);
            this.databaseText.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "数据库名";
            // 
            // passwdText
            // 
            this.passwdText.Location = new System.Drawing.Point(82, 49);
            this.passwdText.Name = "passwdText";
            this.passwdText.Size = new System.Drawing.Size(160, 21);
            this.passwdText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // userText
            // 
            this.userText.Location = new System.Drawing.Point(82, 19);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(160, 21);
            this.userText.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "密码";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 262);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "TuanSpider v2.0";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox nametextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox urltextbox;
        private System.Windows.Forms.CheckBox dnuomiCheck;
        private System.Windows.Forms.CheckBox dlashouCheck;
        private System.Windows.Forms.CheckBox dmeituanCheck;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox passwdText;
        private System.Windows.Forms.TextBox userText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox databaseText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox imeituanCheck;
        private System.Windows.Forms.CheckBox inuomiCheck;
        private System.Windows.Forms.CheckBox ilashouCheck;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label indexstatusLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label mainstatus;
    }
}


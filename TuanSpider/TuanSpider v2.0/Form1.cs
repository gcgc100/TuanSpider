using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using System.Configuration;
using System.Globalization;
using System.Collections.Specialized;

using MoveToDatabase;

namespace TuanSpider_v2._0
{
    public partial class Form1 : Form
    {
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        string fileurl, tarfile;
        string filepath;
        int type;
        int count;

        //string user, passwd, database, host;
        CustomSection customSection;
        System.Configuration.Configuration config;

        public Form1()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker3 = new System.ComponentModel.BackgroundWorker();

            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;

            InitializeComponent();
            backgroundWorker1.DoWork +=
                new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker1_ProgressChanged);

            backgroundWorker2.DoWork +=
                new DoWorkEventHandler(backgroundWorker2_DoWork);
            backgroundWorker2.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker2_RunWorkerCompleted);
            backgroundWorker2.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker2_ProgressChanged);
            customSection = new CustomSection();
            try
            {
                // Get the current configuration file.
                config = ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                // Create the custom section entry  
                // in <configSections> group and the 
                // related target section in <configuration>.
                if (config.Sections["CustomSection"] == null)
                {
                    config.Sections.Add("CustomSection", customSection);

                    // Save the configuration file.
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
                customSection =
                     config.GetSection("CustomSection") as CustomSection;

                userText.Text = customSection.User;
                passwdText.Text = customSection.Passwd;
                databaseText.Text = customSection.Database;
            }
            catch (ConfigurationErrorsException err)
            {
                MessageBox.Show("CreateConfigurationFile: {0}", err.ToString());
            }
        }
        private void backgroundWorker1_DoWork(object sender,
            DoWorkEventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileurl);
            StreamWriter sw = new StreamWriter(tarfile);
            sw.Write(document.InnerXml);
            sw.Flush();
            sw.Close();
        }
        private void backgroundWorker1_RunWorkerCompleted(Object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.dmeituanCheck.Enabled = true;
            this.dlashouCheck.Enabled = true;
            this.dnuomiCheck.Enabled = true;
            this.checkBox1.Enabled = true;
            this.button1.Enabled = true;
            statusLabel.Text = "无任务";
        }
        private void backgroundWorker1_ProgressChanged(Object sender,
            ProgressChangedEventArgs e)
        {
        }


        private void backgroundWorker2_DoWork(object sender,
           DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            int pos = 0;
            LoadIntoDatabase down = new LoadIntoDatabase(filepath, customSection.Host, customSection.Database, customSection.User,
                customSection.Passwd, type);
            count = down.getcount();
            while (pos < count && worker.CancellationPending != true)
            {
                down.addLink(pos, pos);
                pos++;
                worker.ReportProgress(pos);
            }
        }
        private void backgroundWorker2_RunWorkerCompleted(Object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.imeituanCheck.Enabled = true;
            this.ilashouCheck.Enabled = true;
            this.inuomiCheck.Enabled = true;
            this.button8.Enabled = true;

            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                indexstatusLabel.Text += "\tCanceled.";
            }
            //else
            //    indexstatusLabel.Text = e.Result.ToString();
        }
        private void backgroundWorker2_ProgressChanged(Object sender,
            ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage * 100 / count;
            progressBar2.Value = e.ProgressPercentage * 100 / count;
            indexstatusLabel.Text = "已索引    " + e.ProgressPercentage + "    条。";
            mainstatus.Text = "已索引    " + e.ProgressPercentage + "    条。";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                if (!Directory.Exists("xml"))
                    Directory.CreateDirectory("xml");
                // Start the asynchronous operation.
                if (dmeituanCheck.Checked == true)
                {
                    this.dmeituanCheck.Enabled = false;
                    this.dlashouCheck.Enabled = false;
                    this.dnuomiCheck.Enabled = false;
                    this.checkBox1.Enabled = false;
                    this.button1.Enabled = false;
                    statusLabel.Text = "正在下载meitian.xml  ...";
                    fileurl = customSection.Meituanurl;
                    tarfile = customSection.Meituanpath;
                    backgroundWorker1.RunWorkerAsync();
                }
                if (dlashouCheck.Checked == true)
                {
                    this.dmeituanCheck.Enabled = false;
                    this.dlashouCheck.Enabled = false;
                    this.dnuomiCheck.Enabled = false;
                    this.checkBox1.Enabled = false;
                    this.button1.Enabled = false;
                    statusLabel.Text = "正在下载lashou.xml  ...";
                    fileurl = customSection.Lashouurl;
                    tarfile = customSection.Lashoupath;
                    backgroundWorker1.RunWorkerAsync();
                }
                if (dnuomiCheck.Checked == true)
                {
                    this.dmeituanCheck.Enabled = false;
                    this.dlashouCheck.Enabled = false;
                    this.dnuomiCheck.Enabled = false;
                    this.checkBox1.Enabled = false;
                    this.button1.Enabled = false;
                    statusLabel.Text = "正在下载nuomi.xml  ...";
                    fileurl = customSection.Nuomiurl;
                    tarfile = customSection.Nuomipath;
                    backgroundWorker1.RunWorkerAsync();
                }
                if (checkBox1.Checked == true)
                {
                    this.dmeituanCheck.Enabled = false;
                    this.dlashouCheck.Enabled = false;
                    this.dnuomiCheck.Enabled = false;
                    this.checkBox1.Enabled = false;
                    this.button1.Enabled = false;
                    statusLabel.Text = "正在下载自定义url  ...";
                    fileurl = urltextbox.Text;
                    tarfile = "xml/" + nametextBox.Text + ".xml";
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            customSection.User = userText.Text;
            customSection.Passwd = passwdText.Text;
            customSection.Database = databaseText.Text;
            customSection.SectionInformation.ForceSave = true;
            config.Save(ConfigurationSaveMode.Full);

            tabControl1.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedIndex = 3;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (backgroundWorker2.IsBusy != true)
            {
                // Start the asynchronous operation.
                if (imeituanCheck.Checked == true)
                {
                    this.imeituanCheck.Enabled = false;
                    this.ilashouCheck.Enabled = false;
                    this.inuomiCheck.Enabled = false;
                    this.button8.Enabled = false;
                    filepath = customSection.Meituanpath;
                    type = 1;
                    statusLabel.Text = "正在索引meituan.xml  ...";
                    backgroundWorker2.RunWorkerAsync();
                }
                if (ilashouCheck.Checked == true)
                {
                    this.imeituanCheck.Enabled = false;
                    this.ilashouCheck.Enabled = false;
                    this.inuomiCheck.Enabled = false;
                    this.button8.Enabled = false;
                    filepath = customSection.Lashoupath;
                    type = 2;
                    statusLabel.Text = "正在索引lashou.xml  ...";
                    backgroundWorker2.RunWorkerAsync();
                }
                if (inuomiCheck.Checked == true)
                {
                    this.imeituanCheck.Enabled = false;
                    this.ilashouCheck.Enabled = false;
                    this.inuomiCheck.Enabled = false;
                    this.button8.Enabled = false;
                    type = 3;
                    filepath = customSection.Nuomipath;
                    statusLabel.Text = "正在索引nuomi.xml  ...";
                    backgroundWorker2.RunWorkerAsync();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (backgroundWorker2.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker2.CancelAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                if (!Directory.Exists("xml"))
                    Directory.CreateDirectory("xml");
                // Start the asynchronous operation.
                    this.dmeituanCheck.Enabled = false;
                    this.dlashouCheck.Enabled = false;
                    this.dnuomiCheck.Enabled = false;
                    this.checkBox1.Enabled = false;
                    this.button1.Enabled = false;
                    statusLabel.Text = "正在下载meitian.xml  ...";
                    fileurl = customSection.Meituanurl;
                    tarfile = customSection.Meituanpath;
                    backgroundWorker1.RunWorkerAsync();

                    statusLabel.Text = "正在下载lashou.xml  ...";
                    fileurl = customSection.Lashouurl;
                    tarfile = customSection.Lashoupath;
                    backgroundWorker1.RunWorkerAsync();

                    statusLabel.Text = "正在下载nuomi.xml  ...";
                    fileurl = customSection.Nuomiurl;
                    tarfile = customSection.Nuomipath;
                    backgroundWorker1.RunWorkerAsync();
            }
            // Start the asynchronous operation.
                this.imeituanCheck.Enabled = false;
                this.ilashouCheck.Enabled = false;
                this.inuomiCheck.Enabled = false;
                this.button8.Enabled = false;
                filepath = customSection.Meituanpath;
                type = 1;
                statusLabel.Text = "正在索引meituan.xml  ...";
                backgroundWorker2.RunWorkerAsync();

                filepath = customSection.Lashoupath;
                type = 2;
                statusLabel.Text = "正在索引lashou.xml  ...";
                backgroundWorker2.RunWorkerAsync();

                type = 3;
                filepath = customSection.Nuomipath;
                statusLabel.Text = "正在索引nuomi.xml  ...";
                backgroundWorker2.RunWorkerAsync();
        }
    }
}


public sealed class CustomSection : ConfigurationSection
{

    public CustomSection()
    {

    }


    [ConfigurationProperty("user",
     DefaultValue = "root",
     IsRequired = true,
     IsKey = true)]
    public string User
    {
        get
        {
            return (string)this["user"];
        }
        set
        {
            this["user"] = value;
        }
    }

    [ConfigurationProperty("passwd",
        DefaultValue = "",
        IsRequired = true)]
    public string Passwd
    {
        get
        {
            return (string)this["passwd"];
        }
        set
        {
            this["passwd"] = value;
        }
    }

    [ConfigurationProperty("database",
        DefaultValue = "",
        IsRequired = true)]
    public string Database
    {
        get
        {
            return (string)this["database"];
        }
        set
        {
            this["database"] = value;
        }
    }
    [ConfigurationProperty("host",
      DefaultValue = "localhost",
      IsRequired = true)]
    public string Host
    {
        get
        {
            return (string)this["host"];
        }
        set
        {
            this["host"] = value;
        }
    }
    [ConfigurationProperty("meituanurl",
     DefaultValue = @"http://www.meituan.com/api/v2/beijing/deals",
     IsRequired = true)]
    public string Meituanurl
    {
        get
        {
            return (string)this["meituanurl"];
        }
        set
        {
            this["meituanurl"] = value;
        }
    }
    [ConfigurationProperty("lashouurl",
     DefaultValue = @"http://open.client.lashou.com/api/detail/city/2419/p/1",
     IsRequired = true)]
    public string Lashouurl
    {
        get
        {
            return (string)this["lashouurl"];
        }
        set
        {
            this["lashouurl"] = value;
        }
    }
    [ConfigurationProperty("nuomiurl",
     DefaultValue = @"http://www.nuomi.com/api/dailydeal?version=v1&city=beijing",
     IsRequired = true)]
    public string Nuomiurl
    {
        get
        {
            return (string)this["nuomiurl"];
        }
        set
        {
            this["nuomiurl"] = value;
        }
    }
    [ConfigurationProperty("meituanpath",
     DefaultValue = "xml/meituan.xml",
     IsRequired = true)]
    public string Meituanpath
    {
        get
        {
            return (string)this["meituanpath"];
        }
        set
        {
            this["meituanpath"] = value;
        }
    }
    [ConfigurationProperty("lashoupath",
     DefaultValue = "xml/lashou.xml",
     IsRequired = true)]
    public string Lashoupath
    {
        get
        {
            return (string)this["lashoupath"];
        }
        set
        {
            this["lashoupath"] = value;
        }
    }
    [ConfigurationProperty("nuomipath",
     DefaultValue = "xml/nuomi.xml",
     IsRequired = true)]
    public string Nuomipath
    {
        get
        {
            return (string)this["nuomipath"];
        }
        set
        {
            this["nuomipath"] = value;
        }
    }
}
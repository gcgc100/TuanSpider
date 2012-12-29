using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.IO;

namespace DownloadXml
{
    public class downloadXml
    {
        private BackgroundWorker backgroundWorker1;
        private XmlDocument document = null;
        string fileurl;

        public downloadXml()
        {
            // Instantiate BackgroundWorker and attach handlers to its
            // DowWork and RunWorkerCompleted events.
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
        }
        public void download(string fileurl, string tarfile)
        {
            this.fileurl = fileurl;
            StreamWriter sw = new StreamWriter(tarfile);
            // Start the download operation in the background.
            this.backgroundWorker1.RunWorkerAsync();
            while (this.backgroundWorker1.IsBusy)
            {
            }
            sw.Write(document.InnerXml);
            sw.Flush();
            sw.Close();
        }
        private void backgroundWorker1_DoWork(
            object sender,
            DoWorkEventArgs e)
        {
            document = new XmlDocument();

            // Uncomment the following line to
            // simulate a noticeable latency.
            //Thread.Sleep(5000);

            // Replace this file name with a valid file name.
            document.Load(fileurl);
        }
        private void backgroundWorker1_RunWorkerCompleted(
        object sender,
        RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
                Console.WriteLine("Download {0} complete!", fileurl);
            else
            {
                Console.WriteLine("Failed to download file {0}.", fileurl);
            }
            // Set progress bar to 100% in case it's not already there.
            //progressBar1.Value = 100;

            //if (e.Error == null)
            //{
            //    MessageBox.Show(document.InnerXml, "Download Complete");
            //}
            //else
            //{
            //    MessageBox.Show(
            //        "Failed to download file",
            //        "Download failed",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}

            //// Enable the download button and reset the progress bar.
            //this.downloadButton.Enabled = true;
            //progressBar1.Value = 0;
        }
    }
}

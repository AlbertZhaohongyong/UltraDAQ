using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraDAQ_Lite.SubForm
{
    public partial class Form_Progressbar : Form
    {
        #region 属性       
        /*进度名*/
        private string processName;
        public delegate void close_ProcessState();//申明委托


        public string m_processName
        {
            get { return processName; }
            set { processName = value; }
        }
        /*进度值*/
        private int processValue;

        public int m_processValue
        {
            get { return processValue; }
            set { processValue = value; }
        }
        #endregion

        public Form_Progressbar()
        {
            InitializeComponent();
        }

        private void Form_Progressbar_Load(object sender, EventArgs e)
        {
            //this.ucRollText_ProcessName.Text = m_processName;
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = 100;
        }

        /// <summary>
        /// 进度条设置为左右转动
        /// </summary>
        public void ProcessMarquee(string str)
        {
            this.progressBar1.Style = ProgressBarStyle.Marquee;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "通道配置中";
            this.label_ProcessStatus.Text = str;
            this.ShowInTaskbar = false;
            this.TopMost = true;
        }

        public void CloseProcess()
        {
            if (this.InvokeRequired)
            {
                close_ProcessState close_ProcessState = new close_ProcessState(CloseProcess);
                this.Invoke(close_ProcessState);
            }
            else
            {
                this.Visible = false;
            }
        }


        /// <summary>
        /// Increase process bar
        /// </summary>
        /// <param name="nValue">the value increased</param>
        /// <returns></returns>
        public bool Increase(int nValue)

        {
            if (nValue > 0)
            {
                if (progressBar1.Value + nValue < progressBar1.Maximum)
                {
                    progressBar1.Value += nValue;
                    return true;
                }
                else
                {
                    progressBar1.Value = progressBar1.Maximum;
                    this.Dispose();
                    this.Close();
                    return false;
                }
            }
            return false;
        }


        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var count = (int)e.Argument;
            for (int i = 1; i <= count; i++)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                if (i == 2)
                    throw new Exception("出错啦！");

                bw.ReportProgress(i);
                Thread.Sleep(200);
            }
        }
    }
}

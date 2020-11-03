using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraDAQ_Lite.UserControls
{
    public partial class UCDevice : UserControl
    {
        #region 属性
        /*设备SN*/
        private string strDevSN;
        public string m_strDevSN
        {
            get { return strDevSN; }
            set { strDevSN = value; }
        }
        /*设备IP*/
        private string strDevIP;
        public string m_strDevIP
        {
            get { return strDevIP; }
            set { strDevIP = value; }
        }
        /*设备别名*/
        private string strDevSubName;
        public string m_strDevSubName
        {
            get { return strDevSubName; }
            set { strDevSubName = value; }
        }
        /*Mac地址*/
        private string MAC;
        public string m_Mac
        {
            get { return MAC; }
            set { MAC = value; }
        }
        /*型号*/
        private string Model;

        public string m_Model
        {
            get { return Model; }
            set { Model = value; }
        }
        /*固件版本*/
        private string SoftVersion;

        public string m_SoftVersion
        {
            get { return SoftVersion; }
            set { SoftVersion = value; }
        }


        /*设备在线状态*/
        private bool bOnline;
        public bool m_bOnline
        {
            get { return bOnline; }
            set { bOnline = value; }
        }
     
        /*设备选中状态*/
        private bool bDevCheck;
        public bool m_bDevCheck
        {
            get { return bDevCheck; }
            set { bDevCheck = value; }
        }
        #endregion

        public UCDevice()
        {
            InitializeComponent();
        }

        private void checkBox_IsChoose_CheckedChanged(object sender, EventArgs e)
        {
            bDevCheck = checkBox_IsChoose.Checked;
        }

        public void updateCurrentState()
        {
            if(bOnline)
            {
                this.iconPictureBox_State.IconColor = Color.FromArgb(50, 170, 102);             
                this.checkBox_IsChoose.Enabled = true;
                this.label_SN.Text = "SN:" + strDevSN;
                this.label_IP.Text = strDevIP;
                this.label_DevSubName.Text = strDevSubName;
            }
            else
            {
                this.iconPictureBox_State.IconColor = Color.Gray;
                this.checkBox_IsChoose.Enabled = false;
            }
        }


    }
}

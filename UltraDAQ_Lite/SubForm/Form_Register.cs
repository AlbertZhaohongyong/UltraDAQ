using LibVisa;
using saker_Winform.Global;
using saker_Winform.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltraDAQ_Lite.SubForm
{    
    public partial class Form_Register : Form
    {
        #region 字段属性
        CVisa deviceVisa = null;
        public bool checkBox { get; set; }
        public string m_visaName { get; set; }
        public string devInfo { get; set; }
        public string m_devIP { get; set; }
        #endregion
        public Form_Register()
        {
            InitializeComponent();
        }

        private void button_RegistorView_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.combox_DevVisa.Text))
            {
                MessageBox.Show("Please fill in communication mode!");
                return;
            }
            if(this.radioButton_LAN.Checked)
            {
                m_devIP = this.combox_DevVisa.Text;
                m_visaName = "TCPIP0::" + this.combox_DevVisa.Text + "::inst0::INSTR";          
            }
            if(this.radioButton_USB.Checked)
            {
                m_visaName = this.combox_DevVisa.Text;
            }
            try
            {
                //if (deviceVisa != null)
                //{
                //    deviceVisa.Close();
                //}
                if(deviceVisa == null)
                {
                    deviceVisa = new CVisa(m_visaName);
                }
                
                /* USB读取IP */
                if (this.radioButton_USB.Checked)
                {
                    byte[] ipInfo = Encoding.Default.GetBytes(CGlobalCmd.STR_CMD_GET_IPAD + "\n");
                    deviceVisa.WriteBytes(ipInfo, ipInfo.Length);
                    byte[] ipInfoRead = new byte[1024];
                    int ipInfoReadLength = deviceVisa.ReadBytes(ipInfoRead, 1024);
                    m_devIP = null;
                    m_devIP = Encoding.Default.GetString(ipInfoRead, 0, ipInfoReadLength);
                }

                /* USB/LAN读取*IDN和MAC */
                byte[] command = Encoding.Default.GetBytes(CGlobalCmd.STR_CMD_INQUIRE + ";" + CGlobalCmd.STR_CMD_GET_MAC + "\n");
                deviceVisa.WriteBytes(command, command.Length);
                byte[] byteToRead = new byte[1024];
                int retCount = deviceVisa.ReadBytes(byteToRead, 1024);           
                devInfo = null;
                devInfo = Encoding.Default.GetString(byteToRead, 0, retCount);
                deviceVisa.Close();
                if (devInfo.Contains("RIGOL"))
                {
                    this.textBox_DevInfo.Clear();
                    this.textBox_DevInfo.Text = devInfo + "\r\n";
                    this.textBox_DevInfo.AppendText("\r\n");
                    this.textBox_DevInfo.AppendText("Connection Succeeded!\r\n");
                }
                else
                {
                    this.textBox_DevInfo.Clear();
                    this.textBox_DevInfo.AppendText("Connection Fail!\r\n");
                }
                
            }
            catch (Exception)
            {
                deviceVisa.Close();
                deviceVisa = null;
            }
            

        }

        private void Form_Register_Load(object sender, EventArgs e)
        {
            ClassVisa._Visa_Init();
            this.textBox_DevInfo.ReadOnly = true;
            this.radioButton_LAN.Checked = true;
            this.iconButton_Refresh.Visible = false;
        }

        private void AssignDevInfo()
        {
            devInfo = devInfo.TrimEnd(Environment.NewLine.ToCharArray());//去除最后的/n
            string[] recvDevInfo = devInfo.Split(';');
            Module_Device module_Device = new Module_Device();//创建设备实例
            module_Device.visaResource = m_visaName;//Visa资源名
            module_Device.Name = this.textBox_DevSubName.Text;//设备别名
            module_Device.IP = m_devIP;//设备IP
            module_Device.MAC = recvDevInfo[1];//MAC
            module_Device.Model = recvDevInfo[0].Split(',')[1];//设备型号
            module_Device.SN = recvDevInfo[0].Split(',')[2];//设备SN
            module_Device.SoftVersion = recvDevInfo[0].Split(',')[3];//设备固件版本
            module_Device.Status = true;//设备在线状态
            module_Device.VirtualNumber = (Module_DeviceManage.Instance.Devices.Count+1).ToString().PadLeft(3,'0');//虚拟编号
            Module_DeviceManage.Instance.Devices.Add(module_Device);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.textBox_DevSubName.Text))
            {
                MessageBox.Show("Please fill in Device SubName!");
                return;
            }
            else if(this.textBox_DevInfo.Text.Contains("Succee"))
            {
                Action action = new Action(AssignDevInfo);
                action.Invoke();
                this.Close();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton_USB_CheckedChanged(object sender, EventArgs e)
        {
            this.iconButton_Refresh.Visible = true;
        }

        private void radioButton_LAN_CheckedChanged(object sender, EventArgs e)
        {
            this.iconButton_Refresh.Visible = false;
        }

        private void iconButton_Refresh_Click(object sender, EventArgs e)
        {
            this.combox_DevVisa.Text = "";
            this.combox_DevVisa.Items.Clear();
            ClassVisa clsVisa = new ClassVisa(ClassVisa.USB_DEVICE);
            foreach (var item in ClassVisa.DevicesInfo)
            {
                if (item != null && item.VisaAddr != null)
                {
                    this.combox_DevVisa.Items.Add(item.VisaAddr);
                    this.combox_DevVisa.Text = item.VisaAddr;                 
                }
            }
        }
    }
}

using LibVisa;
using saker_Winform.CommonBaseModule;
using saker_Winform.Module;
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
using UltraDAQ_Lite.UserControls;

namespace UltraDAQ_Lite.SubForm
{
    public partial class Form_DeviceConfig : Form
    {
        public Form_DeviceConfig()
        {
            InitializeComponent();
        }

        #region 字段/属性
        public List<UCDevice> listUCDevices = new List<UCDevice>();//管理自定义控件UCDevice
        private int devMaxNumber = 4;//支持最大设备数
        public static bool bConfig;
        public static bool bReg;
        public static bool bDel;
        #endregion

        #region 配置
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconButton_Config_Click(object sender, EventArgs e)
        {
            if (IsEmptyCheckout()) //空值判断
            {
                MessageBox.Show("Null value or no device information, please enter or register the instrument and click pply");
                return;
            }
            else
            {
                if (IsValidCheck()) //参数有效性判断
                {
                    MessageBox.Show("Invalid parameters exist, please check.", "Warnning!");
                    return;
                }

                Form_Progressbar form_Progressbar = new Form_Progressbar();
                /* 开启进度条 */
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                cancelTokenSource.Token.Register(() =>
                {
                    form_Progressbar.CloseProcess();//委托方法调用进度条关闭                
                    DialogResult res = MessageBox.Show("Channel configuration is complete", "Configuration", MessageBoxButtons.OK);
                    if (res == DialogResult.OK)
                    {
                        //RaiseEvent("ProcessClose");
                        return;
                    }
                });
                bConfig = true;
                Task.Run(() =>
                {
                    form_Progressbar.ProcessMarquee("Configuring...");//设置进度条显示为左右转动
                    form_Progressbar.StartPosition = FormStartPosition.CenterScreen;//程序中间
                    form_Progressbar.ShowDialog();
                }, cancelTokenSource.Token);

                /* 仪器设备信息 */            
                Dictionary<string, string> device_CommonSCPI = new Dictionary<string, string>();
                device_CommonSCPI.Add("TriggerSource", comboBox_TriggeSource.Text);//触发源
                device_CommonSCPI.Add("TriggerMode", comboBox_TrigStyle.Text);//触发方式
                device_CommonSCPI.Add("MemDepth", comboBox_StorgeDepth.Text);//存储深度
                device_CommonSCPI.Add("HoldOff", CUnitTransform.UnitTransF(comboBox_TrigHoldUnit, textBox_TrigHold)); //触发释抑
                device_CommonSCPI.Add("HorizontalTimebase", CUnitTransform.UnitTransF(comboBox_HorTimeUnit, textBox_HorTime));//水平时基
                device_CommonSCPI.Add("HorizontalOffset", CUnitTransform.UnitTransF(comboBox_HoriOffsetUnit, textBox_HoriOffset)); //水平偏移
                device_CommonSCPI.Add("TriggerLevel", CUnitTransform.UnitTransF(comboBox_TriggerLevelUnit, textBox_TriggerLevel));//触发电平  

                DataTable dataTable_DeviceChannel = dataGridView_ChanSet.DataSource as DataTable;//将DataGridView转换为DataTable
                /* 赋值给单例 */
                Module_DeviceManage.Instance.AssignDeviceAndChannel(device_CommonSCPI, dataTable_DeviceChannel);
                /* 建立Visa连接 */
                ClassVisa._Visa_Init();//初始化句柄
                Parallel.For(0, Module_DeviceManage.Instance.Devices.Count, i =>
                {
                    Module_Device module_Device = Module_DeviceManage.Instance.Devices[i];
                    if (module_Device.Status == true)
                    {
                        if (module_Device.deviceVisa == null)
                        {
                            try
                            {
                                module_Device.deviceVisa = new CVisa(module_Device.visaResource);
                            }
                            catch (Exception)
                            {
                                module_Device.Status = false;
                            }
                        }
                    }
                    else
                    {
                        module_Device.deviceVisa.Close();
                        module_Device.deviceVisa = null;
                    }

                });
                /* 发送指令 */
                Module_DeviceManage.Instance.SetDevices();
                Module_DeviceManage.Instance.MaxChannelModel = Module_DeviceManage.Instance.GetMaxChannelMode();

                /* 设置延时，每台设备设置5s延时用于Visa传输指令 */
                Thread.Sleep(5000 * Module_DeviceManage.Instance.Devices.Count);
                cancelTokenSource.Cancel();
            }
        }
        #endregion

        #region 删除仪器
        private void iconButton_DelDev_Click(object sender, EventArgs e)
        {
            foreach (UCDevice item in this.flowLayoutPanel_DeviceManager.Controls)
            {
                if (item.m_bDevCheck)
                {
                    if (Module_DeviceManage.Instance.GetDeviceBySN(item.m_strDevSN).deviceVisa != null)
                    {
                        Module_DeviceManage.Instance.GetDeviceBySN(item.m_strDevSN).deviceVisa.Close();
                        Module_DeviceManage.Instance.GetDeviceBySN(item.m_strDevSN).deviceVisa = null;
                    }

                    Module_DeviceManage.Instance.Devices.Remove(Module_DeviceManage.Instance.GetDeviceBySN(item.m_strDevSN));//从单例中移除相关设备 
                    listUCDevices.Remove(item);
                }
            }

            Action action = new Action(UpdateControlView);
            action.Invoke();
            bDel = true;
        }
        #endregion

        #region 添加仪器
        private void iconButton_Add_Click(object sender, EventArgs e)
        {
            if (Module_DeviceManage.Instance.Devices.Count >= devMaxNumber)//设备数超限判断
            {
                MessageBox.Show("The maximum number of device is"+ devMaxNumber.ToString()+"，beyond the limit,you can't register more.");
            }
            else
            {
                Form_Register form_Register = new Form_Register();//仪器的注册
                form_Register.StartPosition = FormStartPosition.CenterParent;
                form_Register.ShowDialog();
                bReg = true;
                Action action = new Action(ShowCtrDev);
                action += UpdateControlView;
                action.Invoke();
                this.dataGridView_ChanSet.Refresh();
            }
        }
        #endregion

        #region 方法：单例赋值给List和DataGridView
        /// <summary>
        /// 单例赋值给List和DataGridView
        /// </summary>
        private void ShowCtrDev()
        {
            for (int i = 0; i < Module_DeviceManage.Instance.Devices.Count; i++)
            {
                /* 通过listUCDevice管理自定义控件 */
                UCDevice uCDevice = new UCDevice();
                listUCDevices.Add(uCDevice);
                Module_Device module_Device = Module_DeviceManage.Instance.Devices[i];
                /* 设备自定义控件赋值 */
                listUCDevices[i].m_strDevSubName = module_Device.Name;
                listUCDevices[i].m_strDevIP = module_Device.visaResource;
                listUCDevices[i].m_Mac = module_Device.MAC;
                listUCDevices[i].m_Model = module_Device.Model;
                listUCDevices[i].m_strDevSN = module_Device.SN;
                listUCDevices[i].m_SoftVersion = module_Device.SoftVersion;
                listUCDevices[i].m_bOnline = module_Device.Status;
                listUCDevices[i].updateCurrentState();

                /* 绑定初始的通道显示信息表 */
                for (int j = 1; j < 5; j++)
                {
                    module_Device.GetChannel(j).ChannelID = j;//通道
                    module_Device.GetChannel(j).Collect = true;//采集
                    module_Device.GetChannel(j).Tag = "Tag" + (((int.Parse(module_Device.VirtualNumber)-1)*4+j)).ToString().PadLeft(3,'0');//Tag
                    module_Device.GetChannel(j).Scale = "1";//范围
                    module_Device.GetChannel(j).Offset = "0";//偏移
                    module_Device.GetChannel(j).Impedance = "1M";//阻抗
                    module_Device.GetChannel(j).Coupling = "DC";//耦合
                    module_Device.GetChannel(j).ProbeRatio = "*1";//探头比
                }
            }
        }
        #endregion

        #region 方法：将DevList刷到流式布局中
        /* 将DevList刷到流式布局中 */
        private void UpdateControlView()
        {
            this.flowLayoutPanel_DeviceManager.Controls.Clear();
            for (int i = 0; i < Module_DeviceManage.Instance.Devices.Count; i++)
            {
                flowLayoutPanel_DeviceManager.Controls.Add(listUCDevices[i]);
                flowLayoutPanel_DeviceManager.AllowDrop = true;
            }
            this.flowLayoutPanel_DeviceManager.Refresh();
            dataGridView_ChanSet.DataSource = Module_DeviceManage.Instance.GetChanelConfig();
        }
        #endregion

        #region Load事件
        private void Form_DeviceConfig_Load(object sender, EventArgs e)
        {
            /* 去除窗体的标题栏 */
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.ShowInTaskbar = false;

            /* 初始化流式布局控件 */
            flowLayoutPanel_DeviceManager.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel_DeviceManager.WrapContents = true;
            flowLayoutPanel_DeviceManager.HorizontalScroll.Maximum = 0;
            flowLayoutPanel_DeviceManager.AutoScroll = true;                     

            /* 通道参数控件初始化 */
            this.comboBox_TriggeSource.SelectedIndex = 0; //默认选择0
            this.comboBox_TrigStyle.SelectedIndex = 0; //默认选择0
            this.comboBox_StorgeDepth.SelectedIndex = 1; //默认选择3
            this.comboBox_HoriOffsetUnit.SelectedIndex = 0;//水平偏移默认单位为V
            this.comboBox_HorTimeUnit.SelectedIndex = 2;//水平时基默认单位为us
            this.comboBox_TriggerLevelUnit.SelectedIndex = 1; //触发电平默认单位为mV
            this.comboBox_TrigHoldUnit.SelectedIndex = 3;//触发释抑默认单位为ns
            this.textBox_HorTime.Text = "1";
            this.textBox_HoriOffset.Text = "0";
            this.textBox_TriggerLevel.Text = "500";
            this.textBox_TrigHold.Text = "8";
            this.comboBox_StorgeDepth.DropDownStyle = ComboBoxStyle.DropDownList; //禁止下拉框手动输入
            this.comboBox_TriggeSource.DropDownStyle = ComboBoxStyle.DropDownList; //禁止下拉框手动输入
            this.comboBox_TrigStyle.DropDownStyle = ComboBoxStyle.DropDownList;//禁止下拉框手动输入
            this.textBox_HorTime.KeyPress += TextBox_HorTime_KeyPress;  //水平时基KeyPress事件，限制输入数字
            this.textBox_TriggerLevel.KeyPress += TextBox_TriggerLevel_KeyPress; //触发电平KeyPress事件，限制输入数字
            this.textBox_TrigHold.KeyPress += TextBox_TrigHold_KeyPress; //水平偏移KeyPress事件，限制输入数字
            this.textBox_HoriOffset.KeyPress += TextBox_HoriOffset_KeyPress; //触发释抑KeyPress事件，限制输入数字
        }
        #endregion

        #region 方法：限定只能输入数字
        /// <summary>
        /// 方法：限定只能输入数字
        /// </summary>
        /// <param name="e"></param>
        public void LimitInput(KeyPressEventArgs e, bool negative)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9')) e.Handled = true;
            if (negative)
            {
                if (e.KeyChar == '\b' || e.KeyChar == '-' || e.KeyChar == '.') e.Handled = false;
            }
            else
            {
                if (e.KeyChar == '\b' || e.KeyChar == '.') e.Handled = false;
            }

        }
        #endregion

        #region 方法：判断是否为空值，为空弹出对话框
        /// <summary>
        /// 判断是否为空值，为空弹出对话框
        /// </summary>
        /// <returns></returns>
        public bool IsEmptyCheckout()
        {
            if (string.IsNullOrEmpty(textBox_TriggerLevel.Text) || string.IsNullOrEmpty(textBox_TrigHold.Text)
                || string.IsNullOrEmpty(textBox_HorTime.Text) || string.IsNullOrEmpty(textBox_HoriOffset.Text) ||
                (this.dataGridView_ChanSet.Rows.Count <= 0))
            {             
                return true;
            }
            return false;
        }

        /// <summary>
        /// 验证输入是否合法，尝试转换为Double
        /// </summary>
        /// <returns></returns>
        public bool IsValidCheck()
        {
            double numberValid;
            if (!(double.TryParse(textBox_TriggerLevel.Text, out numberValid) && double.TryParse(textBox_TrigHold.Text, out numberValid)
                && double.TryParse(textBox_HorTime.Text, out numberValid) && double.TryParse(textBox_HoriOffset.Text, out numberValid)))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 事件：限制只能输入数字
        /// <summary>
        /// 水平偏移KeyPress事件，限制输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_HoriOffset_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimitInput(e, true);
        }

        /// <summary>
        /// 触发释抑KeyPress事件，限制输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TrigHold_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimitInput(e, false);
        }

        /// <summary>
        /// 触发电平KeyPress事件，限制输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TriggerLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimitInput(e, true);
        }

        /// <summary>
        /// 水平时基KeyPress事件，限制输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_HorTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            LimitInput(e, false);
        }
        #endregion


    }
}

using saker_Winform.CommonBaseModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltraDAQ_Lite.SubForm;

namespace UltraDAQ_Lite
{
    public partial class Form_Main : Form
    {
        #region 字段/属性
        private Form_DeviceConfig form_DeviceConfig = new Form_DeviceConfig();
        private Form_WaveMonitor form_WaveMonitor = new Form_WaveMonitor();
        #endregion
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            this.panel_FunctionItem.Width = 118;
            form_DeviceConfig.FormBorderStyle = FormBorderStyle.None;
            form_DeviceConfig.TopLevel = false;
            form_DeviceConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Module.Controls.Add(form_DeviceConfig);
            form_DeviceConfig.Show();
        }

        #region 事件：事件：右侧折叠  事件：左侧展开
        private void iconButton_DockLeft_Click(object sender, EventArgs e)
        {
            if (this.panel_FunctionItem.Width == 118)
            {
                this.panel_FunctionItem.Width = 37;
                this.iconButton_DockLeft.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            }
            else
            {
                this.panel_FunctionItem.Width = 118;
                this.iconButton_DockLeft.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            }
        }

        private void iconButton_DockRight_Click(object sender, EventArgs e)
        {
            this.panel_FunctionItem.Width = 118;
            this.iconButton_DockLeft.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            iconButton_DockLeft.Visible = false;
            iconButton_DockRight.Visible = true;
        }
        #endregion

        private void iconButton_ConfgDev_Click(object sender, EventArgs e)
        {
            LeftColor("ConfgDev");
            if (panel_Module.Controls.Contains(form_DeviceConfig))
                return;
            this.panel_Module.Controls.Clear(); //清除显示的窗体
            form_DeviceConfig.FormBorderStyle = FormBorderStyle.None;
            form_DeviceConfig.TopLevel = false;
            form_DeviceConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Module.Controls.Add(form_DeviceConfig);
            form_DeviceConfig.Show();
        }

        #region 方法：左侧栏配色
        public void LeftColor(string iconButtonLeft)
        {
            switch (iconButtonLeft)
            {
                case "ConfgDev":
                    CControlProp.ButtonBackColor(this.iconButton_ConfgDev, 198, 198, 198);//仪器配置按钮变色
                    CControlProp.ButtonBackColor(this.iconButton_WaveView, 230, 230, 230);//通道显示按钮白色
                    CControlProp.SetButtonProp(true, iconButton_ConfgDev);
                    CControlProp.SetButtonProp(false, iconButton_WaveView);
                    break;
                case "WaveView":
                    CControlProp.ButtonBackColor(iconButton_ConfgDev, 230, 230, 230);//通道配置按钮白色
                    CControlProp.ButtonBackColor(iconButton_WaveView, 198, 198, 198);//仪器配置按钮变色      
                    CControlProp.SetButtonProp(false, iconButton_ConfgDev);
                    CControlProp.SetButtonProp(true, iconButton_WaveView);
                    break;
              
            }
        }
        #endregion

        private void iconButton_WaveView_Click(object sender, EventArgs e)
        {         
            LeftColor("WaveView");
            if (panel_Module.Controls.Contains(form_WaveMonitor))
                return;
            this.panel_Module.Controls.Clear(); //清除显示的窗体
            form_WaveMonitor.FormBorderStyle = FormBorderStyle.None;
            form_WaveMonitor.TopLevel = false;
            form_WaveMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Module.Controls.Add(form_WaveMonitor);
            form_WaveMonitor.Show();
            if(Form_DeviceConfig.bReg|| Form_DeviceConfig.bDel)
            {
                form_WaveMonitor.InitChart();
                Form_DeviceConfig.bReg = false;
                Form_DeviceConfig.bDel = false;
            }         
        }
    }
}

using LibVisa;
using saker_Winform.Global;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace saker_Winform.Module
{
    public class Module_Device
    {
        public string Name { get; set; }// 设备名称
        public string SN { get; set; }// 设备序列号
        public string IP { get; set; }  //  设备IP地址
        public string MAC { get; set; }//  设备MAC地址
        public string SoftVersion { get; set; }//  设备软件版本
        public string Model { get; set; }//  产品型号
        public string VirtualNumber { get; set; }//  虚拟编号
      
        public string SampRate { get; set; }//设备的采样率

        //  通道信息
        public  Module_Channel[] Channels = new Module_Channel[4] { new Module_Channel(),new Module_Channel(),new Module_Channel(),new Module_Channel()};            
        public bool Status { get; set; }      //设备在线状态 
        public bool IsOnTesting { get; set; } //设备在本次测试实验中
        public CVisa deviceVisa { get; set; }//Visa，用于给仪器发送命令
        public string visaResource { get; set; }//Visa资源名

        // 获取单个通道信息方法
        public Module_Channel GetChannel(int i)
        {
            return Channels[i-1];
        }
        /// <summary>
        /// 返回这台设备的通道模式
        /// </summary>
        /// <returns></returns>
        public int GetChannelModel()
        {                                 
            int temp = 0;
            int count = 0;
            for (int i = Channels.Length-1; i>=0; i--)
            {
                if (Channels[i].Collect)
                {
                    temp += (i + 1) * Convert.ToInt32(Math.Pow(10.0, count*1.0));                  
                    count++;
                }
            }          
            if (temp > 0 && temp < 10)
            {
                return 1;
            }
            if (temp > 100 || temp == 12 || temp == 34)
            {
                return 4;
            }
            if (temp < 100&&temp>10)
            {
                return 2;
            }
            return 0;
        }
        /// <summary>
        /// 返回每台设备需要发下去的通道命令
        /// </summary>
        /// <returns></returns>
        public List<string> GetChannelSCPI()
        {               
            List<string> strSendList = new List<string>();
            string strSend = "";
            List<Module_Channel> temp = Channels.Where(item => item.Collect == true).ToList();
            //如果没有要采集该仪器的数据，任何命令都不需要发送
            if (temp.Count() == 0)
            {
                return strSendList;
            }
            int channelMode = Module_DeviceManage.Instance.GetMaxChannelMode();
            //判断哪些通道是否要打开，通道模式需要保持一致           
            //四通道模式，全部打开
            if (GetChannelModel() != channelMode)
            {
                if (channelMode == 4)
                {
                    GetChannel(1).Open = true;
                    GetChannel(2).Open = true;
                    GetChannel(3).Open = true;
                    GetChannel(4).Open = true;                 
                    for (int i = 1; i <= 4; i++)
                    {
                        GetChannel(i).Open = true;
                        strSend += Global.CGlobalCmd.STR_CMD_SET_OPENCHANNEL;
                        strSend = strSend.Replace("<n>", i.ToString()) + ";";
                    }
                }
                //双通道模式，打开指定通道
                if (channelMode == 2)
                {
                    for (int i = 0; i < temp.Count(); i++)
                    {
                        if (temp[i].ChannelID < 3)
                        {
                            strSend += Global.CGlobalCmd.STR_CMD_SET_OPENCHANNEL;
                            strSend = strSend.Replace("<n>", "3") + ";";
                            strSend += Global.CGlobalCmd.STR_CMD_SET_OPENCHANNEL;
                            strSend = strSend.Replace("<n>", temp[i].ChannelID.ToString()) + ";";
                            GetChannel(temp[i].ChannelID).Open = true;
                            GetChannel(3).Open = true;                           
                            break;
                        }
                        if (temp[i].ChannelID >= 3)
                        {
                            strSend += Global.CGlobalCmd.STR_CMD_SET_OPENCHANNEL;
                            strSend = strSend.Replace("<n>", "1") + ";";
                            strSend += Global.CGlobalCmd.STR_CMD_SET_OPENCHANNEL;
                            strSend = strSend.Replace("<n>", temp[i].ChannelID.ToString()) + ";";
                            GetChannel(temp[i].ChannelID).Open = true;
                            GetChannel(1).Open = true;                          
                            break;
                        }
                    }
                }
            }
            else
            {
                if (GetChannelModel() == 4)
                {
                    //四通道模式，全部打开               
                    for (int i = 1; i <= 4; i++)
                    {
                        GetChannel(i).Open = true;
                        strSend += Global.CGlobalCmd.STR_CMD_SET_OPENCHANNEL;
                        strSend = strSend.Replace("<n>", i.ToString()) + ";";
                    }                  
                }
                else
                {
                    //不是四通道模式，直接打开勾选的采集通道，          
                    for (int i = 0; i < temp.Count(); i++)
                    {
                        strSend += Global.CGlobalCmd.STR_CMD_SET_OPENCHANNEL;
                        strSend = strSend.Replace("<n>", temp[i].ChannelID.ToString()) + ";";                     
                        GetChannel(temp[i].ChannelID).Open = true;
                    }
                }                           
            }
            //通道打开命令
            foreach (Module_Channel item in temp)
            {
                // 先发探头比后发垂直档位，探头比会影响垂直档位
                strSend += Global.CGlobalCmd.STR_CMD_SET_PROBERATIO + item.ProbeRatio.ToString().Replace("*", "") + ";";
                strSend += Global.CGlobalCmd.STR_CMD_SET_SCALE + item.Scale.ToString()+";";
                if (item.Impedance.ToString().Contains("50"))
                {
                    item.Impedance = "FIFTY";
                }
                else
                {
                    item.Impedance = "OMEG";
                }
                strSend += Global.CGlobalCmd.STR_CMD_SET_IMPENDENCE + item.Impedance.ToString() + ";";
                strSend += Global.CGlobalCmd.STR_CMD_SET_OFFSET + item.Offset.ToString() + ";";        
                strSend += Global.CGlobalCmd.STR_CMD_SET_COUPLING + item.Coupling.ToString() + ";";           
                strSend = strSend.Replace("<n>",item.ChannelID.ToString());
                if(!string.IsNullOrEmpty(strSend))
                {
                    strSendList.Add(strSend);
                    strSend = "";
                }             
            }            
            return strSendList;
        }
        /// <summary>
        /// 根据配置表，给通道信息赋值
        /// </summary>
        /// <param name="dr"></param>
        public void SetChannelConfig(DataRow dr)
        {
            //IsOnTesting = false;
            int i = Convert.ToInt32(dr["ChannelID"].ToString().Substring(2,1));
            if (string.IsNullOrEmpty(dr["Collect"].ToString()))
            {
                dr["Collect"] = false;
            }
            GetChannel(i).Collect = Convert.ToBoolean(dr["Collect"]);
            IsOnTesting = GetChannel(i).Collect | IsOnTesting;      
            GetChannel(i).Tag = dr["Tag"].ToString();
            GetChannel(i).TagDesc = dr["TagDesc"].ToString();
            GetChannel(i).Scale = dr["Scale"].ToString();
            GetChannel(i).Offset = dr["Offset"].ToString();         
            if (string.IsNullOrEmpty(GetChannel(i).Scale))
            {
                GetChannel(i).Scale = "0";
            }
            if (string.IsNullOrEmpty(GetChannel(i).Offset))
            {
                GetChannel(i).Offset = "0";
            }
            GetChannel(i).Coupling = dr["Coupling"].ToString();
            GetChannel(i).ProbeRatio = dr["ProbeRatio"].ToString();
            GetChannel(i).Impedance = dr["Impedance"].ToString();
            if (GetChannel(i).Impedance.Contains("50"))
            {
                GetChannel(i).BChanImpedence = false;
            }
            else
            {
                GetChannel(i).BChanImpedence = true;
            }          
        }
        
    }
}

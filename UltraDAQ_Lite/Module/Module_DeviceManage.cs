using ClassLibrary_ThreadManage;
using saker_Winform.CommonBaseModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace saker_Winform.Module
{
    public sealed class Module_DeviceManage
    {
        /// <summary>
        /// 仪器管理，单例模式，内存唯一
        /// </summary>
        private static readonly Lazy<Module_DeviceManage> lazy = new Lazy<Module_DeviceManage>(() => new Module_DeviceManage());
        public static Module_DeviceManage Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        // 栈
        public Stack<string> stack = new Stack<string>();
        //开始测量的时间
        public DateTime StartTime { get; set; }
        //波形数据存放表名
        public string WaveTableName { get; set; }
        //项目的识别码 GUID
        public string ProjectGUID { get; set; }
        //项目名称
        public string ProjectName { get; set; }
        //项目注释
        public string ProjectRemark { get; set; }
        //识别码
        public string GUID { get; set; }
        // 仪器总数
        public int TotalNumber;
        // 虚拟设备池
        public int PoolSize = 75;
        // 在线数量         
        public int OnlineNumber;
        // 仪器清单列表
        public List<Module_Device> Devices = new List<Module_Device>();

        public List<Module_Device> OnlineDevices = new List<Module_Device>();
        //显示配置
        // 触发源
        public string TriggerSource;
        // 触发模式
        public string TriggerMode;
        // 水平偏移
        public string HorizontalOffset;
        // 水平时基
        public string HorizontalTimebase;
        // 触发电平
        public string TriggerLevel;
        // 存储深度
        public string MemDepth;
        // 点数
        public int Points;
        // 触发释抑
        public string HoldOff;
        //最大通道模式
        public int MaxChannelModel;
        /// <summary>
        /// 返回SN为指定值的设备，SN不存在时返回空
        /// </summary>
        /// <param name="SN"></param>
        /// <returns></returns>
        public Module_Device GetDeviceBySN(string SN)
        {
            var temp = Devices.Where(item => item.SN == SN);
            if (temp.Count() != 0)
            {
                return temp.FirstOrDefault();
            }
            return null;
        } 
        /// <summary>
        /// 获取通道模式，1通道，2通道，4通道模式
        /// </summary>
        /// <returns></returns>
        public int GetMaxChannelMode()
        {
            int channelMode = Convert.ToInt32(Global.CGlobalValue.euChannelMode.NONE);
            foreach (var item in Devices)
            {
                int temp = Convert.ToInt32(item.GetChannelModel());
                if (temp > channelMode)
                {
                    channelMode = temp;
                }
                if (temp == Convert.ToInt32(Global.CGlobalValue.euChannelMode.FOURCH))
                {
                    return temp;
                }
            }
            return channelMode;
        }   
        /// <summary>
        /// 获取通道的配置参数,每个IP对应四个通道配置项,返回一个DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable GetChanelConfig()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Collect");
            dt.Columns.Add("DeviceName");
            dt.Columns.Add("ChannelID");
            dt.Columns.Add("Tag");
            dt.Columns.Add("TagDesc");
            dt.Columns.Add("Scale");
            dt.Columns.Add("Offset");
            dt.Columns.Add("Impedance");
            dt.Columns.Add("Coupling");
            dt.Columns.Add("ProbeRatio");
            dt.Columns.Add("SN");
            int count = 1;
            List<Module_Device> devicesOrder = Instance.Devices.OrderBy(item => item.VirtualNumber).ToList();
            foreach (Module_Device device in devicesOrder)
            {
                if (device.Status)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Module_Channel channel = device.Channels[i];
                        DataRow row = dt.NewRow();
                        row["ID"] = count.ToString().PadLeft(3, '0');
                        row["Collect"] = channel.Collect.ToString();
                        row["DeviceName"] = device.Name;
                        row["ChannelID"] = "CH" + channel.ChannelID;
                        row["Tag"] = channel.Tag;
                        row["TagDesc"] = channel.TagDesc;
                        if (string.IsNullOrEmpty(channel.TagDesc))
                        {
                            row["TagDesc"] = "TagComment" + row["Tag"].ToString().Substring(3, 3);
                        }
                        row["Scale"] = channel.Scale;
                        row["Offset"] = channel.Offset;
                        row["Impedance"] = "1M";
                        if (channel.Impedance.Contains("FIFTY") || channel.Impedance.Contains("50") || channel.Impedance.Contains("FIFT"))
                        {
                            row["Impedance"] = "50";
                        }
                        row["Coupling"] = channel.Coupling;
                        row["ProbeRatio"] = channel.ProbeRatio;
                        row["SN"] = device.SN;
                        dt.Rows.Add(row);
                        count++;
                    }
                }
            }
            return dt;
        }
        public string GetDeviceSCPI()
        {
            string command = "";
            command+= Global.CGlobalCmd.STR_CMD_SET_RUN+";";
            command += Global.CGlobalCmd.STR_CMD_SET_TRIGGERMODE + "NORMAL" + ";";
            command += Global.CGlobalCmd.STR_CMD_SET_READMODE + ";";
            command += Global.CGlobalCmd.STR_CMD_SET_READTYPE + ";";
            command += Global.CGlobalCmd.STR_CMD_SET_TRIGGERSOURCE + Instance.TriggerSource + ";";
            command += Global.CGlobalCmd.STR_CMD_SET_HORIZONTAOFFSET + Instance.HorizontalOffset + ";";
            command += Global.CGlobalCmd.STR_CMD_SET_HORIZONTALTIMEBASE + Instance.HorizontalTimebase + ";";
            command += Global.CGlobalCmd.STR_CMD_SET_TRIGGERLEVEL + Instance.TriggerLevel + ";";                                 
            command += Global.CGlobalCmd.STR_CMD_SET_MEMDEPTH + Instance.MemDepth + ";";
            command += Global.CGlobalCmd.STR_CMD_SET_HOLDOFF + Instance.HoldOff + ";";
            ; return command;
        }       
        /// <summary>
        ///  根据通道配置表，开始设置仪器
        /// </summary>
        public void SetDevices()
        {
            Debug.WriteLine(DateTime.Now.ToString() + " 开始配置");
            using (var countdown = new MutipleThreadResetEvent(Instance.Devices.Count))
            {
                for (int k = 0; k < Instance.Devices.Count; k++)
                {
                    var model = new MutipleThreadSendCmd();
                    model.SetDevice(Instance.Devices[k]);
                    model.MTREvent = countdown;
                    //开启N个线程，传递MutipleThreadResetEvent对象给子线程
                    ThreadPool.QueueUserWorkItem(SetSingleDevice, model);
                }
                //等待所有线程执行完毕
                countdown.WaitAll();
            }
            Debug.WriteLine(DateTime.Now.ToString() + " ");
        }
        /// <summary>
        /// 设置单台仪器命令
        /// </summary>
        /// <param name="obj"></param>
        private void SetSingleDevice(Object obj)
        {
            MutipleThreadSendCmd model = obj as MutipleThreadSendCmd;
            if (model.GetDevice().IsOnTesting == false)
            {
                model.MTREvent.SetOne();
                return;
            }
            try
            {
                Dictionary<string, string> origin = new Dictionary<string, string>();
                string send = GetDeviceSCPI();
                List<string> channelset = model.GetDevice().GetChannelSCPI();
                Debug.WriteLine("初始化仪器，关闭所有通道");
                string channelInit = ":CHANnel1:DISPlay OFF;:CHANnel2:DISPlay OFF;:CHANnel3:DISPlay OFF;:CHANnel4:DISPlay OFF;" + "\n";
                
                model.GetDevice().deviceVisa.WriteBytes(Encoding.Default.GetBytes(channelInit), Encoding.Default.GetBytes(channelInit).Length);
                Thread.Sleep(50);
                if (channelset.Count == 0)
                {
                    model.MTREvent.SetOne();
                    return;
                }
                Debug.WriteLine(Thread.CurrentThread.ManagedThreadId + " " + model.GetDevice().IP);
                foreach (string cmd in channelset)
                {
                    send += cmd;
                }
                send += Global.CGlobalCmd.STR_CMD_SET_TRIGGERMODE + Instance.TriggerMode + ";";
                send = send.Remove(send.Length - 1, 1);
                List<string> cmdSend = send.Split(';').ToList();
                send += "\n";
                Debug.WriteLine(DateTime.Now.ToString() + " 开始配置仪器：" + model.GetDevice().IP);
                model.GetDevice().deviceVisa.WriteBytes(Encoding.Default.GetBytes(send), Encoding.Default.GetBytes(send).Length);
                Debug.WriteLine(send);
                Thread.Sleep(50);
                Debug.WriteLine(DateTime.Now.ToString() + " 配置仪器完成：" + model.GetDevice().IP);           
                model.MTREvent.SetOne();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(model.GetDevice().IP + " 配置异常：" + ex.Message);
                model.MTREvent.SetOne();
            }

        }
        /// <summary>
        /// 通道配置表赋值给响应设备信息
        /// </summary>
        public void AssignDeviceAndChannel(Dictionary<string, string> dc, DataTable dt)
        {
            try
            {
                Instance.TriggerMode = dc["TriggerMode"];
                Instance.TriggerSource = dc["TriggerSource"];
                Instance.TriggerLevel = dc["TriggerLevel"];
                Instance.MemDepth = dc["MemDepth"];
                Instance.HoldOff = dc["HoldOff"];
                Instance.HorizontalTimebase = dc["HorizontalTimebase"];
                Instance.HorizontalOffset = dc["HorizontalOffset"];
                Instance.Points = CString2Value.meDepth2Value(dc["MemDepth"]);

                foreach (DataRow dr in dt.Rows)
                {
                    var sn = dr["SN"].ToString();
                    var channelId = Convert.ToInt32(dr["ChannelID"].ToString().Substring(2, 1));
                    Instance.GetDeviceBySN(sn).SetChannelConfig(dr);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }    
    }
}

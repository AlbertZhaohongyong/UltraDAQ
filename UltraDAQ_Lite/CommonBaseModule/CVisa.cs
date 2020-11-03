 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace LibVisa
{
    public class CVisa
    {
        public string DevNum;  
        public string Type;
        public string Serial;
        public string Manufactory;
        public string Version;  

        public CVisa(string Addr, int TimeOut = 5000 )
        {
            _Device_Open( Addr, TimeOut );
        }

        /// <summary>
        /// 向仪器写入命令 write command to the instrument
        /// </summary>
        /// <param name="strCmd">   </param>
        /// <returns>   </returns>
        public int Write(string strCmd)
        {
            return _Device_Write(strCmd);
        }
        /// <summary>
        /// 向仪器写入命令 write command to the instrument
        /// </summary>
        /// <param name="strCmd">   </param>
        /// <returns>   </returns>
        public int WriteBytes(byte[] buf,Int32 count)
        {
            return _Device_Write_Bytes(buf, count);
        }

        /// <summary>
        /// 从仪器读取测试结果 read the result
        /// </summary>
        /// <returns></returns>
        public string Read(int ReadLen = 1024)
        {
            return _Device_Read(ReadLen);
        }
        /// <summary>
        /// 从仪器读取测试结果 read the result
        /// </summary>
        /// <returns></returns> 
        public Int32 ReadBytes(byte[] buf, Int32 count = 1024)
        {
            return _Device_Read_Bytes(buf, count);
        }

        /// <summary>
        /// 向仪器写入命令，并读取返回结果
        /// </summary>
        /// <param name="strCmd"></param>
        /// <returns></returns>
        public string Query(string strCmd, int ReadLen = 1024)
        {
            string strRtn = "";
            int WriteCnt = _Device_Write(strCmd);
            if (WriteCnt >= 0)
            {
                strRtn = _Device_Read(ReadLen);
            }

            return strRtn;
        }

        /// <summary>
        /// 关闭通讯
        /// </summary>
        /// <returns></returns>
        public int Close()
        {
            return _Device_Close();
        }
       /// <summary>
       /// 设置串口的波特率
       /// </summary>
       /// <param name="baud">
       /// 串口波特率，
       /// </param>
       /// <returns>
        /// 返回值：0，配置成功，负数，配置失败
       /// </returns>
        public int ASLSetBAUD(int baud)
        {
            int state;
            state = ClassVisa.viSetAttribute(g_i32VisaIO, ClassVisa.VI_ATTR_ASRL_BAUD, baud);
            return state;
        }
        /// <summary>
        /// 配置串口的奇偶校验位
        /// </summary>
        /// <param name="parity">
        /// 输入变量：奇偶校验类型
        /// ClassVisa.VI_ASRL_PAR_NONE - 0  - No parity bit exists, 
        /// ClassVisa.VI_ASRL_PAR_ODD  - 1  - Odd parity should be used, 
        /// ClassVisa.VI_ASRL_PAR_EVEN - 2  - Even parity should be used,
        /// ClassVisa.VI_ASRL_PAR_MARK - 3  - MARK  Parity bit exists and is always 1,
        /// ClassVisa.VI_ASRL_PAR_SPACE - 4  - SPACE Parity bit exists and is always 0.
        /// </param>
        /// <returns>
        /// 返回值：0，配置成功，负数，配置失败
        /// </returns>
        public int ASLSetPARITY(int parity)
        {
            int state;
            state = ClassVisa.viSetAttribute(g_i32VisaIO,ClassVisa.VI_ATTR_ASRL_PARITY,parity);
            return state;
         
        }
        /// <summary>
        /// 配置串口通信的数据位数
        /// </summary>
        /// <param name="databits">
        /// 串行通信数据位数，取值范围：5-8
        /// </param>
        /// <returns>
        ///  返回值：0，配置成功，负数，配置失败
        /// </returns>
        public int ASLSeDATAtBITS(int databits)
        {
            int state;
            state = ClassVisa.viSetAttribute(g_i32VisaIO,ClassVisa.VI_ATTR_ASRL_DATA_BITS,databits);
            return state;
                
        }
        /// <summary>
        /// 配置串口通信的数据位数
        /// </summary>
        /// <param name="stopbits">
        /// ClassVisa.VI_ASRL_STOP_ONE   - 10 - 1 stop bit is used per frame,
        /// ClassVisa.VI_ASRL_STOP_ONE5  - 15 - 1.5 stop bits are used per frame,
        /// ClassVisa.VI_ASRL_STOP_TWO   - 20 - 2 stop bits are used per frame.
        /// </param>
        /// <returns>
        /// 返回值：0，配置成功，负数，配置失败
        /// </returns>
        public int ASLSetSTOPBITS(int stopbits)
        {
            int state;
            state = ClassVisa.viSetAttribute(g_i32VisaIO,ClassVisa.VI_ATTR_ASRL_STOP_BITS,stopbits);
            return state;
        }
        /// <summary>
        /// 设置串口的timeOut时间
        /// </summary>
        /// <param name="T_timeOut">
        /// timeout的时间ms
        /// </param>
        /// <returns>
        /// 返回值：0，配置成功，负数，配置失败
        /// </returns>
        public int ASLSetTimerOut(int T_timeOut)
        {
            int state;
            state = ClassVisa.viSetAttribute(g_i32VisaIO, ClassVisa.VI_ATTR_TMO_VALUE, T_timeOut);
            return state;
        }



        /********************************************* 私有属性 *********************************************/
        
        /// <summary>
        /// viOpen打开的对话通道
        /// </summary> 
        public Int32 g_i32VisaIO;

        /********************************************* 私有方法 *********************************************/
        

        /// <summary>
        /// 根据地址信息打开设备
        /// </summary>
        /// <param name="strAddr">设备地址字符串</param>
        /// <param name="TimeOut_ms">超时时间</param>
        /// <returns>错误码</returns>
        private int _Device_Open(string strAddr, int TimeOut_ms)
        {
            try
            {
                ClassVisa.viClose(g_i32VisaIO);
                //根据地址信息打开设备
                ClassVisa.viOpen(ClassVisa.g_i32RsrcManager, strAddr, 0, TimeOut_ms, ref g_i32VisaIO);
            }
            catch (Exception err)
            {
                //统一错误处理  error handling    
            }
            return 0;
        }
        /// <summary>
        /// 关闭当前打开的设备
        /// </summary>
        /// <returns>错误码</returns>
        private int _Device_Close()
        {
            return ClassVisa.viClose(g_i32VisaIO);
        }
        /// <summary>
        /// 向设备写入命令字符串
        /// </summary>
        /// <param name="Cmd">命令字符串</param>
        /// <returns>错误码</returns>
        private int _Device_Write(string Cmd)
        {
            try
            {
                string strCmd = Cmd;  //命令字符串
                
               return ClassVisa.viVPrintf(g_i32VisaIO, strCmd, 0); //向visa接口发送命令符
            }
            catch (Exception err)
            {
                //统一错误处理  error handling    
            }

            return 0;
        }
        /// <summary>
        /// 向设备写入数据
        /// </summary>
        /// <param name="Cmd">命令字符串</param>
        /// <returns>错误码</returns>
        private int _Device_Write_Bytes(byte[]buf,Int32 count)
        {
            Int32 retCount = 0;
            try
            {
                return ClassVisa.viWrite(g_i32VisaIO, buf, count, retCount); //向visa接口发送命令符
            }
            catch (Exception err)
            {
                //统一错误处理 error handling     
            }

            return retCount;
        }
        /// <summary>
        /// 从设备读取命令返回结果
        /// </summary>
        /// <returns>从设备读取到的返回字符串</returns>
        private string _Device_Read(int Len = 1024)
        {
            string strReturn = "";         //返回值参数并初始化
            try
            {
                byte[] temp = new byte[Len];   //buffer

                int Error = ClassVisa.viScanf(g_i32VisaIO, "%t", temp);
                if (Error < 0)
                {
                    return strReturn;
                }

                strReturn = Encoding.ASCII.GetString(temp); //将接收到的字节数组内容转化成为字符串

                //remove '\n'
                if (strReturn.IndexOf('\n') != -1)
                {
                    strReturn = strReturn.Substring(0, strReturn.IndexOf('\n'));
                }
            }
            catch (Exception err)
            {
                //统一错误处理    error handling  
            }

            return strReturn;
        }
        /// <summary>
        /// 从设备读取命令返回结果
        /// </summary>
        /// <returns>从设备读取到的返回字符串</returns>
        private Int32 _Device_Read_Bytes( byte[] buf, Int32 count)
        {
            Int32 retCount = 0;
            ClassVisa.viRead(g_i32VisaIO, buf, count, out retCount);
            return retCount;
        }


        public string[] _GetDevIdnInfo(string Addr)
        {
            Int32 retCount = 0;
            byte[] byteToRead = new byte[1024];
            _Device_Open(Addr, 1000);
            string command = "*idn?";
            command = command + "\n";
            byte[] byteToSend = Encoding.Default.GetBytes(command);
            _Device_Write_Bytes(byteToSend, byteToSend.Length);
            retCount = _Device_Read_Bytes(byteToRead, 1024);
            string Temp = Encoding.Default.GetString(byteToRead, 0, retCount);
            _Device_Close();
            return Temp.Split(',');
        }

    }

    public class ClassDeviceInfo
    {
        public string VisaAddr;
        public string Manufactory;
        public string Type;
        public string Serial;
        public string Version;

        public ClassDeviceInfo()
        {
            VisaAddr = "";
            Manufactory = "";
            Type = "";
            Serial = "";
            Version = "";
        }
    }

    /// <summary>
    /// 查找、打开、控制Visa设备的类（可以根据接口类型选择查找）
    /// </summary>
    public class ClassVisa
    {

        //' ************************************************************************
        //' 参数类型：串口配置参数宏定义
        //' ************************************************************************
        public const int VI_ATTR_ASRL_BAUD = 1073676321;
        public const int VI_ATTR_ASRL_PARITY = 1073676323;
        public const int VI_ATTR_ASRL_DATA_BITS = 1073676322;
        public const int VI_ATTR_ASRL_STOP_BITS = 1073676324;
        public const int VI_ATTR_ASRL_FLOW_CNTRL = 1073676325;
        public const int VI_ATTR_TMO_VALUE = 1073676314;

        public const short VI_ASRL_PAR_NONE = 0;                     //No parity bit exists,
        public const short VI_ASRL_PAR_ODD = 1;                      //Odd parity should be used,
        public const short VI_ASRL_PAR_EVEN = 2;                     //Even parity should be used,
        public const short VI_ASRL_PAR_MARK = 3;                     //Parity bit exists and is always 1,
        public const short VI_ASRL_PAR_SPACE = 4;                    //Parity bit exists and is always 0.

        public const short VI_ASRL_STOP_ONE = 10;                    //1 stop bit is used per frame,
        public const short VI_ASRL_STOP_ONE5 = 15;                   //1.5 stop bits are used per frame,
        public const short VI_ASRL_STOP_TWO = 20;                    //2 stop bits are used per frame.
        /********************************************* 公有[静态]属性 *********************************************/
        /// <summary>
        /// 支持同时连接的最大设备数量20
        /// </summary>
        public const int MAX_DEVICE_NUM = 20;
        /// <summary>
        /// 连接到USB的设备地址掩码
        /// </summary>
        public const string USB_DEVICE = "USB[0-9]*::?*INSTR";
        /// <summary>
        /// 连接到串口的设备地址掩码
        /// </summary>
        public const string UART_DEVICE = "ASRL[0-9]*::?*INSTR";
        /// <summary>
        /// 连接到GPIB的设备地址掩码
        /// </summary>
        public const string GPIB_DEVICE = "GPIB[0-9]*::?*INSTR";
        /// <summary>
        /// 连接到LAN的设备地址掩码
        /// </summary>
        public const string TCPIP_DEVICE = "TCPIP[0-9]*::?*INSTR";

        /// <summary>
        /// 设备信息列表，最多MAX_DEVICE_NUM个设备信息的二维表: [完整Visa地址，厂商信息，型号，序列号，版本号]
        /// </summary>
        public string[,] Devices = new string[20,5];



        /// <summary>
        /// 全部设备's 结构化信息
        /// </summary>
        public static ClassDeviceInfo[] DevicesInfo = new ClassDeviceInfo[MAX_DEVICE_NUM];
        /// <summary>
        /// 按照查找条件找到的设备数目
        /// </summary>
        public static int DeviceNum = 0;

        /// <summary>
        /// 按照查找条件找到的 有效设备数目
        /// </summary>
        public static int DeviceValiNum = 0;
    

        /// <summary>
        /// 当前选择的设备在Devices中的位置值
        /// </summary>
        public int DevSelect = -1;
        
        /********************************************* 公有方法 *********************************************/
        /// <summary>
        /// 根据设备地址或掩码查找已连接的Visa设备
        /// </summary>
        /// <param name="DeviceAddr"> 设备地址或设备地址掩码字符串，根据接口的掩码类型可以是USB_DEVICE/UART_DEVICE/GPIB_DEVICE/TCPIP_DEVICE, 参数可以省略表示查找所有visa设备 </param>
        public ClassVisa(string DeviceAddr = "?*")
        {
            RefreshRsc(DeviceAddr);
        }

        /// <summary>
        /// 主动根据设备地址或地址掩码刷新和查找设备
        /// </summary>
        /// <param name="DeviceAddr">设备地址或设备地址掩码字符串，根据接口的掩码类型可以是USB_DEVICE/UART_DEVICE/GPIB_DEVICE/TCPIP_DEVICE, 参数可以省略表示查找所有visa设备</param>
        /// <returns>返回找到的设备数目</returns>
        public int RefreshRsc(string DeviceAddr = "?*")
        {
            return _Visa_Init(DeviceAddr);
        }

        /// <summary>
        /// 析构函数完成文件保存
        /// </summary>
        ~ClassVisa()
        {
        }


        /********************************************* 私有属性 *********************************************/
        /// <summary>
        /// 资源管理器标识符 
        /// </summary>
        public static Int32 g_i32RsrcManager;


        public static void _Visa_Init()
        {
            viOpenDefaultRM(ref g_i32RsrcManager);
        }

        /// <summary>
        /// 类初始化处理，查找已连接设备。
        /// </summary>
        /// <param name="findMask">设备地址或掩码</param>
        /// <returns>找到的设备数目</returns>
        private int _Visa_Init(string findMask)
        {
            string strTemp = "";                
            Int32 fList = 0;                    
            Int32 retCount = 0;                 
            byte[] g_bpRsrcName = new byte[200];       
            string g_strCurrentDevice;         

            try
            {
                viOpenDefaultRM(ref g_i32RsrcManager);                         //引用资源名参数
                retCount = viFindRsrc(g_i32RsrcManager, findMask, ref fList, ref DeviceNum, g_bpRsrcName); //寻找现有设备连接方式，数量，名称等
                if (DeviceNum > MAX_DEVICE_NUM)
                {
                    DeviceNum = MAX_DEVICE_NUM;
                }

                if (DeviceNum > 0)                  
                {
                    strTemp = Encoding.ASCII.GetString(g_bpRsrcName);                   //提取资源名将资源名转化为字符串形式
                    g_strCurrentDevice = strTemp.Substring(0, strTemp.IndexOf('\0'));   //将设备资源名赋给g_strCurrentDevice

                    Devices[0, 0] = g_strCurrentDevice;

                    CVisa Dev = new CVisa(g_strCurrentDevice);
                    string[] TempArrey = Dev._GetDevIdnInfo(g_strCurrentDevice);
                    int TempCnt = 1;
                    foreach (string Temp in TempArrey)
                    {
                        Devices[0, TempCnt] = Temp;
                        TempCnt++;
                    }

                    for (int i = 1; i < DeviceNum; i++)                             //当连接设备数量大于1时，进行连续性寻找
                    {
                        retCount = viFindNext(fList, g_bpRsrcName);                     //将寻找到下一台设备资源
                        if (retCount >= 0)                                              //如果找到
                        {
                            strTemp = Encoding.ASCII.GetString(g_bpRsrcName);                    //提取资源名将资源名转化为字符串形式
                            g_strCurrentDevice = strTemp.Substring(0, strTemp.IndexOf('\0'));    //将设备资源名赋给g_strCurrentDevice

                            Devices[i, 0] = g_strCurrentDevice;
                            Dev = new CVisa(g_strCurrentDevice);
                            TempArrey = Dev._GetDevIdnInfo(g_strCurrentDevice);
                            TempCnt = 1;
                            foreach (string Temp in TempArrey)
                            {
                                Devices[i, TempCnt] = Temp;
                                TempCnt++;
                            }
                        }
                        else
                        { }
                    }
                }
                else    
                {
                    return 0;
                }

                //信息转换到结构化存储空间中
                for (int i = 0; i < DeviceNum; i++)
                {
                    DevicesInfo[i] = new ClassDeviceInfo();

                    if (Devices[i, 0] != null)
                    {
                        DevicesInfo[i].VisaAddr = Devices[i, 0];
                    }
                    if (Devices[i, 0] != null)
                    {
                        DevicesInfo[i].Manufactory = Devices[i, 1];
                    }
                    if (Devices[i, 0] != null)
                    {
                        DevicesInfo[i].Type = Devices[i, 2];
                    }                            
                    if (Devices[i, 0] != null)
                    {                    
                        DevicesInfo[i].Serial = Devices[i, 3];                        
                    }                     
                    if (Devices[i, 0] != null)
                    {
                        DevicesInfo[i].Version = Devices[i, 4];                        
                    }
                }
            }
            catch (Exception err)
            {
                //统一错误处理 error handling   
            }

            return DeviceNum;
        }
             

        /********************************************* DLL导入的方法 *********************************************/
        /// <summary>
        /// 查询VISA系统，进行资源定位
        /// </summary>
        /// <param name="sesn">输入，资源管理器标识符，由viOpenDefaultRM获得</param>
        /// <param name="expr">输入，资源名匹配的表达式</param>
        /// <param name="vi">输出，下一个资源管理器标识符，用于viFindNext</param>
        /// <param name="retCount">输出，设备数量</param>
        /// <param name="Desc">输出，资源名(VISA Address)，用于viOpen</param>
        /// <returns>错误码</returns>
        [DllImport("visa32.dll")]
        public static extern Int32 viFindRsrc(Int32 sesn, string expr, ref Int32 vi, ref Int32 retCount, byte[] Desc);

        //' ************************************************************************
        //' 函数功能：返回下一个查询操作查得的资源
        //' 主要参数：参数名      I/O         描述                 关系
        //'           vi          输入    下一个资源管理器标识符   由viFindRsrc获得
        //'           Desc        输出    资源名(VISA Address)    用于viOpen
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern Int32 viFindNext(Int32 vi, byte[] Desc);

        //' ************************************************************************
        //' 函数功能：打开资源管理器
        //' 主要参数：参数名      I/O         描述                 关系
        //'           sesn        输出    资源管理器标识符         用于viFindRsrc、viOpen
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern Int32 viOpenDefaultRM(ref Int32 sesn);

        //' ************************************************************************
        //' 函数功能：打开特定资源管理器的对话通道
        //' 主要参数：参数名      I/O         描述                 关系
        //'           sesn        输入    资源管理器标识符         由viOpenDefaultRM获得
        //'           viDesc      输入    资源名(VISA Address)    由viFindRsrc获得
        //'           mode        输入    资源存取锁定模式
        //'           timeout     输入    操作超时值
        //'           vi          输出    对话通道标识符           用于viClose、viVPrintf、viVScanf
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern Int32 viOpen(Int32 sesn, string viDexc, Int32 mode, Int32 timeout, ref Int32 vi);

        //' ************************************************************************
        //' 函数功能：关闭特定资源管理器的对话通道
        //' 主要参数：参数名      I/O         描述                 关系
        //'           vi          输入    对话通道标识符           由viOpen获得
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern Int32 viClose(Int32 vi);

        //' ************************************************************************
        //' 函数功能：按设定格式将数据传送到器件中
        //' 主要参数：参数名      I/O         描述                 关系
        //'           vi          输入    对话通道标识符           由viOpen获得
        //'           writeFmt    输入    发送命令内容
        //'           params      输入
        //' ************************************************************************
        [DllImport("visa32.dll" )]
        public static extern Int32 viVPrintf(Int32 vi, string writeFmt, Int32 para);
//' ************************************************************************
        //' 函数功能：将数据同步写入到器件中
        //' 主要参数：参数名      I/O         描述                 关系
        //'           vi          输入    对话通道标识符           由viOpen获得
        //'           writeFmt    输入    发送命令内容
        //'           params      输入
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern Int32 viWrite(Int32 vi, byte[] buf, Int32 count,Int32 retCount);
        //' ************************************************************************
        //' 函数功能：按设定格式从器件中读取数据
        //' 主要参数：参数名      I/O         描述                 关系
        //'           vi          输入    对话通道标识符           由viOpen获得
        //'           readFmt     输入
        //'           params      输入    读回内容
        //' ************************************************************************
        [DllImport("visa32.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 viScanf(Int32 vi, string readFmt,  byte[] para);
		//' 主要参数：参数名      I/O         描述                 关系
        //'           vi          输入    对话通道标识符           由viOpen获得
        //'           writeFmt    输入    发送命令内容
        //'           params      输入
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern Int32 viRead(Int32 vi, byte[] buf, Int32 count, out Int32 retCount);

        //' ************************************************************************
        //' 函数功能：设置串口的属性
        //' 主要参数：参数名       I/O         描述                 关系
        //'           vi          输入    对话通道标识符           由viOpen获得
        //'           attrName    输入    设置项类型
        //'           attrValue   输入    属性值，byte型
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern int viSetAttribute(int vi, int attrName, byte attrValue);
        //' ************************************************************************
        //' 函数功能：设置串口的属性
        //' 主要参数：参数名       I/O         描述                 关系
        //'           vi          输入    对话通道标识符           由viOpen获得
        //'           attrName    输入    设置项类型
        //'           attrValue   输入    属性值，short型
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern int viSetAttribute(int vi, int attrName, short attrValue);
        //' ************************************************************************
        //' 函数功能：设置串口的属性
        //' 主要参数：参数名       I/O         描述                 关系
        //'           vi          输入    对话通道标识符           由viOpen获得
        //'           attrName    输入    设置项类型
        //'           attrValue   输入    属性值，int型
        //' ************************************************************************
        [DllImport("visa32.dll")]
        public static extern int viSetAttribute(int vi, int attrName, int attrValue);

        
    }
}

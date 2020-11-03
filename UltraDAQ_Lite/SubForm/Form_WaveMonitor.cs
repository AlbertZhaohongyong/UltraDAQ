using ClassLibrary_ThreadManage;
using LibVisa;
using saker_Winform.Global;
using saker_Winform.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UltraDAQ_Lite.SubForm
{
    public partial class Form_WaveMonitor : Form
    {
        #region 字段/属性
        private bool bCollect = false;//开始采集
        public bool bUpdate { get; set; }//获取内存数据
        private Task collectTask;//采集Task
        private CancellationTokenSource collectTaskCancel = new CancellationTokenSource();//采集令牌取消标志     
        private delegate void Painting(string seriesName, double[] doubleYData);//绘图委托
        private delegate void ClearPaint();//清空绘图
        private delegate void FinishTask();//结束Task
        private delegate void updateChart();//绘图委托
        static Semaphore sema_1 = new Semaphore(0, 1);// 用于线程同步
        static Semaphore sema_2 = new Semaphore(0, 1);// 用于线程同步
        private static object objlock = new object();

        #endregion
        public Form_WaveMonitor()
        {
            InitializeComponent();
        }

        private void Form_WaveMonitor_Load(object sender, EventArgs e)
        {
            InitChart();
        }

        /// <summary>
        /// 初始化图表
        /// </summary>
        public void InitChart()
        {
            //初始化绘图区域
            this.chart_WaveDate.ChartAreas[0].BackColor = Color.FromArgb(0x87, 0xCC, 0xFF, 0xFF);
            this.chart_WaveDate.Series.Clear();

            this.chart_WaveDate.ChartAreas[0].CursorX.IsUserEnabled = true;
            this.chart_WaveDate.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            this.chart_WaveDate.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            this.chart_WaveDate.ChartAreas[0].CursorY.IsUserEnabled = true;
            this.chart_WaveDate.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            this.chart_WaveDate.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            //将滚动内嵌到坐标轴中
            this.chart_WaveDate.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            this.chart_WaveDate.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = true;
            // 设置滚动条的大小
            this.chart_WaveDate.ChartAreas[0].AxisX.ScrollBar.Size = 10;
            this.chart_WaveDate.ChartAreas[0].AxisY.ScrollBar.Size = 10;
            // 设置滚动条的按钮的风格，将所有滚动条上的按钮显示出来
            this.chart_WaveDate.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            this.chart_WaveDate.ChartAreas[0].AxisY.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            // 设置自动放大与缩小的最小量
            this.chart_WaveDate.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            this.chart_WaveDate.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
            this.chart_WaveDate.ChartAreas[0].AxisY.ScaleView.SmallScrollSize = double.NaN;
            this.chart_WaveDate.ChartAreas[0].AxisY.ScaleView.SmallScrollMinSize = 1;

            for (int i = 0; i < Module_DeviceManage.Instance.Devices.Count; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    this.chart_WaveDate.Series.Add(Module_DeviceManage.Instance.Devices[i].Name + "_" + "CHAN" + j.ToString());
                    this.chart_WaveDate.Series[Module_DeviceManage.Instance.Devices[i].Name + "_" + "CHAN" + j.ToString()].ChartType = SeriesChartType.Line;
                }

            }
        }

        #region 方法：结束绘图Task
        public void FinishPaintingTask()
        {
            sema_1.WaitOne();
            collectTaskCancel.Cancel();
            collectTask.Wait();
            collectTaskCancel.Dispose();
            collectTaskCancel = new CancellationTokenSource();
            this.iconButton_Collect.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.iconButton_Collect.IconColor = Color.Green;
            this.bCollect = false;
        }
        #endregion

        private void PaintSeries(string seriesName, double[] doubleYData)
        {
            try
            {
                if (this.chart_WaveDate.InvokeRequired)
                {
                    Painting painting = new Painting(PaintSeries);
                    this.chart_WaveDate.Invoke(painting, seriesName, doubleYData);
                }
                else
                {
                    this.chart_WaveDate.Series[seriesName].Points.DataBindY(doubleYData);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void getData(CancellationToken collectToken)
        {
            while (true)
            {
                this.getPscreenWaveDataTaskScheduler(true);
                if (bCollect == false)
                {
                    sema_1.Release();
                }
                if (collectToken.IsCancellationRequested)
                {
                    return;
                }
            }
        }

        private void ClearChart()
        {
            if (this.InvokeRequired)
            {
                ClearPaint clearPaint = new ClearPaint(ClearChart);
                this.Invoke(clearPaint);
            }
            else
            {
                for (int i = 0; i < Module_DeviceManage.Instance.Devices.Count; i++)
                {
                    for (int j = 1; j < 5; j++)
                    {
                        this.chart_WaveDate.Series[Module_DeviceManage.Instance.Devices[i].Name + "_" + "CHAN" + j.ToString()].Points.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// /*创建线程池*/
        /// </summary>
        private void getPscreenWaveDataTaskScheduler(bool bBlock)
        {
            //ClearChart();
            LimitedConcurrencyLevelTaskScheduler lcts = new LimitedConcurrencyLevelTaskScheduler();
            List<Task> tasks = new List<Task>();
            // Create a TaskFactory and pass it our custom scheduler. 
            TaskFactory factory = new TaskFactory(lcts);
            CancellationTokenSource cts = new CancellationTokenSource();//取消线程

            // Use our factory to run a set of tasks. 
            Object lockObj = new Object();

            for (int tCtr = 0; tCtr < Module_DeviceManage.Instance.Devices.Count; tCtr++)
            {
                int iteration = tCtr;
                Module_Device module_Device = Module_DeviceManage.Instance.Devices[iteration];
                if (module_Device.deviceVisa == null)
                {
                    module_Device.deviceVisa = new CVisa(module_Device.visaResource, 5000);
                }
                Task t = factory.StartNew(() =>
                {
                    try
                    {
                        string cmd;
                        byte[] command;
                        cmd = CGlobalCmd.STR_CMD_SET_RUN;
                        command = Encoding.Default.GetBytes(cmd + "\n");
                        module_Device.deviceVisa.WriteBytes(command, command.Length);
                        Thread.Sleep(10);
                        for (int i = 1; i < 5; i++)
                        {
                            cmd = CGlobalCmd.STR_CMD_SET_CHANSOURCE;
                            cmd = cmd.Replace("<n>", i.ToString());
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(100);
                            cmd = CGlobalCmd.STR_CMD_SET_READMODENOR + ";" + CGlobalCmd.STR_CMD_SET_READTYPE;
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(100);
                            cmd = CGlobalCmd.STR_CMD_GET_READDATA;
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(200);

                            //回读屏幕点
                            byte[] DataTemp = new byte[1024];
                            byte[] DataScreen = new byte[1000 + 12];
                            var startIndex = 0;
                            var dataLength = 0;
                            int headerCount = 0;
                            do
                            {
                                int readLength = module_Device.deviceVisa.ReadBytes(DataTemp);
                                if (readLength == 0)
                                {
                                    break;
                                }
                                if (startIndex == 0)
                                {
                                    var N = DataTemp[1] - '0';
                                    headerCount = N + 2;
                                    dataLength = Convert.ToInt32(Encoding.ASCII.GetString(DataTemp, 2, N)) + headerCount + 1;
                                }
                                // cpy data
                                Buffer.BlockCopy(DataTemp, 0, DataScreen, startIndex, readLength);
                                startIndex += readLength;
                            } while (startIndex < dataLength);

                            //获取波形参数PREamble
                            cmd = CGlobalCmd.STR_CMD_GET_WAVEPARASALL;
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(200);
                            byte[] DataPREamble = new byte[1024];
                            int readLengthPREamble = module_Device.deviceVisa.ReadBytes(DataPREamble, 1024);
                            string result = Encoding.Default.GetString(DataPREamble, 0, readLengthPREamble);
                            string[] res = result.TrimEnd(Environment.NewLine.ToCharArray()).Split(',');
                            module_Device.Channels[i - 1].XIncrement = res[4].ToString();
                            module_Device.Channels[i - 1].XOrigin = res[5].ToString();
                            module_Device.Channels[i - 1].XReference = res[6].ToString();
                            module_Device.Channels[i - 1].YIncrement = res[7].ToString();
                            module_Device.Channels[i - 1].YOrigin = res[8].ToString();
                            module_Device.Channels[i - 1].YReference = res[9].ToString();

                            //计算实际电压值
                            DataScreen = DataScreen.Skip(12).ToArray();
                            double[] doubleYData = new double[DataScreen.Length];
                            for (int j = 0; j < DataScreen.Length; j++)
                            {
                                doubleYData[j] = (double)(DataScreen[j] - (double.Parse(module_Device.Channels[i - 1].YOrigin) + double.Parse(module_Device.Channels[i - 1].YReference))) * double.Parse(module_Device.Channels[i - 1].YIncrement);
                            }
                            PaintSeries(module_Device.Name + "_" + "CHAN" + i.ToString(), doubleYData);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        module_Device.deviceVisa.Close();
                        module_Device.deviceVisa = null;
                    }

                }, cts.Token);
                tasks.Add(t);
            }
            // Wait for the tasks to complete before displaying a completion message.
            if (bBlock)
            {
                Task.WaitAll(tasks.ToArray());
            }
            cts.Dispose();
#if Debug
            Console.WriteLine("\n\nSuccessful completion.");
#endif
        }



        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void iconButton_Run_Click(object sender, EventArgs e)
        {
            if (this.iconButton_Collect.IconChar == FontAwesome.Sharp.IconChar.Play)
            {
                this.iconButton_Collect.IconChar = FontAwesome.Sharp.IconChar.Stop;
                this.iconButton_Collect.IconColor = Color.Red;
                this.bCollect = true;
                this.bUpdate = false;
            }
            else
            {
                this.iconButton_Collect.IconChar = FontAwesome.Sharp.IconChar.Play;
                this.iconButton_Collect.IconColor = Color.Green;
                this.bCollect = false;
                this.bUpdate = false;
            }
            if (bCollect)
            {
                ClassVisa._Visa_Init();//初始化句柄
                CancellationToken collectToken = collectTaskCancel.Token;//令牌
                collectTask = new Task(() => { getData(collectToken); }, collectToken);//新建循环测试任务
                try
                {
                    collectTask.Start();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n OperationCanceledException：{0}\n", ex.Message);
                }
            }
            else
            {
                //结束屏幕绘制线程
                Task.Run(() => FinishPaintingTask());
            }

        }

        /// <summary>
        /// 手动获取内存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iconButton_Update_Click(object sender, EventArgs e)
        {
            if (!Form_DeviceConfig.bConfig)
            {
                MessageBox.Show("Please click the Apply button!");
                return;
            }
            //结束屏幕绘制线程
            bool bWaiting = false;
            if (bCollect)
            {
                bCollect = false;
                bWaiting = true;
                this.iconButton_Collect.IconChar = FontAwesome.Sharp.IconChar.Play;
                this.iconButton_Collect.IconColor = Color.Green;
                Task.Run(() => 
                {
                    sema_1.WaitOne();
                    collectTaskCancel.Cancel();
                    collectTask.Wait();
                    collectTaskCancel.Dispose();
                    collectTaskCancel = new CancellationTokenSource();
                    sema_2.Release();
                });
            }

            Task.Run(() => {
                Form_Progressbar form_Progressbar = new Form_Progressbar();
                /* 开启进度条 */
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                cancelTokenSource.Token.Register(() =>
                {
                    form_Progressbar.CloseProcess();//委托方法调用进度条关闭                
                    DialogResult res = MessageBox.Show("Paint Completed", "Paint", MessageBoxButtons.OK);
                    if (res == DialogResult.OK)
                    {
                        //RaiseEvent("ProcessClose");
                        return;
                    }
                });
                Task.Run(() =>
                {
                    form_Progressbar.ProcessMarquee("Painting...");//设置进度条显示为左右转动
                    form_Progressbar.StartPosition = FormStartPosition.CenterScreen;//程序中间
                    form_Progressbar.ShowDialog();
                }, cancelTokenSource.Token);
                bUpdate = true;
                ClearChart();
                if (bWaiting == true)
                {
                    sema_2.WaitOne();
                }
                //并行执行，Stop获取内存数据
                Parallel.For(0, Module_DeviceManage.Instance.Devices.Count, item =>
                {             
                    int iteration = item;
                    Module_Device module_Device = Module_DeviceManage.Instance.Devices[iteration];
                    if (module_Device.deviceVisa != null)
                    {
                        module_Device.deviceVisa.Close();
                    }
                    try
                    {
                        module_Device.deviceVisa = new CVisa(module_Device.visaResource, 5000);
                        // 开启Stop，读取内存波形
                        string cmd = CGlobalCmd.STR_CMD_SET_STOP + "\n";
                        byte[] command = Encoding.Default.GetBytes(cmd);
                        module_Device.deviceVisa.WriteBytes(command, command.Length);
                        Thread.Sleep(200);

                        // 读取四个通道的内存数据
                        for (int i = 1; i < 5; i++)
                        {
                            cmd = CGlobalCmd.STR_CMD_SET_CHANSOURCE;
                            cmd = cmd.Replace("<n>", i.ToString());
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(50);
                            cmd = CGlobalCmd.STR_CMD_SET_READMODE + ";" + CGlobalCmd.STR_CMD_SET_READTYPE;
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(50);
                            cmd = CGlobalCmd.STR_CMD_SET_READPOINT + Module_DeviceManage.Instance.Points.ToString();
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(100);
                            cmd = CGlobalCmd.STR_CMD_GET_READDATA;
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(200);

                            //回读内存点
                            byte[] Data = new byte[Module_DeviceManage.Instance.Points + 12];
                            byte[] DataTemp = new byte[6144];
                            var startIndex = 0;
                            var dataLength = 0;
                            int headerCount = 0;
                            int readLength = 0;
                            do
                            {
                                readLength = module_Device.deviceVisa.ReadBytes(DataTemp, DataTemp.Length);//此句需要加偏移
                                if (readLength == 0)
                                {
                                    break;
                                }
                                if (startIndex == 0)
                                {
                                    var N = DataTemp[1] - '0';
                                    headerCount = N + 2;
                                    dataLength = Convert.ToInt32(Encoding.ASCII.GetString(DataTemp, 2, N)) + headerCount + 1;
                                }
                                // cpy data
                                Buffer.BlockCopy(DataTemp, 0, Data, startIndex, readLength);
                                startIndex += readLength;
                            } while (startIndex < dataLength);

                            Data = Data.Skip(12).ToArray();
                            Thread.Sleep(1000);

                            //获取波形参数PREamble
                            cmd = CGlobalCmd.STR_CMD_GET_WAVEPARASALL;
                            command = Encoding.Default.GetBytes(cmd + "\n");
                            module_Device.deviceVisa.WriteBytes(command, command.Length);
                            Thread.Sleep(50);
                            byte[] DataPREamble = new byte[1024];
                            int readLengthPREamble = module_Device.deviceVisa.ReadBytes(DataPREamble, 1024);
                            string result = Encoding.Default.GetString(DataPREamble, 0, readLengthPREamble);
                            string[] res = result.TrimEnd(Environment.NewLine.ToCharArray()).Split(',');
                            module_Device.Channels[i - 1].XIncrement = res[4].ToString();
                            module_Device.Channels[i - 1].XOrigin = res[5].ToString();
                            module_Device.Channels[i - 1].XReference = res[6].ToString();
                            module_Device.Channels[i - 1].YIncrement = res[7].ToString();
                            module_Device.Channels[i - 1].YOrigin = res[8].ToString();
                            module_Device.Channels[i - 1].YReference = res[9].ToString();


                            double[] doubleData = new double[Data.Length];
                            for (int j = 0; j < Data.Length; j++)
                            {
                                doubleData[j] = (double)(Data[j] - (double.Parse(module_Device.Channels[i - 1].YOrigin) + double.Parse(module_Device.Channels[i - 1].YReference))) * double.Parse(module_Device.Channels[i - 1].YIncrement);
                            }
                            module_Device.Channels[i - 1].SetData(Data, 0, Data.Length);
                            module_Device.Channels[i - 1].SetDoubleData(doubleData, 0, Data.Length);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                });
                PaintMemorySeries();
                cancelTokenSource.Cancel();
            });
        }

        private void PaintMemorySeries()
        {
            Debug.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));
            if (this.chart_WaveDate.InvokeRequired)
            {
                updateChart updatechart = new updateChart(PaintMemorySeries);
                this.chart_WaveDate.Invoke(updatechart);
            }
            else
            {
                foreach (var item in Module_DeviceManage.Instance.Devices)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        double[] doubleDataMem = new double[Module_DeviceManage.Instance.Points];
                        Array.Copy(item.Channels[i - 1].doubleData, doubleDataMem, Module_DeviceManage.Instance.Points);
                        this.chart_WaveDate.Series[item.Name + "_" + "CHAN" + i.ToString()].Points.DataBindY(doubleDataMem);
                    }
                }
            }
            
            Debug.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff"));
        }

        private void iconButton_Save_Click(object sender, EventArgs e)
        {
            if (this.bUpdate)
            {
                this.folderBrowserDialog1.ShowDialog();
                string filePath = folderBrowserDialog1.SelectedPath;
                Parallel.For(0, Module_DeviceManage.Instance.Devices.Count, item =>
                {
                    int iteration = item;
                    Module_Device module_Device = Module_DeviceManage.Instance.Devices[iteration];
                    // 读取四个通道的内存数据
                    for (int i = 1; i < 5; i++)
                    {
                        string path = filePath + "\\" + DateTime.Now.ToString("yyyyMM_ddHHmmss") + module_Device.Name + "CHAN" + i.ToString() + ".csv";
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        string para = " Xincrement =" + module_Device.Channels[i - 1].XIncrement.ToString() +
               " Xreference =" + module_Device.Channels[i - 1].XReference.ToString() +
               " Xorigin =" + module_Device.Channels[i - 1].XOrigin.ToString() +
               " Yincrement =" + module_Device.Channels[i - 1].YIncrement.ToString() +
               " Yreference =" + module_Device.Channels[i - 1].YReference.ToString() +
               " Yorigin =" + module_Device.Channels[i - 1].YOrigin.ToString();
                        using (FileStream csvFs = new FileStream(path, FileMode.Create))
                        {
                            using (StreamWriter csvSw = new StreamWriter(csvFs, System.Text.Encoding.Default))
                            {
                                int j = 0;
                                csvSw.WriteLine(para);
                                while (j < Module_DeviceManage.Instance.Points)
                                {
                                    csvSw.WriteLine(module_Device.Channels[i - 1].Data[j]);
                                    j++;
                                }
                                csvSw.Flush();
                                //关闭流
                                csvSw.Close();
                                csvFs.Close();
                            }
                        }

                    }
                });
                MessageBox.Show("Save successfully!");
            }
            else
            {
                MessageBox.Show("Only memory data is allowed to be saved,please click Update to get" +
                    "the data and then click Save.");
            }
        }
    }
}

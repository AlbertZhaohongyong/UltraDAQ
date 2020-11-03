using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saker_Winform.Module
{
    public class Module_Channel
    {
        public string GUID { get; set; }
        public int ChannelID { get; set; }
        public bool Collect { get; set; }
        public bool Valid { get; set;}
        public bool Open { get; set; }

        public  byte[] Data = new byte[1000000 + 12];//4通道模式的125M

        public double[] doubleData = new double[1000000 + 12];

        public string XIncrement { get; set; } // X 方向上相邻两点的时间差
        public string XOrigin { get; set; }//X方向上的起始时间
        public string XReference { get; set; } //X方向上数据的参考时间基准
        public string YIncrement { get; set; }  //Y方向上波形的步进值
        public string YOrigin { get; set; } //Y方向上相对于垂直参考位置的垂直偏移
        public string YReference { get; set; } //Y方向的垂直参考位置
        public Module_Channel()
        {
            GUID = Guid.NewGuid().ToString();
        }
        public byte[] GetData()
        {           
            return Data;
        }
        public void SetData(byte[] data,int offset,int length)
        {
            //Array.Clear(Data,0,Data.Length);
            Array.Copy(data, offset, Data, 0, length);           
        }

        public double[] GetDoubleData()
        {
            return doubleData;
        }
        public void SetDoubleData(double[] doubledata, int offset, int length)
        {
            //Array.Clear(Data,0,Data.Length);
            Array.Copy(doubledata, offset, doubleData, 0, length);
        }
        public Module_Channel(int i)
        {
            ChannelID = i;
        }
        public string Tag { get; set; }//tag
        public string TagDesc { get; set; }//tag注释类型
        public string Scale { get; set; }
        public string Offset { get; set; }
        public string Impedance { get; set; }//阻抗
        public string Coupling { get; set; }//耦合
        public string ProbeRatio { get; set; }//探头比
        public bool BChanInv { get; set; }//通道是否反向
        public bool BChanBWLimit { get; set; }//通道是否带宽限制
        public bool BChanImpedence { get; set; }//通道是否高阻       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saker_Winform.CommonBaseModule
{
    class CUnitTransform
    {

        /// <summary>
        /// 根据索引检测单位，进行转换
        /// </summary>
        /// <param name="comboBox"></param>
        /// <returns></returns>
       public static string UnitTransF(System.Windows.Forms.ComboBox comboBox,System.Windows.Forms.TextBox textBox)
        {
            switch(comboBox.SelectedIndex)
            {
                case 0:
                    return textBox.Text;              
                case 1:
                    return (Double.Parse(textBox.Text) / 1000).ToString();                
                case 2:
                    return (Double.Parse(textBox.Text) / 1000000).ToString();
                case 3:
                    return (Double.Parse(textBox.Text) / 1000000000).ToString();
                case 4:
                    return (Double.Parse(textBox.Text) / 1000000000000).ToString();
                default:
                    return textBox.Text;                
            }
        }     
    }
}

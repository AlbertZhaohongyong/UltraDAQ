using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saker_Winform.CommonBaseModule
{
    class CControlProp
    {
        /// <summary>
        /// 方法：传入R,G,B的值
        /// </summary>
        /// <param name="button"></param>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        public static void ButtonBackColor(System.Windows.Forms.Button button,int R,int G,int B)
        {
            button.BackColor = Color.FromArgb(R, G, B);//仪器配置按钮变色        
        }

        #region 方法：设置右侧字体大小及加粗
        /// <summary>
        /// 方法：设置右侧字体大小及加粗
        /// </summary>
        /// <param name="bool1"></param>
        /// <param name="button1"></param>
        public static void SetButtonProp(bool bool1, System.Windows.Forms.Button button1)
        {
            if (bool1)
            {
                button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            }
            else
            {
                button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular);
            }

        }
        #endregion



    }
}

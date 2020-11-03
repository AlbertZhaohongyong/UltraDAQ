using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace saker_Winform.CommonBaseModule
{
    class CString2Value
    {
        /// <summary>
        /// 内存深度转数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int meDepth2Value(string strValue)
        {
            int result = 0;
            strValue = strValue.ToUpper();
            if (strValue.Contains("M"))
            {
                int temp = Convert.ToInt32(strValue.Replace("M", ""));
                result = temp * 1000000;
            }
            else if (strValue.Contains("K"))
            {
                int temp = Convert.ToInt32(strValue.Replace("K", ""));
                result = temp * 1000;
            }
            return result;
        }
    }
}

using saker_Winform.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary_ThreadManage;
namespace saker_Winform.CommonBaseModule
{
    public class MutipleThreadSendCmd
    {
        private  Module_Device _Device;
        public Module_Device GetDevice()
        {
            return _Device;
        }
        public void SetDevice(Module_Device device)
        {
            _Device = device;
        }
        public MutipleThreadResetEvent MTREvent;

    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace vip_vp.Support.Pins
{
    public abstract class BasePin
    {
        public abstract object Value { get; set; }
        public abstract Task Run();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace vip_vp.Support.Pins
{
    public class LiteralPin : BasePin
    {
        public override object Value { get; set; }

        public override Task Run() => Task.CompletedTask;
    }
}

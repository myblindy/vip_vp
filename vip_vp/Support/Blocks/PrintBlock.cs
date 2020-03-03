using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vip_vp.Support.Pins;

namespace vip_vp.Support.Blocks
{
    public class PrintBlock : BaseBlock
    {
        public BasePin InputPin { get; set; }

        public override async Task Run() =>
            Console.WriteLine(InputPin.Value);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vip_vp.Support.Pins;

namespace vip_vp.Support.Blocks
{
    public class AddBlock : BaseBlock
    {
        public BaseBlock NextBlock { get; set; }

        public LiteralPin InputPin1 { get; set; }
        public LiteralPin InputPin2 { get; set; }
        public LiteralPin OutputPin { get; set; } = new LiteralPin();

        public override async Task Run()
        {
            OutputPin.Literal = (dynamic)InputPin1.Literal + InputPin2.Literal;
        }
    }
}

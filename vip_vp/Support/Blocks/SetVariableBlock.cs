using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using vip_vp.Support.Blocks.Attributes;
using vip_vp.Support.Pins;

namespace vip_vp.Support.Blocks
{
    public class SetVariableBlock : BaseBlock
    {
        public BaseBlock NextBlock { get; set; }

        [InputPin]
        public BasePin InputPin { get; set; }

        [OutputPin]
        public VariablePin OutputPin { get; set; }

        public override async Task Run()
        {
            await InputPin.Run();
            OutputPin.Value = InputPin.Value;

            if (!(NextBlock is null))
                await NextBlock.Run();
        }
    }
}

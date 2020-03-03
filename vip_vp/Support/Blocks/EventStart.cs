using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace vip_vp.Support.Blocks
{
    public class EventStart : BaseBlock
    {
        public BaseBlock NextBlock { get; set; }

        public override Task Run() => NextBlock is null ? Task.CompletedTask : NextBlock.Run();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vip_vp.Support.Blocks;

namespace vip_vp.Support.State
{
    public class Machine
    {
        public Dictionary<string, object> Variables { get; } = new Dictionary<string, object>();
        public EventStart OnInitializeEvent { get; } = new EventStart();
        public EventStart OnUpdateEvent { get; } = new EventStart();

        public async Task Run(bool firstTick)
        {
            if (firstTick)
                await OnInitializeEvent.Run();
            else
                await OnUpdateEvent.Run();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vip_vp.Support.State;

namespace vip_vp.Support.Blocks
{
    public class QuitBlock : BaseBlock
    {
        private readonly Machine Machine;
        public QuitBlock(Machine m) => Machine = m;

        public override async Task Run() => Machine.Quit();
    }
}

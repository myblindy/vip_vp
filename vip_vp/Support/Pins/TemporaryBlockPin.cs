using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vip_vp.Support.Blocks;

namespace vip_vp.Support.Pins
{
    class TemporaryBlockPin<T> : BasePin where T : BaseBlock
    {
        readonly T Block;
        readonly Func<T, BasePin> PinSelector;

        public TemporaryBlockPin(T block, Func<T, BasePin> pin)
        {
            Block = block;
            PinSelector = pin;
        }

        public override Task Run() => Block.Run();

        public override object Value
        {
            get => PinSelector(Block).Value;
            set => throw new NotImplementedException();
        }
    }
}

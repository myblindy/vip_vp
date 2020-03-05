using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vip_vp.Support.Pins;

namespace vip_vp.Support.Blocks
{
    public class BatchedForRangeBlock : BaseBlock
    {
        public BasePin FromInputPin { get; set; }
        public BasePin ToInputPin { get; set; }
        public BasePin IncrementInputPin { get; set; }
        public BasePin BatchSizeInputPin { get; set; }

        public LiteralPin IndexOutputPin { get; set; } = new LiteralPin();

        public BaseBlock LoopBlock { get; set; }
        public BaseBlock NextBlock { get; set; }

        bool First = true, End;

        public override async Task Run()
        {
            endCheck:
            if (End)
            {
                if (!(NextBlock is null))
                    await NextBlock.Run();
                return;
            }

            if (First)
            {
                First = false;
                await FromInputPin.Run();
                IndexOutputPin.Value = FromInputPin.Value;
            }

            await BatchSizeInputPin.Run();
            var batchCount = Convert.ToInt64(BatchSizeInputPin.Value);

            while (batchCount-- > 0)
            {
                await ToInputPin.Run();
                if ((dynamic)IndexOutputPin.Value > (dynamic)ToInputPin.Value)
                {
                    End = true;
                    goto endCheck;
                }

                if (!(LoopBlock is null))
                    await LoopBlock.Run();

                await IncrementInputPin.Run();
                IndexOutputPin.Value = (dynamic)IndexOutputPin.Value + (dynamic)IncrementInputPin.Value;
            }
        }
    }
}

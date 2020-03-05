

using System.Threading.Tasks;
using vip_vp.Support.Pins;

namespace vip_vp.Support.Blocks
{
			public class AddBlock : BaseBlock
		{
			public BasePin InputPin1 { get; set; }
			public BasePin InputPin2 { get; set; }
            
			public LiteralPin OutputPin { get; } = new LiteralPin();

			public override async Task Run() 
            {
                await InputPin1.Run();
                await InputPin2.Run();

                OutputPin.Value = (dynamic)InputPin1.Value + (dynamic)InputPin2.Value;
            }
		}
			public class SubtractBlock : BaseBlock
		{
			public BasePin InputPin1 { get; set; }
			public BasePin InputPin2 { get; set; }
            
			public LiteralPin OutputPin { get; } = new LiteralPin();

			public override async Task Run() 
            {
                await InputPin1.Run();
                await InputPin2.Run();

                OutputPin.Value = (dynamic)InputPin1.Value - (dynamic)InputPin2.Value;
            }
		}
			public class MultiplyBlock : BaseBlock
		{
			public BasePin InputPin1 { get; set; }
			public BasePin InputPin2 { get; set; }
            
			public LiteralPin OutputPin { get; } = new LiteralPin();

			public override async Task Run() 
            {
                await InputPin1.Run();
                await InputPin2.Run();

                OutputPin.Value = (dynamic)InputPin1.Value * (dynamic)InputPin2.Value;
            }
		}
	
    public class DivideBlock : BaseBlock
    {
        public BasePin InputPin1 { get; set; }
        public BasePin InputPin2 { get; set; }

        public LiteralPin QuotientOutputPin { get; } = new LiteralPin();
        public LiteralPin RemainderOutputPin { get; } = new LiteralPin();

        public override async Task Run()
        {
            await InputPin1.Run();
            await InputPin2.Run();

            dynamic val1 = InputPin1.Value, val2 = InputPin2.Value;
            if (!(QuotientOutputPin is null))
                QuotientOutputPin.Value = val1 / val2;
            if (!(RemainderOutputPin is null))
                RemainderOutputPin.Value = val1 % val2;
        }
    }

}
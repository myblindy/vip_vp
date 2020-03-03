

using System.Threading.Tasks;
using vip_vp.Support.Pins;

namespace vip_vp.Support.Blocks
{
			public class AddBlock : BaseBlock
		{
			public BaseBlock NextBlock { get; set; }

			public BasePin InputPin1 { get; set; }
			public BasePin InputPin2 { get; set; }
			public VariablePin OutputPin { get; set; }

			public override async Task Run()
			{
				OutputPin.Value = (dynamic)InputPin1.Value + (dynamic)InputPin2.Value;
				await NextBlock?.Run();
			}
		}
			public class SubtractBlock : BaseBlock
		{
			public BaseBlock NextBlock { get; set; }

			public BasePin InputPin1 { get; set; }
			public BasePin InputPin2 { get; set; }
			public VariablePin OutputPin { get; set; }

			public override async Task Run()
			{
				OutputPin.Value = (dynamic)InputPin1.Value - (dynamic)InputPin2.Value;
				await NextBlock?.Run();
			}
		}
			public class MultiplyBlock : BaseBlock
		{
			public BaseBlock NextBlock { get; set; }

			public BasePin InputPin1 { get; set; }
			public BasePin InputPin2 { get; set; }
			public VariablePin OutputPin { get; set; }

			public override async Task Run()
			{
				OutputPin.Value = (dynamic)InputPin1.Value * (dynamic)InputPin2.Value;
				await NextBlock?.Run();
			}
		}
	
    public class DivideBlock : BaseBlock
    {
        public BaseBlock NextBlock { get; set; }

        public BasePin InputPin1 { get; set; }
        public BasePin InputPin2 { get; set; }
        public VariablePin QuotientOutputPin { get; set; }
        public VariablePin RemainderOutputPin { get; set; }

        public override async Task Run()
        {
            dynamic val1 = InputPin1.Value, val2 = InputPin2.Value;
            if (!(QuotientOutputPin is null))
                QuotientOutputPin.Value = val1 / val2;
            if (!(RemainderOutputPin is null))
                RemainderOutputPin = val1 % val2;
            await NextBlock?.Run();
        }
    }

}
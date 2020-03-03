using System;
using System.Threading.Tasks;
using vip_vp.Support.Blocks;
using vip_vp.Support.Pins;
using vip_vp.Support.State;

namespace vip_vp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var m = new Machine
            {
                Variables =
                {
                    ["i"] = 15,
                },
            };

            m.OnUpdateEvent.NextBlock = new AddBlock
            {
                InputPin1 = new VariablePin(m) { VariableName = "i" },
                InputPin2 = new LiteralPin { Value = 10 },
                OutputPin = new VariablePin(m) { VariableName = "i" },

                NextBlock = new PrintBlock
                {
                    InputPin = new VariablePin(m) { VariableName = "i" },
                }
            };

            await m.Run(true);

            var last = DateTime.MinValue;
            while (true)
            {
                while ((DateTime.Now - last).TotalMilliseconds < 16.6) { }
                last = DateTime.Now;

                await m.Run(false);
            }
        }
    }
}

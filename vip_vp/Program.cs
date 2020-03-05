using System;
using System.Diagnostics;
using System.Threading;
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

            //m.OnUpdateEvent.NextBlock = new SetVariableBlock
            //{
            //    InputPin = new TemporaryBlockPin<AddBlock>(new AddBlock
            //    {
            //        InputPin1 = new VariablePin(m) { VariableName = "i" },
            //        InputPin2 = new LiteralPin { Value = 10 },
            //    }, x => x.OutputPin),
            //    OutputPin = new VariablePin(m) { VariableName = "i" },
            //    NextBlock = new PrintBlock
            //    {
            //        InputPin = new VariablePin(m) { VariableName = "i" },
            //    },
            //};

            var loop = new BatchedForRangeBlock
            {
                FromInputPin = new LiteralPin { Value = 15 },
                ToInputPin = new LiteralPin { Value = 25 },
                IncrementInputPin = new LiteralPin { Value = .1 },
                BatchSizeInputPin = new LiteralPin { Value = int.MaxValue },

                LoopBlock = new PrintBlock
                {
                    NextBlock = new QuitBlock(m)
                },
            };
            ((PrintBlock)loop.LoopBlock).InputPin = loop.IndexOutputPin;
            m.OnUpdateEvent.NextBlock = loop;

            await m.Run(true);

            var sw = new Stopwatch();
            sw.Start();
            var nextMs = 16.6;

            while (!m.HasQuit)
            {
                Console.WriteLine("=====");

                while (true)
                {
                    var wait = nextMs - sw.ElapsedMilliseconds;
                    if (wait > 3)
                        Thread.Sleep(3);
                    else
                    {
                        while (nextMs - sw.ElapsedMilliseconds > 0.1) { }
                        break;
                    }
                }
                nextMs += 16.6;

                await m.Run(false);
            }
        }
    }
}

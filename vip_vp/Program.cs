using System;
using System.Threading.Tasks;
using vip_vp.Support.Blocks;
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
            
            var add=new AddBlock
            {
                
            }

            await m.Run(true);

            var last = DateTime.MinValue;
            while (true)
            {
                var now = DateTime.Now;
                while ((now - last).Milliseconds < 16.6) { }

                await m.Run(false);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using vip_vp.Support.State;

namespace vip_vp.Support.Pins
{
    public class VariablePin : BasePin
    {
        public string VariableName { get; set; }
        public override object Value { get => Machine.Variables[VariableName]; set => Machine.Variables[VariableName] = value; }

        private readonly Machine Machine;

        public VariablePin(Machine m) => Machine = m;

        public override Task Run() => Task.CompletedTask;
    }
}

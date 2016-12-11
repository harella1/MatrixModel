using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Builder
{
    public class AppleBuilder : ComputerBuilder
    {
        public AppleBuilder()
        {
            Computer = new Computer(ComputerTyp.Apple);
        }

        public override void BuildMotherboard()
        {
            Computer.MotherBoard = "iMac G5 PowerPC";
        }

        public override void BuildProcessor()
        {
            Computer.Processor = "Intel Core 2 Duo";
        }

        public override void BuildHardDisk()
        {
            Computer.HardDisk = "320GB";
        }

        public override void BuildScreen()
        {
            Computer.Screen = "24 inch (1980 x 1200)";
        }
    }
}

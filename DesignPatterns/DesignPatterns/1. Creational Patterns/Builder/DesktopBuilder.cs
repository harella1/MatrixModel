using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Builder
{
    public class DesktopBuilder : ComputerBuilder
    {
        public DesktopBuilder()
        {
            Computer = new Computer(ComputerTyp.Desktop);
        }

        public override void BuildMotherboard()
        {
            Computer.MotherBoard = "Asus P6X58D Premium";
        }

        public override void BuildProcessor()
        {
            Computer.Processor = "Intel Xeon 7500";
        }

        public override void BuildHardDisk()
        {
            Computer.HardDisk = "2TB";
        }

        public override void BuildScreen()
        {
            Computer.Screen = "21 inch (1980 x 1200)";
        }
    }
}

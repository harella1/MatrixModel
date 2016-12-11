using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Builder
{
    public class ComputerShop
    {
        public void ConstructComputer(ComputerBuilder computerBuilder)
        {
            computerBuilder.BuildMotherboard();
            computerBuilder.BuildProcessor();
            computerBuilder.BuildHardDisk();
            computerBuilder.BuildScreen();
        }
    }
}

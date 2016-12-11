using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Builder
{
    public abstract class ComputerBuilder
    {
        public Computer Computer { get; set; }

        public abstract void BuildMotherboard();
        public abstract void BuildProcessor();
        public abstract void BuildHardDisk();
        public abstract void BuildScreen();
    }
}

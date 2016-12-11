using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Builder
{
    public class Computer
    {
        private ComputerTyp _computerTyp;

        public string MotherBoard { get; set; }
        public string Processor { get; set; }
        public string HardDisk { get; set; }
        public string Screen { get; set; }

        public Computer(ComputerTyp computerTyp)
        {
            _computerTyp = computerTyp;
        }

        public void DisplayConfiguration()
        {
            string message;

            message = string.Format("Computer: {0}", _computerTyp);
            Console.WriteLine(message);

            message = string.Format("Motherboard: {0}", MotherBoard);
            Console.WriteLine(message);

            message = string.Format("Processor: {0}", Processor);
            Console.WriteLine(message);

            message = string.Format("Harddisk: {0}", HardDisk);
            Console.WriteLine(message);

            message = string.Format("Screen: {0}", Screen);
            Console.WriteLine(message);

            Console.WriteLine();
        }
    }

    public enum ComputerTyp
    {
        Laptop,
        Desktop,
        Apple
    }
}

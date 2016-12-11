using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.AbstractFactory
{
    class MercedesFamilyCar : FamilyCar
    {
        public override void Speed(SportsCar abstractSportsCar)
        {
            Console.WriteLine(GetType().Name + " is slower than "
                + abstractSportsCar.GetType().Name);
        }
    }
}

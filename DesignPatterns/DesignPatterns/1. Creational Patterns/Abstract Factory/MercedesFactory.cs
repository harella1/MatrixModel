using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.AbstractFactory
{
    public class MercedesFactory : CarFactory
    {
        public override SportsCar CreateSportsCar()
        {
            return new MercedesSportsCar();
        }

        public override FamilyCar CreateFamilyCar()
        {
            return new MercedesFamilyCar();
        }
    }
}

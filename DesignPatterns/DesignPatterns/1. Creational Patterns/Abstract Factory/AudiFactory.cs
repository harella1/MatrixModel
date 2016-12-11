using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.AbstractFactory
{
    public class AudiFactory : CarFactory
    {
        public override SportsCar CreateSportsCar()
        {
            return new AudiSportsCar();
        }

        public override FamilyCar CreateFamilyCar()
        {
            return new AudiFamilyCar();
        }
    }
}

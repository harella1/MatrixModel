using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.AbstractFactory
{
    public class Driver
    {
        private CarFactory _carFactory;
        private SportsCar _sportsCar;
        private FamilyCar _familyCar;

        public Driver(CarFactory carFactory)
        {
            CarFactory = carFactory;
            SportsCar = CarFactory.CreateSportsCar();
            FamilyCar = CarFactory.CreateFamilyCar();
        }

        private CarFactory CarFactory
        {
            get { return _carFactory; }
            set { _carFactory = value; }
        }

        private SportsCar SportsCar
        {
            get { return _sportsCar; }
            set { _sportsCar = value; }
        }

        private FamilyCar FamilyCar
        {
            get { return _familyCar; }
            set { _familyCar = value; }
        }

        public void CompareSpeed()
        {
            FamilyCar.Speed(SportsCar);
        }
    }

    //// Language agnostic solution without the use of propoerties
    //public class Driver
    //{
    //    private SportsCar _sportsCar;
    //    private FamilyCar _familyCar;

    //    public Driver(CarFactory carFactory)
    //    {
    //        _sportsCar = carFactory.CreateSportsCar();
    //        _familyCar = carFactory.CreateFamilyCar();
    //    }

    //    public void CompareSpeed()
    //    {
    //        _familyCar.Speed(_sportsCar);
    //    }
    //}
}

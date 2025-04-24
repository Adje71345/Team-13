using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ny_carapp
{
    internal class FuelCar : Car, IEnergy
    {
        public double FuelLevel { get; set; }
        public double TankCapacity { get; set; }
        public double KmPerLiter { get; set; }

        // => returnerer værdien af FuelLevel og TankCapacity (shorthand)
        public double EnergyLevel => FuelLevel;
        public double MaxEnergy => TankCapacity;

        public FuelCar(string brand, string model, string licensePlate, double tankCapacity, double kmPerLiter) : base(brand, model, licensePlate)
        {
            TankCapacity = tankCapacity;
            KmPerLiter = kmPerLiter;
            FuelLevel = 0;
        }
        public void Refill(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("You cannot refuel a negative amount.");
                return;
            }
            if (FuelLevel + amount > TankCapacity)
            {
                Console.WriteLine("You cannot refuel more than the tank capacity.");
                return;
            }
            FuelLevel += amount;
            Console.WriteLine($"Refueled {amount} liters. Current fuel level: {FuelLevel} liters.");
        }



        public void UseEnergy(double km)
        {
            double fuelNeeded = km / KmPerLiter;
            if (fuelNeeded > FuelLevel)
            {
                Console.WriteLine("Not enough fuel to drive this distance.");
                return;
            }
            FuelLevel -= fuelNeeded;
        }

        public override void Drive(double km)
        {
            if (!IsEngineOn)
            {
                Console.WriteLine("You need to start the engine before driving.");
                return;
            }
            if (CanDrive(km) == true)
            {
                UseEnergy(km);
                Odometer += (int)km;
            }
        }

        public override bool CanDrive(double km)
        {
            if (FuelLevel <= 0)
            {
                Console.WriteLine("You cannot drive without fuel.");
                return false;
            }
            double fuelNeeded = km / KmPerLiter;
            if (fuelNeeded > FuelLevel)
            {
                Console.WriteLine("Not enough fuel to drive this distance.");
                return false;
            }
            return true;
        }


    }
}

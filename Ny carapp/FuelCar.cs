using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ny_carapp
{
    internal class FuelCar : Car
    {
        public double FuelLevel { get; set;}
        public double TankCapacity { get; set; }
        public double KmPerLiter { get; set; }

        public FuelCar(string brand, string model, string licensePlate, double tankCapacity, double kmPerLiter) : base(brand, model, licensePlate)
        {
            TankCapacity = tankCapacity;
            KmPerLiter = kmPerLiter;
            FuelLevel = 0;
        }
        public void Refuel (double amount)
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

        public override bool CanDrive(double distance)
        {
            if (FuelLevel <= 0)
            {
                Console.WriteLine("You cannot drive without fuel.");
                return false;
            }
            double fuelNeeded = CalculateConsumption(distance);
            if (fuelNeeded > FuelLevel)
            {
                Console.WriteLine("Not enough fuel to drive this distance.");
                return false;
            }
            return true;
        }

        public override void UpdateEnergyLevel(double distance)
        {
            double fuelNeeded = CalculateConsumption(distance);
            if (fuelNeeded > FuelLevel)
            {
                Console.WriteLine("Not enough fuel to drive this distance.");
                return;
            }
            FuelLevel -= fuelNeeded;
        }

        public override double CalculateConsumption(double distance)
        {
            return distance / KmPerLiter;
        }


        public override void Drive (double distance)
        {
            if (!IsEngineOn)
            {
                Console.WriteLine("You need to start the engine before driving.");
                return;
            }
            if (CanDrive(distance) == true)
            {
                UpdateEnergyLevel(distance);
                Odometer += (int)distance;
            }  
        }
    }
}

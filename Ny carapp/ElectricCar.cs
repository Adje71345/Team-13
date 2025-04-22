using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ny_carapp
{
    internal class ElectricCar : Car
    {
        public double BatteryLevel { get; set; }
        public double BatteryCapacity { get; set; }
        public double KmPerKWh { get; set; }
        public ElectricCar(string brand, string model, string licensePlate, double batteryCapacity, double kmPerKWh) : base(brand, model, licensePlate)
        {
            BatteryCapacity = batteryCapacity;
            KmPerKWh = kmPerKWh;
            BatteryLevel = 0;
        }

        public void Charge(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("You cannot charge a negative amount.");
                return;
            }
            if (BatteryLevel + amount > BatteryCapacity)
            {
                Console.WriteLine("You cannot charge more than the battery capacity.");
                return;
            }
            BatteryLevel += amount;
            Console.WriteLine($"Charged {amount} kWh. Current battery level: {BatteryLevel} kWh.");
        }
        
        public override bool CanDrive(double distance)
        {
            if (BatteryLevel <= 0)
            {
                Console.WriteLine("You cannot drive without fuel.");
                return false;
            }
            double fuelNeeded = CalculateConsumption(distance);
            if (fuelNeeded > BatteryLevel)
            {
                Console.WriteLine("Not enough fuel to drive this distance.");
                return false;
            }
            return true;
        }

        public override void UpdateEnergyLevel(double distance)
        {
            double fuelNeeded = CalculateConsumption(distance);
            if (fuelNeeded > BatteryLevel)
            {
                Console.WriteLine("Not enough fuel to drive this distance.");
                return;
            }
            BatteryLevel -= fuelNeeded;
        }

        public override double CalculateConsumption(double distance)
        {
            return distance / KmPerKWh;
        }


        public override void Drive(double distance)
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


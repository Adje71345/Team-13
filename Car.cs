using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ny_carapp
{
    internal abstract class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public bool IsEngineOn { get; set; }
        public int Odometer { get; set; }

        public Car(string brand, string model, string licensePlate)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            IsEngineOn = false;
            Odometer = 0;
        }

        public void StartEngine()
        {
            if (!IsEngineOn)
            {
                IsEngineOn = true;
                Console.WriteLine("The engine is now on.");
            }
            else
            {
                Console.WriteLine("The engine is already on.");
            }
        }

        public void StopEngine()
        {
            if (IsEngineOn)
            {
                IsEngineOn = false;
                Console.WriteLine("The engine is now off.");
            }
            else
            {
                Console.WriteLine("The engine is already off.");
            }
        }
        public abstract void Drive(double distance);

        public abstract bool CanDrive(double distance);
        public abstract void UpdateEnergyLevel(double distance);
        public abstract double CalculateConsumption(double distance);


    }
}

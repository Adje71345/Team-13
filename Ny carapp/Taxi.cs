using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ny_carapp
{
    internal class Taxi : Car
    {
        public Car Vehicle { get; private set; }
        public double StartPrice { get; set; }
        public double PricePerKm { get; set; }
        public double PricePerMinute { get; set; }
        public bool MeterStarted { get; set; }
        public double FuelLevel
        {
            get
            {
                if (Vehicle is FuelCar fuelCar)
                {
                    return fuelCar.FuelLevel;
                }
                else if (Vehicle is ElectricCar electricCar)
                {
                    return electricCar.BatteryLevel;
                }
                else
                {
                    throw new InvalidOperationException("Unknown vehicle type.");
                }
            }
        }

        public Taxi(Car vehicle, string brand, string model, string licensePlate, double startPrice, double pricePerKm, double pricePerMinute) : base(vehicle.Brand, vehicle.Model, vehicle.LicensePlate)
        {
            Vehicle = vehicle;
            StartPrice = startPrice;
            PricePerKm = pricePerKm;
            PricePerMinute = pricePerMinute;
            MeterStarted = false;
        }

        public void StartMeter()
        {
            if (!MeterStarted)
            {
                MeterStarted = true;
                Console.WriteLine("The taxi meter is now running.");
            }
            else
            {
                Console.WriteLine("The taxi meter is already running.");
            }
        }

        public void StopMeter()
        {
            if (MeterStarted)
            {
                MeterStarted = false;
                Console.WriteLine("The taxi meter is now stopped.");
            }
            else
            {
                Console.WriteLine("The taxi meter is already stopped.");
            }
        }

        public double CalculateFare(double distance, double minutes)
        {
            if (!MeterStarted)
            {
                Console.WriteLine("The taxi meter is not running. Please start the meter first.");
                return 0;
            }
            double fare = StartPrice + (PricePerKm * distance) + (PricePerMinute * minutes);
            return fare;
        }

        public override bool CanDrive(double distance)
        {
            return Vehicle.CanDrive(distance);
        }

        public override void UpdateEnergyLevel(double distance)
        {
            Vehicle.UpdateEnergyLevel(distance);
        }

        public override double CalculateConsumption(double distance)
        {
            return Vehicle.CalculateConsumption(distance);
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

        public void Refuel(double amount)
        {
            if (Vehicle is FuelCar fuelCar)
            {
                fuelCar.Refuel(amount);
            }
            else if (Vehicle is ElectricCar electricCar)
            {
                electricCar.Charge(amount);
            }
            else
            {
                Console.WriteLine("This vehicle cannot be refueled.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ny_carapp
{
    internal class Taxi : Car
    {
        private Car Vehicle { get; set; }
        public double StartPrice { get; set; }
        public double PricePerKm { get; set; }
        public double PricePerMinute { get; set; }
        public bool MeterStarted { get; set; }

        public Taxi(Car vehicle, string brand, string model, string licensePlate, double startPrice, double pricePerKm, double pricePerMinute) : base(vehicle.Brand, model, licensePlate)
        {
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
    }
}

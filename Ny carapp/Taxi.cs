using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ny_carapp
{
    internal class Taxi : Car
    {
        

        private IEnergy energyHandler; // komposition med IEnergy interface

        public double EnergyLevel => energyHandler.EnergyLevel; // getter til at få energiniveauet
        public double MaxEnergy => energyHandler.MaxEnergy; // getter til at få maksimalt energiniveau

        public double StartPrice { get; set; }
        public double PricePerKm { get; set; }
        public double PricePerMinute { get; set; }
        public bool MeterStarted { get; set; }
        

        // konstruktør tager Ienergy implementation som parameter

        public Taxi(string brand, string model, string licensePlate,IEnergy energyHandler, double startPrice, double pricePerKm, double pricePerMinute) : base(brand, model,licensePlate)
        {
            
            this.energyHandler = energyHandler;
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

        public double CalculateFare(double km, double minutes)
        {
            if (!MeterStarted)
            {
                Console.WriteLine("The taxi meter is not running. Please start the meter first.");
                return 0;
            }
            double fare = StartPrice + (PricePerKm * km) + (PricePerMinute * minutes);
            return fare;
        }

        public override bool CanDrive(double km)
        {
            // Implementering baseret på energyHandler
            // Logik for at afgøre om taxi har nok energy
            return energyHandler.EnergyLevel > 0; // eller en anden betingelse
        }

        public void UseEnergy(double km)
        {
            energyHandler.UseEnergy(km);
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

        public void Refill(double amount)
        {
            energyHandler.Refill(amount);
        }

        

        


        
    }
}
    


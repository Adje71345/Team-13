using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carapp_repository_pattern
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string LicensePlate { get; set; }
        public string FuelType { get; set; }
        public List<Trip> Trips { get; set; }

        public Car(string make, string model, int year, string color, string licensePlate, string fuelType)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            LicensePlate = licensePlate;
            FuelType = fuelType;
            Trips = new List<Trip>();
        }

        public string ToString()
        {
            return $"{Make},{Model},{Year},{Color},{LicensePlate},{FuelType}";
        }

        public static Car FromString(string input)
        {
            string[] parts = input.Split(',');
            if (parts.Length != 6)
            {
                throw new ArgumentException("Invalid input format");
            }
            string make = parts[0].Trim();
            string model = parts[1].Trim();
            int year = int.Parse(parts[2].Trim());
            string color = parts[3].Trim();
            string licensePlate = parts[4].Trim();
            string fuelType = parts[5].Trim();
            return new Car(make, model, year, color, licensePlate, fuelType);
        }
    }
}

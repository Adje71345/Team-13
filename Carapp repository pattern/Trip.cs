using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carapp_repository_pattern
{
    public class Trip
    {
        public string CarRegNr { get; set; }
        public double Distance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Trip(string carRegNr, double distance, DateTime date, TimeSpan startTime, TimeSpan endTime)
        {
            CarRegNr = carRegNr;
            Distance = distance;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string ToString()
        {
            return $"{CarRegNr},{Distance},{Date.ToShortDateString()},{StartTime},{EndTime}";
        }

        public static Trip FromString(string input)
        {
            string[] parts = input.Split(',');
            if (parts.Length != 5)
            {
                throw new ArgumentException("Invalid input format");
            }
            string carRegNr = parts[0].Trim();
            double distance = double.Parse(parts[1].Trim());
            DateTime date = DateTime.Parse(parts[2].Trim());
            TimeSpan startTime = TimeSpan.Parse(parts[3].Trim());
            TimeSpan endTime = TimeSpan.Parse(parts[4].Trim());
            return new Trip(carRegNr, distance, date, startTime, endTime);
        }
    }
}

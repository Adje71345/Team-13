using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carapp_repository_pattern
{
    public class FileTripRepository
    {
        public string filePath = "trips.txt";

        public IEnumerable<Trip> GetTripsForCar(string regNr)
        {
            try
            {
                List<Trip> trips = new List<Trip>();
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Trip trip = Trip.FromString(line);
                    if (trip.CarRegNr == regNr)
                    {
                        trips.Add(trip);
                    }
                }
                return trips;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                return new List<Trip>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                return new List<Trip>();
            }
        }

        public void AddTrip(Trip trip)
        {
            if (trip == null)
            {
                throw new ArgumentNullException(nameof(trip), "Trip cannot be null.");
            }

            //opret en instans af FileCarRepository og tjek bilens eksistens
            var carRepository = new FileCarRepository();
            var car = carRepository.GetCar(trip.CarRegNr);

            if (car == null)
            {
                throw new ArgumentException("Car with this license plate does not exist.");
            }

            try
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(trip.ToString());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public void DeleteTrip(Trip trip)
        {
            if (trip == null)
            {
                throw new ArgumentNullException(nameof(trip), "Trip cannot be null.");
            }
            try
            {
                List<Trip> trips = (List<Trip>)GetTripsForCar(trip.CarRegNr);
                int index = trips.FindIndex(t => t.Date == trip.Date && t.StartTime == trip.StartTime);
                if (index != -1)
                {
                    trips.RemoveAt(index);
                    File.WriteAllLines(filePath, trips.Select(t => t.ToString()));
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}

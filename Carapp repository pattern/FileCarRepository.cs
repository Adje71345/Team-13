using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Carapp_repository_pattern
{
    public class FileCarRepository:ICarRepository
    {
        public string filePath= "cars.txt";

        public IEnumerable<Car> GetAllCars()
        {
            try
            {
                List<Car> cars = new List<Car>();
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    Car car = Car.FromString(line);
                    cars.Add(car);
                }
            return cars;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
                return new List<Car>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                return new List<Car>();
            }
        }
        public Car GetCar(string licensePlate)
        {
            return GetAllCars().FirstOrDefault(c => c.LicensePlate == licensePlate);
        }

        public void AddCar(Car car)
        {
            if (GetCar(car.LicensePlate) != null)
                {
                    Console.WriteLine("Car with this license plate already exists.");
                    return;
                }
            try
            {   
                using (StreamWriter sw = File.AppendText(filePath))
                {
                sw.WriteLine(car.ToString());
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

        public void UpdateCar(Car car)
        {
            try
            {
                List<Car> cars = (List<Car>)GetAllCars();
                int index = cars.FindIndex(c => c.LicensePlate == car.LicensePlate);
                if (index != -1)
                {
                    cars[index] = car;
                    File.WriteAllLines(filePath, cars.Select(c => c.ToString()));
                }
                else
                {
                    Console.WriteLine("Car not found.");
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
        public void DeleteCar(string licensePlate)
        {
            if (GetCar(licensePlate) == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }
            try
            {
                List<Car> cars = (List<Car>)GetAllCars();
                int index = cars.FindIndex(c => c.LicensePlate == licensePlate);
                if (index != -1)
                {
                    cars.RemoveAt(index);
                    File.WriteAllLines(filePath, cars.Select(c => c.ToString()));
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

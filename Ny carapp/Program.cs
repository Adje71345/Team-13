namespace Ny_carapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FuelCar fuelCar= new FuelCar("Toyota", "Corolla", "ABC123", 50, 15);
            fuelCar.StartEngine();
            fuelCar.Refuel(40);
            fuelCar.Drive(100);
            Console.WriteLine($"Fuelcar Odometer: {fuelCar.Odometer} km. Remaining fuel: {fuelCar.FuelLevel:F2} liters.");
            fuelCar.Drive(700);
            Console.WriteLine($"Fuelcar Odometer: {fuelCar.Odometer} km. Remaining fuel: {fuelCar.FuelLevel:F2} liters.");
            fuelCar.StopEngine();
            Console.ReadLine();

            ElectricCar electricCar = new ElectricCar("Tesla", "Model S", "XYZ789", 100, 5);
            electricCar.StartEngine();
            electricCar.Charge(80);
            electricCar.Drive(200);
            Console.WriteLine($"ElectricCar Odometer: {electricCar.Odometer} km. Remaining battery: {electricCar.BatteryLevel:F2} kWh.");
            electricCar.Drive(400);
            Console.WriteLine($"ElectricCar Odometer: {electricCar.Odometer} km. Remaining battery: {electricCar.BatteryLevel:F2} kWh.");
            electricCar.StopEngine();
            Console.ReadLine();
        }
    }
}

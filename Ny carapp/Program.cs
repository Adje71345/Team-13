namespace Ny_carapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FuelCar fuelCar= new FuelCar("Toyota", "Corolla", "ABC123", 50, 15);
            fuelCar.StartEngine();
            fuelCar.Refill(40);
            fuelCar.Drive(100);
            Console.WriteLine($" Fuel level: {fuelCar.EnergyLevel:F2} Odometer: {fuelCar.Odometer}");
            fuelCar.Drive(700);
            fuelCar.StopEngine();
            Console.ReadLine();

            ElectricCar electricCar = new ElectricCar("Tesla", "Model S", "XYZ789", 100, 5);
            electricCar.StartEngine();
            electricCar.Refill(80);
            electricCar.Drive(200);
            Console.WriteLine($" Fuel level: {electricCar.EnergyLevel:F2} Odometer: {electricCar.Odometer}");
            electricCar.Drive(400);
            electricCar.StopEngine();
            Console.ReadLine();


            // Opretter objekter / Instanser af klasserne

            FuelCar fuelCar1 = new FuelCar("Toyota", "Corolla", "ABC123", 50, 15);
            ElectricCar electricCar1 = new ElectricCar("Tesla", "Model S", "XYZ789", 100, 5);

            // Opret taxi med forskellige energysystemer 
            Taxi fuelTaxi = new Taxi(fuelCar1.Brand, fuelCar1.Model, fuelCar1.LicensePlate,fuelCar1, 50, 2, 3);
            Taxi electricTaxi = new Taxi(electricCar1.Brand, electricCar1.Model, electricCar1.LicensePlate, electricCar1, 50, 2, 3);

            fuelTaxi.StartEngine();
            fuelTaxi.StartMeter();
            fuelTaxi.Refill(40);
            fuelTaxi.Drive(100);

            double fare = fuelTaxi.CalculateFare(100, 30);
            Console.WriteLine($"Taxi fare: {fare:F2} kr. Energy left: {fuelTaxi.EnergyLevel}");
            fuelTaxi.StopMeter();
            
            
            fuelTaxi.StartMeter();
            fuelTaxi.Drive(700);
            double fare2 = fuelTaxi.CalculateFare(700, 30);
            Console.WriteLine($"Taxi fare: {fare2:F2} kr.");
            fuelTaxi.StopMeter();
            fuelTaxi.StopEngine();

            Console.WriteLine();

            electricTaxi.StartEngine();
            electricTaxi.StartMeter();
            electricTaxi.Refill(80);
            electricTaxi.Drive(200);

            fare = electricTaxi.CalculateFare(200, 60);
            Console.WriteLine($"Taxi fare: {fare:F2} kr.");

            electricTaxi.StopMeter();
            fuelTaxi.StopEngine();

            Console.ReadLine();



            // Opret flåde af køretøjer
            FleetManager fleet = new FleetManager();

            // Tilføjer forskellige typer køretøjer
            fleet.AddVehicle(new FuelCar("Toyota", "Corolla", "AB12345", 50, 20));
            fleet.AddVehicle(new ElectricCar("Tesla", "Model 3", "XY98765", 75, 15));
            fleet.AddVehicle(fuelTaxi);
            fleet.AddVehicle(electricTaxi);

            // Håndter hele flåden på én gang
            fleet.DisplayFleetStatus();
            fleet.StartAllEngines();
            fleet.DriveAllVehicles(100);
            fleet.RefillAllVehicles();
            fleet.DisplayFleetStatus();
            fleet.StopAllEngines();
        }

        

        //printer taxi pris
        public static void PrintTaxiFare(Taxi taxi, double distance, double time)
        {
            Console.WriteLine($"Taxi fare: {taxi.CalculateFare(distance, time):F2} kr.");
        }

    }
}

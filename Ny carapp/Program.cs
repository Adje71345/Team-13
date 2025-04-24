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
            //PrintCarStatus(fuelCar);
            fuelCar.Drive(700);
            //PrintCarStatus(fuelCar);
            fuelCar.StopEngine();
            Console.ReadLine();

            ElectricCar electricCar = new ElectricCar("Tesla", "Model S", "XYZ789", 100, 5);
            electricCar.StartEngine();
            electricCar.Refill(80);
            electricCar.Drive(200);
            //PrintCarStatus(electricCar);
            electricCar.Drive(400);
            //PrintCarStatus(electricCar);
            electricCar.StopEngine();
            Console.ReadLine();

            // Create a Taxi object
            FuelCar taxi1 = new FuelCar("Volvo", "V70", "TAXI123", 60, 12);
            ElectricCar taxi2 = new ElectricCar("Nissan", "Leaf", "TAXI456", 40, 6);
            IEnergy taxi3 = new FuelCar("Volvo", "V70", "TAXI123", 60, 12);

            Taxi taxi = new Taxi(taxi3, taxi2.Brand, taxi2.Model, taxi2.LicensePlate, 50, 2, 3);
            taxi.StartEngine();
            taxi.StartMeter();
            taxi.Refill(40);
            taxi.Drive(100);
            //PrintCarStatus(taxi);
            PrintTaxiFare(taxi, 100, 30);
            taxi.StopMeter();
            taxi.StopEngine();
            Console.ReadLine();


            FuelCar fuelCar1 = new FuelCar("Toyota", "Corolla", "ABC123", 50, 15);
            Taxi fuelTaxi  = new Taxi(fuelCar1, fuelCar1.Brand, fuelCar1.Model, fuelCar1.LicensePlate, 50, 2, 3);

            fuelTaxi.StartEngine();
            fuelTaxi.StartMeter();
            fuelTaxi.Refill(40);
            fuelTaxi.Drive(100);
            PrintTaxiFare(fuelTaxi, 100, 30);
            fuelTaxi.StopMeter();
            fuelTaxi.StopEngine();


        }

        /*//print liter eller KWh
        public static void PrintCarStatus(Car car)
        {
            if (car is Taxi taxi)
            {
                if (taxi.Vehicle is ElectricCar)
                {
                    // Hvis taxien bruger en el-bil, vis batteri i stedet for brændstof
                    Console.WriteLine($"Taxi Odometer: {taxi.Odometer} km. Remaining battery: {((ElectricCar)taxi.Vehicle).BatteryLevel:F2} kWh.");
                }
                else
                {
                    // Standard tekst for en taxi med brændstofbil
                    Console.WriteLine($"Taxi Odometer: {taxi.Odometer} km. Remaining fuel: {taxi.FuelLevel:F2} liters.");
                }
            }
            else if (car is FuelCar fuelCar)
            {
                Console.WriteLine($"FuelCar Odometer: {fuelCar.Odometer} km. Remaining fuel: {fuelCar.FuelLevel:F2} liters.");
            }
            else if (car is ElectricCar electricCar)
            {
                Console.WriteLine($"ElectricCar Odometer: {electricCar.Odometer} km. Remaining battery: {electricCar.BatteryLevel:F2} kWh.");
            }
            else
            {
                Console.WriteLine($"Car Odometer: {car.Odometer} km.");
            }
        }*/

        //printer taxi pris
        public static void PrintTaxiFare(Taxi taxi, double distance, double time)
        {
            Console.WriteLine($"Taxi fare: {taxi.CalculateFare(distance, time):F2} kr.");
        }

    }
}

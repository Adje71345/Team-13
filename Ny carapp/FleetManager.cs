namespace Ny_carapp;

public class FleetManager
{
    private List<Car> _vehicles;

    public FleetManager()
    {
        _vehicles = new List<Car>();
    }

     public void AddVehicle(Car vehicle)
     {
        _vehicles.Add(vehicle);
     }

    public void StartAllEngines()
    {
        foreach (var vehicle in _vehicles)
        {
            vehicle.StartEngine();
        }
    }

    public void StopAllEngines()
    {
        foreach (var vehicle in _vehicles)
        {
            vehicle.StopEngine();
        }
    }

    public void DriveAllVehicles(double kilometers)
    {
        foreach (var vehicle in _vehicles)
        {
            if (vehicle.CanDrive(kilometers))
            {
                vehicle.Drive(kilometers);

                Console.WriteLine($"{vehicle.Brand} {vehicle.Model} drove {kilometers} km");
            }
            else
            {
                Console.WriteLine($"{vehicle.Brand} {vehicle.Model} cannot drive the requested distance due to insufficient energy");
            }

        }

    }

    public void RefillAllVehicles()
    {
        foreach (var vehicle in _vehicles)
        {
            if (vehicle is IEnergy energyVehicle)
            {
                double amountToRefill = energyVehicle.MaxEnergy - energyVehicle.EnergyLevel;

                energyVehicle.Refill(amountToRefill);

                Console.WriteLine($"{vehicle.Brand} {vehicle.Model} refilled to maximum capacity");
            }

        }

    }

    public void DisplayFleetStatus()
    {
        Console.WriteLine("\n--- Fleet Status ---");

        foreach (var vehicle in _vehicles)
        {
            string energyInfo = "";

            if (vehicle is IEnergy energyVehicle)
            {
                energyInfo = $"Energy: {energyVehicle.EnergyLevel:F2}/{energyVehicle.MaxEnergy:F2}";
            }

            Console.WriteLine($"{vehicle.Brand} {vehicle.Model} ({vehicle.LicensePlate}) - Odometer: {vehicle.Odometer:F1} km, {energyInfo}");

        }

        Console.WriteLine("-------------------\n");

    }

}
using DataToJsonAdaptor;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDetails;

namespace JSONDataPrinter
{
    public class JsonDataPrinter
    {
        private readonly IJsonTarget vehicleJsonTarget;
        public JsonDataPrinter(IJsonTarget vehicleJsonTarget)
        {
            this.vehicleJsonTarget = vehicleJsonTarget;
        }
        /*
        private IEnumerable<Vehicle> ReadVehicleFromJson(string json)
        {
            var vehicles = JsonSerializer.Deserialize<IEnumerable<Vehicle>>(json);
            if (vehicles == null)
                return new List<Vehicle>();
            return vehicles;
        }
       */
        public void DisplayVehicleInfo()
        {
            
            string json = vehicleJsonTarget.ReadDataFromSource();
            /*
            var vehicles = ReadVehicleFromJson(json);
            foreach(var vehicle in vehicles )
            {
                Console.WriteLine($"Model: {vehicle.Model}");
                Console.WriteLine($"Year: {vehicle.Year}");
                Console.WriteLine($"Number of doors: {vehicle.NumberDoors}");
                Console.WriteLine($"Fuel type: {vehicle.Fuel}\n");
            }
            */
            
            Console.WriteLine(json);
        }

    }
}

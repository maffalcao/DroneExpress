using Src.Models;
using Src.Services;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: dotnet run <input_file> <output_file>");
            return;
        }

        string inputFile = args[0];
        string outputFile = args[1];

        List<Drone> drones = new List<Drone>();
        List<Location> locations = new List<Location>();

        try
        {
            // Reading the input file
            string[] inputLines = File.ReadAllLines(inputFile);

            // Processing the drones
            string[] droneData = inputLines[0].Split(',');
            for (int i = 0; i < droneData.Length; i += 2)
            {
                string droneName = droneData[i].Trim();
                int maxWeight = int.Parse(droneData[i + 1].Trim());
                drones.Add(new Drone(droneName, maxWeight));
            }

            // Processing of locations
            for (int i = 1; i < inputLines.Length; i++)
            {
                string[] locationData = inputLines[i].Split(',');
                string locationName = locationData[0].Trim();
                int packageWeight = int.Parse(locationData[1].Trim());
                locations.Add(new Location(locationName, packageWeight));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading input file: " + ex.Message);
            return;
        }

        // Resolution of the problem
        DroneDeliverySolver solver = new DroneDeliverySolver(drones, locations);
        solver.Solve();


        File.WriteAllText(outputFile, solver.Print());
        Console.WriteLine("Output successfuly generated");
    }
}
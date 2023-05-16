using Src.Models;

namespace Src.Helpers;

public class InputReader
{
    public static (List<Drone>, List<Location>) ReadInputFile(string inputFile)
    {
        List<Drone> drones = new List<Drone>();
        List<Location> locations = new List<Location>();

        try
        {
            string[] inputLines = File.ReadAllLines(inputFile);

            string[] droneData = inputLines[0].Split(',');
            for (int i = 0; i < droneData.Length; i += 2)
            {
                string droneName = droneData[i].Trim();
                int maxWeight = int.Parse(droneData[i + 1].Trim());
                drones.Add(new Drone(droneName, maxWeight));
            }

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
        }

        return (drones, locations);
    }
}
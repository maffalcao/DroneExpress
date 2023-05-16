using System.Text;
using Src.Models;

namespace Src.Services;

public class DroneDeliverySolver
{
    private List<Drone> drones;
    private List<Location> locations;

    public DroneDeliverySolver(List<Drone> drones, List<Location> locations)
    {
        this.drones = drones;
        this.locations = locations;
    }

    public void Solve()
    {
        // Sort locations by package weight (descending order)
        locations.Sort((a, b) => b.PackageWeight.CompareTo(a.PackageWeight));

        // Assign trips to drones
        foreach (var drone in drones)
        {
            var remainingWeight = drone.MaximumWeight;
            var currentTrip = new List<Location>();

            foreach (var location in locations)
            {
                if (location.PackageWeight <= remainingWeight)
                {
                    currentTrip.Add(location);
                    remainingWeight -= location.PackageWeight;
                }

                if (remainingWeight == 0)
                {
                    drone.AddTrip(currentTrip);
                    currentTrip = new List<Location>();
                    remainingWeight = drone.MaximumWeight;
                }
            }

            if (currentTrip.Count > 0)
            {
                drone.AddTrip(currentTrip);
            }
        }
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();

        foreach (Drone drone in this.drones)
        {
            sb.AppendLine($"[{drone.Name}]");
            for (int i = 0; i < drone.Trips.Count; i++)
            {
                sb.AppendLine($"Trip #{i + 1}");
                List<string> locationNames = new List<string>();
                foreach (Location location in drone.Trips[i])
                {
                    locationNames.Add(location.Name);
                }
                sb.AppendLine(string.Join(", ", locationNames));
                sb.AppendLine();
            }
        }

        return sb.ToString();
    }
}
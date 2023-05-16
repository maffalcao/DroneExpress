namespace Src.Models;
public class Drone
{
    public string Name { get; set; }
    public int MaximumWeight { get; set; }
    public List<List<Location>> Trips { get; }

    public Drone(string name, int maximumWeight)
    {
        Name = name;
        MaximumWeight = maximumWeight;
        Trips = new List<List<Location>>();
    }

    public void AddTrip(List<Location> trip)
    {
        Trips.Add(trip);
    }

    public override string ToString()
    {
        string output = $"[{Name}]\n";
        for (int i = 0; i < Trips.Count; i++)
        {
            output += $"Trip #{i + 1}\n";
            output += string.Join(", ", Trips[i]) + "\n";
        }
        return output;
    }
}
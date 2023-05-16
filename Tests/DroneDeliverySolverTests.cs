using Src.Models;
using Src.Services;

namespace Tests;

public class DroneDeliverySolverTests
{
    [Fact]
    public void Solve_ShouldAssignTripsToDrones()
    {
        // Arrange
        var drones = new List<Drone>
        {
            new Drone("Drone 1", 10),
            new Drone("Drone 2", 8)
        };

        var locations = new List<Location>
        {
            new Location("Location 1", 5),
            new Location("Location 2", 3),
            new Location("Location 3", 2),
            new Location("Location 4", 7)
        };

        var solver = new DroneDeliverySolver();
        solver.Initialize(drones, locations);

        // Act
        solver.Solve();

        // Assert
        Assert.Equal(2, drones[0].Trips.Count);
        Assert.Equal(1, drones[1].Trips.Count);
        Assert.Equal(3, solver.TotalTrips());
    }

    [Fact]
    public void Print_ShouldReturnCorrectOutputString()
    {
        // Arrange
        var drones = new List<Drone>
        {
            new Drone("Drone 1", 10),
            new Drone("Drone 2", 8)
        };

        var locations = new List<Location>
        {
            new Location("Location 1", 5),
            new Location("Location 2", 3),
            new Location("Location 3", 2),
            new Location("Location 4", 7)
        };

        var solver = new DroneDeliverySolver();
        solver.Initialize(drones, locations);
        solver.Solve();

        // Act
        var output = solver.Print();

        // Assert
        var expectedOutput = "[Drone 1]\n" +
                             "Trip #1\n" +
                             "Location 4, Location 1\n" +
                             "\n" +
                             "Trip #2\n" +
                             "Location 2, Location 3\n" +
                             "\n" +
                             "[Drone 2]\n" +
                             "Trip #1\n" +
                             "Location 2, Location 3\n" +
                             "\n";

        Assert.Equal(expectedOutput, NormalizeLineEndings(output));
    }
    private static string NormalizeLineEndings(string text)
    {
        return text.Replace("\r\n", "\n").Replace("\r", "\n");
    }
}
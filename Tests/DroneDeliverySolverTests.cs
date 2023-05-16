using Src.Helpers;
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

    [Fact]
    public void Solve_ValidSolution()
    {
        // Arrange
        List<Drone> drones = new List<Drone>
    {
        new Drone("Drone 1", 10),
        new Drone("Drone 2", 15)
    };

        List<Location> locations = new List<Location>
    {
        new Location("Location 1", 5),
        new Location("Location 2", 8),
        new Location("Location 3", 12)
    };

        // Act
        DroneDeliverySolver solver = new DroneDeliverySolver();
        solver.Initialize(drones, locations);
        solver.Solve();

        // Assert
        // Add assertions to validate the solution
        // For example, check if each drone's trips respect the weight limits
        foreach (Drone drone in drones)
        {
            foreach (List<Location> trip in drone.Trips)
            {
                int totalWeight = trip.Sum(location => location.PackageWeight);
                Assert.True(totalWeight <= drone.MaximumWeight);
            }
        }
    }

    [Fact]
    public void Print_ReturnsCorrectOutputString()
    {
        // Arrange
        List<Drone> drones = new List<Drone>
    {
        new Drone("Drone 1", 10),
        new Drone("Drone 2", 15)
    };

        List<Location> locations = new List<Location>
    {
        new Location("Location 1", 5),
        new Location("Location 2", 8),
        new Location("Location 3", 12)
    };

        DroneDeliverySolver solver = new DroneDeliverySolver();
        solver.Initialize(drones, locations);
        // Call the Solve method to populate the trips

        // Act
        string output = solver.Print();

        // Assert
        string expectedOutput = "[Drone 1]\nTrip #1\nLocation 1\n\n[Drone 2]\nTrip #1\nLocation 2\n";
        Assert.Equal(expectedOutput, output);
    }

    [Fact]
    public void WriteOutputFile_WritesCorrectOutputFile()
    {
        // Arrange
        string outputFile = "output.txt";
        string outputContent = "Test output content";

        // Act
        OutputWriter.WriteOutputFile(outputFile, outputContent);

        // Assert
        string actualContent = File.ReadAllText(outputFile);
        Assert.Equal(outputContent, actualContent);
    }

    [Fact]
    public void ReadInputFile_ReturnsCorrectData()
    {
        // Arrange
        string inputFile = "input.txt";
        string[] inputLines = new string[]
        {
        "Drone 1, 10",
        "Location 1, 5",
        "Location 2, 8"
        };
        // Arrange
        File.WriteAllLines(inputFile, inputLines);

        // Act
        var (drones, locations) = InputReader.ReadInputFile(inputFile);

        // Assert
        Assert.Equal(2, drones.Count);
        Assert.Equal(2, locations.Count);

        Assert.Equal("Drone 1", drones[0].Name);
        Assert.Equal(10, drones[0].MaximumWeight);

        Assert.Equal("Location 1", locations[0].Name);
        Assert.Equal(5, locations[0].PackageWeight);

        Assert.Equal("Location 2", locations[1].Name);
        Assert.Equal(8, locations[1].PackageWeight);
    }
    private static string NormalizeLineEndings(string text)
    {
        return text.Replace("\r\n", "\n").Replace("\r", "\n");
    }
}
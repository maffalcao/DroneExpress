using Src.Helpers;
using Src.Services;
using Src.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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

        var serviceProvider = GetServiceProvider();

        // Read input file
        var (drones, locations) = InputReader.ReadInputFile(inputFile);

        // Resolve the required service
        var solver = serviceProvider.GetService<IDroneDeliverySolver>();
        solver.Initialize(drones, locations);

        // Solve the problem
        solver.Solve();

        // Generate output
        string output = solver.Print();

        // Write output file
        OutputWriter.WriteOutputFile(outputFile, output);
    }

    public static IServiceProvider GetServiceProvider()
    {
        // Create a service collection
        var services = new ServiceCollection();

        // Register dependencies
        services.AddTransient<IDroneDeliverySolver, DroneDeliverySolver>();

        // Build the service provider
        return services.BuildServiceProvider();

    }
}
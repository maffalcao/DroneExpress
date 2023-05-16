using Src.Helpers;
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

        // Read input file
        var (drones, locations) = InputReader.ReadInputFile(inputFile);

        // Solve the problem
        DroneDeliverySolver solver = new DroneDeliverySolver(drones, locations);
        solver.Solve();

        // Generate output
        string output = solver.Print();

        // Write output file
        OutputWriter.WriteOutputFile(outputFile, output);
    }
}
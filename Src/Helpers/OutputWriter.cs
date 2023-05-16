namespace Src.Helpers;

public class OutputWriter
{
    public static void WriteOutputFile(string outputFile, string output)
    {
        try
        {
            File.WriteAllText(outputFile, output);
            Console.WriteLine("Output successfully generated");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error writing output file: " + ex.Message);
        }
    }
}
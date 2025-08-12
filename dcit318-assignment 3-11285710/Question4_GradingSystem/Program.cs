using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        var processor = new StudentResultProcessor();
        string inputPath = "StudentInput.txt";
        string outputPath = "StudentReport.txt";

        try
        {
            var students = processor.ReadStudentsFromFile(inputPath);
            processor.WriteReportToFile(students, outputPath);
            Console.WriteLine("Report generated successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: Input file not found.");
        }
        catch (InvalidScoreFormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (MissingFieldException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}

using System;
using OldPhonePadConverter;

class Program
{
    static void Main()
    {
        Console.Write("Enter keypad input: ");
        string input = Console.ReadLine() ?? "";

        var conv = new OldPhoneConverter();
        var result = conv.Convert(input);

        Console.WriteLine($"\nOutput: {result.Text}");
        if (result.Warnings.Count > 0)
        {
            Console.WriteLine("\nWarnings:");
            foreach (var w in result.Warnings)
                Console.WriteLine($"- {w}");
        }
    }
}


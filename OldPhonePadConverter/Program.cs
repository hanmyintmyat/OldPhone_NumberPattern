using System.Text;

public class OldPhonePadProgram
{
    private static readonly Dictionary<char, string> keyMap = new Dictionary<char, string>()
    {
        { '1', "" },     
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '0', " " },   
    };

    public static Dictionary<char, string> KeyMap => keyMap;

    public static string OldPhonePad(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        StringBuilder result = new StringBuilder();
        int i = 0;

        while (i < input.Length)
        {
            char c = input[i];

            if (c == '#') break; // End of input

            if (c == '*') // Backspace
            {
                if (result.Length > 0) result.Length--;
                i++;
                continue;
            }

            if (c == ' ') // Pause between letters
            {
                i++;
                continue;
            }

            int count = 1;
            while (i + count < input.Length && input[i + count] == c)
                count++;

            if (KeyMap.ContainsKey(c) && KeyMap[c].Length > 0)
            {
                string letters = KeyMap[c];
                char letter = letters[(count - 1) % letters.Length];
                result.Append(letter);
            }
            else if (c == '0')
            {
                result.Append(' '); // '0' is a space
            }

            i += count;
        }

        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine("=== Old Phone Keypad Converter ===");
        Console.WriteLine("Type your keypad input using numbers.");
        Console.WriteLine("Use '*' for backspace, pause with space, and end input with '#'.\n");

        Console.Write("Enter input: ");
        string input = Console.ReadLine() ?? "";

        string output = OldPhonePad(input);
        Console.WriteLine("\nTranslated Text: " + output);
    }
}





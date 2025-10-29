using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePadConverter
{

    public class OldPhoneConverter
    {
        // Mapping of keypad digits to letters
        private static readonly Dictionary<char, string> KeyMap = new()
        {
            ['2'] = "ABC",
            ['3'] = "DEF",
            ['4'] = "GHI",
            ['5'] = "JKL",
            ['6'] = "MNO",
            ['7'] = "PQRS",
            ['8'] = "TUV",
            ['9'] = "WXYZ",
            ['0'] = " " // space
        };

        
        public ConversionResult Convert(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var result = new ConversionResult();
            var output = new StringBuilder();

            char? currentKey = null;
            int pressCount = 0;

            void EmitCurrent()
            {
                if (currentKey == null)
                    return;

                if (KeyMap.TryGetValue(currentKey.Value, out var letters))
                {
                    var index = (pressCount - 1) % letters.Length;
                    output.Append(letters[index]);
                }
                else
                {
                    result.Warnings.Add($"Ignoring unknown key '{currentKey}'");
                }

                currentKey = null;
                pressCount = 0;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (c == ' ')
                {
                    // Space means "pause" between same key presses
                    EmitCurrent();
                    continue;
                }

                if (c == '*')
                {
                    // Backspace behavior
                    if (output.Length > 0)
                        output.Length--;
                    else
                        result.Warnings.Add("Backspace at beginning ignored.");

                    currentKey = null;
                    pressCount = 0;
                    continue;
                }

                if (c == '#')
                {
                    // End of input — finalize and exit
                    EmitCurrent();
                    result.Text = output.ToString();
                    return result;
                }

                if (KeyMap.ContainsKey(c))
                {
                    if (currentKey == null || currentKey == c)
                    {
                        currentKey = c;
                        pressCount++;
                    }
                    else
                    {
                        EmitCurrent();
                        currentKey = c;
                        pressCount = 1;
                    }
                }
                else
                {
                    result.Warnings.Add($"Invalid character '{c}' ignored.");
                }
            }

            // If input didn’t end with '#', flush whatever’s left
            EmitCurrent();
            result.Warnings.Add("Input did not end with '#'; partial text returned.");

            result.Text = output.ToString();
            return result;
        }
    }

  
    public class ConversionResult
    {
        public string Text { get; set; } = string.Empty;
        public List<string> Warnings { get; } = new();
    }
}







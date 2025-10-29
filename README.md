# Old Phone Keypad Converter

A C# console application that simulates typing on an old mobile‑phone keypad. It converts numeric input into text using the traditional multi‑tap system.

## Features
- Multi‑tap typing conversion (e.g., press ‘2’ once for ‘A’, twice for ‘B’, etc.)
- Backspace support with `*`
- Space handling with `0` (or explicit pause with space)
- Pause (space character) to separate letters when pressing the **same key** consecutively
- Input must end with `#` to send/confirm the message

## Keypad Mapping

| Key | Letters     |
|-----|-------------|
| 1   | (none)      |
| 2   | ABC         |
| 3   | DEF         |
| 4   | GHI         |
| 5   | JKL         |
| 6   | MNO         |
| 7   | PQRS        |
| 8   | TUV         |
| 9   | WXYZ        |
| 0   | (space)     |
| *   | Backspace   |
| #   | Send / End  |

## Usage Examples

- `OldPhonePad("33#")` → `E`
- `OldPhonePad("227*#")` → `B`
- `OldPhonePad("4433555 555666#")` → `HELLO`
- `OldPhonePad("222 2 22#")` → `CAB`
- `OldPhonePad("8 88777444666*664#")` → `TURING`
- `OldPhonePad("4433555 555666096667775553#")` → `HELLO WORLD`

## How to Run (Terminal)

1. Open a terminal and navigate to the project directory.
2. Build the project:
   ```bash
   dotnet run

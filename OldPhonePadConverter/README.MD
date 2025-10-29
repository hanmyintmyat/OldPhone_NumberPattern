# Old Phone Keypad Converter

A C# console application that simulates typing on an old mobile phone keypad. It converts numeric input into text using the traditional multi-tap system.

## Features

- Multi-tap typing conversion (e.g., press '2' once for 'A', twice for 'B', etc.)
- Backspace support with `*`
- Space handling with `0`
- Input must end with `#` to send/confirm the message
- Pause between letters on the same key by pressing space (` `)

## Keypad Mapping

| Key | Letters |
|-----|---------|
| 1   | (none)  |
| 2   | ABC     |
| 3   | DEF     |
| 4   | GHI     |
| 5   | JKL     |
| 6   | MNO     |
| 7   | PQRS    |
| 8   | TUV     |
| 9   | WXYZ    |
| 0   | (space) |
| *   | Backspace |
| #   | Send/End |

## Usage Examples

- Input: `4433555 555666#`  
  Output: `HELLO`

- Input: `227*#`  
  Output: `B`

- Input: `222 2 22#`  
  Output: `CAB`

## How to Run (Terminal)

1. Open a terminal and navigate to the project directory.
2. Build the project:

   ```bash
   dotnet run

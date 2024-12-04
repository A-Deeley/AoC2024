using aoc_2024.IO;

namespace aoc_2024;

public partial class Day4(IPuzzleInputReader reader)
{
    readonly string input = reader.GetPuzzleInput(4);
    static readonly char[] xmas = ['X', 'M', 'A', 'S'];

    public object RunPart1()
    {
        int xsize = input.IndexOf('\n');
        List<char> puzzle = [.. input.Replace("\n", "").ToCharArray()];
        int xmasesFound = 0;
        List<int> indexesThatStartXmas = new List<int>();
        for (int y = 0; y < puzzle.Count / xsize; y++)
        {
            for (int x = 0; x < xsize; x++)
            {
                int currentIndex = xsize * y + x;
                if (puzzle[currentIndex] == 'X')
                {
                    // Check top row { -1, 0, +1 }
                    for (int dir = -1; dir < 2; dir++)
                    {
                        int difference = -xsize + dir;
                        if (currentIndex + difference < 0 || currentIndex + difference >= puzzle.Count) continue;
                        if (x == 0 && difference < -xsize) continue;
                        if (x == xsize - 1 && difference > -xsize) continue;

                        bool xmasFound = ContainsXMASPart(puzzle, currentIndex, difference, xsize, 1);
                        if (xmasFound) indexesThatStartXmas.Add(currentIndex);
                    }

                    // Check adjacent { -1, +1 }
                    for (int dir = -1; dir < 2; dir+=2)
                    {
                        if (currentIndex + dir < 0 || currentIndex + dir >= puzzle.Count) continue;
                        if (x == 0 && dir < x) continue;
                        if (x == xsize - 1 && dir + x >= xsize) continue;

                        bool xmasFound = ContainsXMASPart(puzzle, currentIndex, dir, xsize, 1);
                        if (xmasFound) indexesThatStartXmas.Add(currentIndex);
                    }

                    // Check bottom row { -1, 0, +1 }
                    for (int dir = -1; dir < 2; dir++)
                    {
                        int difference = xsize + dir;
                        if (currentIndex + difference < 0 || currentIndex + difference >= puzzle.Count) continue;
                        if (x == 0 && difference < xsize) continue;
                        if (x == xsize - 1 && difference > xsize) continue;

                        bool xmasFound = ContainsXMASPart(puzzle, currentIndex, difference, xsize, 1);
                        if (xmasFound) indexesThatStartXmas.Add(currentIndex);
                    }
                }       
            }
        }

        return indexesThatStartXmas.Count;
    }

    static bool ContainsXMASPart(List<char> arr, int currentIndex, int indexDelta, int xsize, int xmasIndex)
    {
        // If we managed to get through all indices of XMAS, we must have found it. Therefore, return true.
        if (xmasIndex == xmas.Length) return true;

        int nextCurrentIndex = currentIndex + indexDelta;

        // If we would be to exit the bounds of the array, the word cannot be completed.
        if (nextCurrentIndex < 0 || nextCurrentIndex >= arr.Count) return false;
        if (currentIndex % xsize == 0 && (indexDelta < -xsize || indexDelta == xsize - 1)) return false;
        if (currentIndex % xsize == xsize - 1 && (indexDelta > xsize || indexDelta == -xsize + 1)) return false;

        if (arr[nextCurrentIndex] == xmas[xmasIndex]) return ContainsXMASPart(arr, nextCurrentIndex, indexDelta, xsize, ++xmasIndex);

        // Next slot is not a letter that contributes to spelling 'XMAS', so the chain is broken.
        return false;
    }

    public object RunPart2()
    {
        throw new NotImplementedException();
    }
}
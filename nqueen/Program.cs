using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static int _count = 0;

        public static void Main()
        {
            const int number = 8;
            var conflictMap = new int[number, number];
            var checkerboard = new int[number, number];
            NQueen(number, checkerboard, conflictMap);
        }


        private static void NQueen(int number, int[,] checkerboard, int[,] conflictMap)
        {
            if (number > 0)
            {
                for (var i = 0; i < checkerboard.GetLength(0); i++)
                {
                    if (IsCorrect(i, number - 1, conflictMap))
                    {
                        PlaceQueen(i, number - 1, checkerboard, conflictMap);
                        NQueen(number - 1, checkerboard, conflictMap);
                        RemoveQueen(i, number - 1, checkerboard, conflictMap);
                    }
                }
            }
            else
            {
                _count++;
                PrintBoard(checkerboard, _count);
            }
        }

        private static void RemoveQueen(int col, int row, int[,] checkerboard, int[,] conflictMap)
        {
            checkerboard[col, row] = 0;

            SetConflict(col, row, conflictMap, -1);
        }


        private static void PlaceQueen(int col, int row, int[,] checkerboard, int[,] conflictMap)
        {
            checkerboard[col, row] = 1;

            SetConflict(col, row, conflictMap, 1);
        }

        private static void SetConflict(int col, int row, int[,] conflictMap, int addValue)
        {
            var length = conflictMap.GetLength(0);

            for (int i = row; i >= 0; i--)
            {
                conflictMap[col, i] += addValue;
            }

            for (int i = col + 1, j = row - 1; i < length && j >= 0; i++, j--)
            {
                conflictMap[i, j] += addValue;
            }

            for (int i = col - 1, j = row - 1; i >= 0 && j >= 0; i--, j--)
            {
                conflictMap[i, j] += addValue;
            }
        }

        private static void PrintBoard(int[,] checkerboard, int count)
        {
            Console.WriteLine("//Solution " + count);
            for (var i = 0; i < checkerboard.GetLength(0); i++)
            {
                for (var j = 0; j < checkerboard.GetLength(1); j++)
                {
                    Console.Write(checkerboard[i, j] == 0 ? "." : "Q");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /*
            01234567
         0  .....Q..
         1  ..Q.....
         2  ....Q...
         3  ......Q.
         4  Q.......
         5  ...Q....
         6  .Q......
         7  .......Q
        */

        private static bool IsCorrect(int col, int row, int[,] conflictMap)
        {
            return conflictMap[col, row] == 0;
        }
    }
}
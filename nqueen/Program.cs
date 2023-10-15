using System;

namespace ConsoleApplication1
{

    
    internal class Program
    {
        private static int _count = 0;

        public static void Main(string[] args)
        {
            const int number = 8;
            var array = new int[number, number];
            Backtracking(number, array);
        }


        private static void Backtracking(int number, int[,] checkerboard)
        {
            var length = checkerboard.GetLength(0);

            if (number > 0)
            {
                for (var i = 0; i < length; i++)
                {
                    if (ForwardChecking(i, number-1, checkerboard))
                    {
                        checkerboard[i, number - 1] = 1;
                        Backtracking(number - 1, checkerboard);
                        checkerboard[i, number - 1] = 0;
                    }
                }
            }
            else
            {
                _count++;
                PrintBoard(checkerboard, length,_count);
            }
        }

        private static void PrintBoard(int[,] checkerboard, int length,int count)
        {
            Console.WriteLine("//Solution " + count);
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
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

        private static bool ForwardChecking(int col, int row, int[,] checkerboard)
        {
            var length = checkerboard.GetLength(0);
            for (int i = row; i < length; i++)
            {
                if (checkerboard[col, i] == 1)
                    return false;
            }
            
            for (int i = col, j = row; i >=0  && j < length; i--, j++)
            {
                if (checkerboard[i, j] == 1)
                    return false;
            }
            
            for (int i = col, j = row; i < length && j < length; i++, j++)
            {
                if (checkerboard[i, j] == 1)
                    return false;
            }

            return true;
        }
    }
}
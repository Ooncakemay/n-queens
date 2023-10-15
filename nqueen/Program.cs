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
                    if (ForwardChecking(i, number - 1, checkerboard))
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
                Console.WriteLine("//Solution " + _count );
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
        }

        private static bool ForwardChecking(int i, int j, int[,] checkerboard)
        {
            var length = checkerboard.GetLength(0);
            int s, t;
            for (s = i, t = 0; t < length; t++)
                if (checkerboard[s, t] == 1 && t != j)
                    return false; //判斷行
            for (t = j, s = 0; s < length; s++)
                if (checkerboard[s, t] == 1 && s != i)
                    return false; //判斷列
            for (s = i - 1, t = j - 1; s >= 0 && t >= 0; s--, t--)
                if (checkerboard[s, t] == 1)
                    return false; //判斷左上方
            for (s = i + 1, t = j + 1; s < length && t < length; s++, t++)
                if (checkerboard[s, t] == 1)
                    return false; //判斷右下方
            for (s = i - 1, t = j + 1; s >= 0 && t < length; s--, t++)
                if (checkerboard[s, t] == 1)
                    return false; //判斷右上方
            for (s = i + 1, t = j - 1; s < length && t >= 0; s++, t--)
                if (checkerboard[s, t] == 1)
                    return false; //判斷左下方
            return true; 
        }
    }
}
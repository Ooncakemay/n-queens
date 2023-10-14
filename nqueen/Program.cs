using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static int count = 0;
        public static void Main(string[] args)
        {
            var number = 4;
        
            int[,] array = new int[number, number];
          
        
            printAll(number,array);

        }

        private static void printAll(int number,int[,] array){
            if(number > 0){
                for(var i = 0; i < array.GetLength(0) ; i++)
                {
                    array[i,number-1] = 1;
                    printAll(number-1,array);
                    array[i,number-1] = 0;
                }
            
            }else
            {
                count++;
                Console.WriteLine("第:" + count+"個");
                for(var i = 0; i < array.GetLength(0) ;i++)
                {
                    for(var j=0;j < array.GetLength(1);j++)
                    {
                        Console.Write( array[i, j]);
                    }
                    Console.WriteLine ();
                }
                Console.WriteLine ();
            
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fibonacci_csharp
{
    class Program
    {
        public static ulong fibonacci(ulong number)
        {


            if (number == 0 || number == 1)
            {
                return number;
            }
            else
            {
                return fibonacci(number - 1) + fibonacci(number - 2);
            } 
      



        }

        static void Main(string[] args)
        {


            ulong start = 0;
            ulong finish = 0;

            Console.Write("This program calculates the Fibonacci sequence for N\n");


            Console.Write("Start N with: ");
            start = ulong.Parse( Console.ReadLine());

            Console.Write("Finish N with: ");
            finish = ulong.Parse(Console.ReadLine());


            Console.Write("\n---------------------------------------------------\n");

            Console.WriteLine("Start\t\t\t\t\t\t\t" + DateTime.Now.ToString() );

            for (ulong i = start; i <= finish; i++)
            {

                Console.Write("Fibonacci N:"+i+" = "+ fibonacci(i) );

                Console.WriteLine("\t   ;\t   "+i+"    \t;\t"+ DateTime.Now.ToString());


            }
            Console.Write("---------------------------------------------------\n");


            Console.ReadKey();




        }
    }
}

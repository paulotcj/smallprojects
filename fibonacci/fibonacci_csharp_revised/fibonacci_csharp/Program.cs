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


	        ulong fn1 = 0;
	        ulong fn2 = 0;
	        ulong result = 0;
        	
	        ulong result_t1 = 0;
	        ulong result_t2 = 0;

            if (number < 2)
            {
                return number;
            }
            else
            {
                result_t2 = 0;
                result_t1 = 1;
                result = 1;

                for (ulong i = 2; i <= number; i++)
                {
                    fn2 = result_t2;
                    fn1 = result_t1;
                    

                    result_t2 = result_t1;
                    result = fn1 + fn2;
                    result_t1 = result;
                }
                return result;
            }

        }

        static void Main(string[] args)
        {


            ulong start = 0;
            ulong finish = 0;

            Console.Write("This program calculates the Fibonacci sequence for N\n");


            Console.Write("Start N with: ");
            start = ulong.Parse(Console.ReadLine());

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

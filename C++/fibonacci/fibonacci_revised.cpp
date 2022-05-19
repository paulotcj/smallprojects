#include <iostream>
#include <ctime>

using namespace std;

unsigned long long int fibonacci(long number ){
	
	        long fn1 = 0;
	        long fn2 = 0;
	        long result = 0;
        	
	        long result_t1 = 0;
	        long result_t2 = 0;

            if (number < 2)
            {
                return number;
            }
            else
            {
                result_t2 = 0;
                result_t1 = 1;
                result = 1;

                for (int i = 2; i <= number; i++)
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



int main()
{

	int start = 0;
	int finish = 0;
	
	printf("This program calculates the Fibonacci sequence for N\n");
	
	printf("Start N with: ");
	cin >> start;
	printf("Finish N with: ");
	cin >> finish;


	printf("\n---------------------------------------------------\n");
	time_t ctt = time(0);
	printf("Start\t\t\t\t\t\t\t%s", asctime(localtime(&ctt)) );

	for(int i = start; i <= finish; i++ )
	{
		printf("Fibonacci N:%d = %d ", i , fibonacci(i)   );
		ctt = time(0);
		printf("\t   ;\t   %d    \t;\t%s", i , asctime(localtime(&ctt))    );
		
	}
	printf("---------------------------------------------------\n");
	
	return 0;

}




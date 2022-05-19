#include <iostream>
#include <ctime>

using namespace std;

unsigned long long int fibonacci(unsigned long long int number ){
	if ( number == 0  ||  number == 1  )
	{
		return number;
	}
	else {
		return fibonacci(number - 1) + fibonacci(number - 2);
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




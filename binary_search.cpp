#include <stdio.h>


//the values match the array index for an easier comparison
int intArray[] = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};

int MAXSIZE = sizeof(intArray)/sizeof(int);

//-----------------------------------------------------------------
void printArray()
{
   printf("[ ");
   for( int i = 0 ; i<MAXSIZE ; i++ )
   {
      printf("%d, ",intArray[i]);
   }
   printf(" ]\n");
}


//-----------------------------------------------------------------
int find(int data)
{

    int upperLimit = MAXSIZE - 1;
    int lowerLimit = 0;
    int midPoint = - 1;



    while(lowerLimit <= upperLimit)
    {

        //breaks the array in two halves and adds the lower limit in the loop
        //  eg: middle point between 10 and 5 is 7.5 because  ->  5 + ( 10 - 5)/2 = 7.5
        midPoint = lowerLimit + (upperLimit - lowerLimit) / 2;


        //-----------------------------------
        // check in which half of the array is the data, upper or lower
        if(data > intArray[midPoint]) { // data is in the upper limit
            lowerLimit = midPoint + 1;
        }
        else // data is in the lower limit
        {

            if(intArray[midPoint] == data) //index found
            {
                return midPoint;
                break;
            }
            else{ //upperLimit assumes the position of the midpoint less 1 and then proceeds to the next interaction of the loop
                upperLimit = midPoint - 1;
            }


        }

    }

    return -1;

}





//-----------------------------------------------------------------
int main()
{
    printf("Array : ");
    printArray();

    printf("\nLocation of 13 in the array: %d" , find(13)  );
    printf("\nLocation of 19 in the array: %d" , find(19)  );
    printf("\nLocation of 0 in the array: %d" , find(0)  );
    printf("\n\n   Checking for non-existent numbers in the array, the \n    index result should be -1 \n");
    printf("\nLocation of -1 in the array: %d" , find(-1)  );
    printf("\nLocation of 20 in the array: %d" , find(20)  );




    printf("\n--------------------------------------------------------\n");

    return 0;
}

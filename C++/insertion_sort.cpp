#include <stdio.h>

//-----------------------------------------------------------------
//Sorting in non decreasing order
void printArray( int arr[], int len )
{
    printf("[ ");
    for ( int i = 0; i < len ; i++ )
    {
        printf("%d, ",arr[i] );
    }

    printf("]\n");

}


//-----------------------------------------------------------------
// Insertion Sort (1) takes one element being tested/ compared ( arr[i] )
//  from the array and stores it in a temp variable, (2) then it starts comparing
//  the values of all elements in the previous positions of the array, (3) if the
//  previous element is bigger than the value of the temp variable it moves the element
//  one position up in the array, (4) when it detects that all the previous variables aren't
//  bigger than the temp variable, or when there are no elements left to compare
//  (i.e. j = -1 in the array) the while condition reaches an end and then
//  (5) the slot left empty by all swaps receives the temp var

void insertionSort( int arr[], int len )
{

    int operations = 0;

    //runs through the array
    for(int i = 1 ; i < len ; i++ )
    {

      int j = i - 1; //J is the base position to be compared, it starts with 0;
      int nextSwap = arr[j+1]; //temp var necessary for swapping numbers between positions of the array



      //comparing all the previous elements in the array, if they are bigger than
      //  the temp var (nextSwap), it moves the element one position up in the array
      while( arr[j] > nextSwap  &&  j > -1 )
      {
          arr[j + 1] = arr[j]; //the upper index receives the bigger value
          j--;
          operations++;
      }


      //in this case either there is nothing left to compare or all previous
      //  variables in the array are ordered, so the temp var (nextSwap) is
      //  inserted in the empty position (arr(j+1))
      arr[j+1] = nextSwap;

      operations++;

      //-------
      printf("Loop %d - ",i);
      printArray(arr, len);
      //-------
    }
    printf("Operations: %d\n\n",operations);
}



//-----------------------------------------------------------------
int main()
{
    //a regular array to be ordered
    int arr1[] = {5, 3, 1, 0, 4, 3, 2, 1};
    int len = sizeof(arr1) / sizeof(int);
    printf("\nRegular array\nIni Array");
    printArray(arr1, len);
    insertionSort(arr1, len);

    printf("\n--------------------------------------\n");


    //worst case scenario
    int arr2[] = {8, 7, 6, 5, 4, 3, 2, 1};
    len = sizeof(arr2) / sizeof(int);
    printf("\nWorst case scenario\nIni array");
    printArray(arr2, len);
    insertionSort(arr2, len);


    printf("\n--------------------------------------\n");


    //best case scenario
    int arr3[] = {1, 2, 3, 4, 5, 6, 7, 8};
    len = sizeof(arr3) / sizeof(int);
    printf("\nBest case scenario\nIni array");
    printArray(arr3, len);
    insertionSort(arr3, len);



    return 0;
}

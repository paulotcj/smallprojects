#include <stdio.h>


//---------------------------------------------------------------------------------------------------
void printArray(int arr[], int len)
{
	
	printf("[");
	for (int i = 0; i < len; i++)
	{
		//printf(arr[i] + ", ");
		printf("%d, ", arr[i] );
	}
	printf("]\n");

}


//---------------------------------------------------------------------------------------------------
//switches the position between a lower index with a higher index
static void swapBubbleSort(int arr[], int lowerIndex, int upperIndex)
{
	int temp = arr[lowerIndex];
	arr[lowerIndex] = arr[upperIndex];
	arr[upperIndex] = temp;
}


//---------------------------------------------------------------------------------------------------
void bubbleSort(int arr[], int len)
{

    int hasChanged = 1; //runs at least once

    //runs through the length of the array 
    // also checks if the previous run has made no changes, if so the array is sorted
    for (int i = 0; i < (len - 1) && hasChanged != 0; i++)
    {
        hasChanged = 0;

		//after every loop in this inner loop the biggest number/element will be placed at the end of the array
		// that's why in the condition is specified as ( - i), since every loop of the parent 'for' will place the highest number at
		// the end there is no need to go through the entire array
        for (int j = 0; j < (len -1) - i; j++)
        {
            //if the data in a lower position (arr[j]) in the index have a bigger value than the data in a higher position (arr[j + 1])
            if (arr[j] > arr[j + 1])
            {
                swapBubbleSort(arr, j, j + 1); //swaps the data between the positions
                hasChanged = 1; //Flag this loop with an occurrence of change
            }
        }
        //printArray(arr,len); //uncomment this line to see each loop of the algorithmn
       
    }

}


//---------------------------------------------------------------------------------------------------
int main()
{

	//initializing the array
	int arr[] = { 6, 4, 2, 1, 10, 8, 3, 9, 7, 5 };
	int len = sizeof(arr)/sizeof(int);

	//-------------------------------------
	printf("Initial Array");
	printArray(arr, len);
	bubbleSort(arr,len);

	//-------------------------------------
	printf("Final Array :"  );
	printArray(arr,len);



	return 0;

}

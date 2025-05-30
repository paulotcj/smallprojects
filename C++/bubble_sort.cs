using System;



namespace bubble_sort
{
    class bubble_sort
    {


        //---------------------------------------------------------------------------------------------------
        //switches the position between a lower index with a higher index
        static void swapBubbleSort(int[] arr, int lowerIndex, int upperIndex)
        {
            int temp = arr[lowerIndex];
            arr[lowerIndex] = arr[upperIndex];
            arr[upperIndex] = temp;
        }

        //---------------------------------------------------------------------------------------------------
        static void bubbleSort(int[] arr)
        {
            int hasChanged = 1; //runs at least once

            //runs through the length of the array 
            // also checks if the previous run has made no changes, if so the array is sorted
            for (int i = 0; i < (arr.Length - 1) && hasChanged != 0; i++)
            {
                hasChanged = 0;

				//after every loop in this inner loop the biggest number/element will be placed at the end of the array
				// that's why in the condition is specified as ( - i), since every loop of the parent 'for' will place the highest number at
				// the end there is no need to go through the entire array
                for (int j = 0; j < (arr.Length -1) - i; j++)
                {
                    //if the data in a lower position (arr[j]) in the index have a bigger value than the data in a higher position (arr[j + 1])
                    if (arr[j] > arr[j + 1])
                    {
                        swapBubbleSort(arr, j, j + 1); //swaps the data between the positions
                        hasChanged = 1; //Flag this loop with an occurrence of change
                    }
                }
                //printArray(arr); //uncomment this line to see each loop of the algorithmn
               
            }



        }

        //---------------------------------------------------------------------------------------------------
        static void printArray(int[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.Write("]\n");

        }

        //---------------------------------------------------------------------------------------------------
        static void Main()
        {

            //initializing the array
            int[] arr = { 6, 4, 2, 1, 10, 8, 3, 9, 7, 5 };

            Console.Write("Initial Array");
            printArray(arr);

            //-------------------------------------
            DateTime time1 = System.DateTime.Now;
            bubbleSort(arr);
            DateTime time2 = System.DateTime.Now;

            //-------------------------------------
            Console.Write("Final Array :"  );
            printArray(arr);
            Console.Write("Elapsed time:" + (time2 - time1).ToString());
            Console.ReadKey();

            

        }



    }
}

#include<stdio.h>
#include<stdlib.h>





int find(int data , int arr[], int length) {
    int start = 0;
    int end = length-1;
    int midPoint = 0;

    double ratio = 0;
    double refDiff = 0;


    printf("\nLooking for the number: %d", data);

    while(start <= end)
    {


        ratio = (double)(end-start)/(arr[end]-arr[start]) ;
        refDiff = double(data - arr[start]) ;

        midPoint = start + ratio * refDiff  ;

        printf("\nRatio:    %f", ratio);
        printf("\nrefDiff:  %f\n", refDiff);


        printf("\nStart:    %d", start);
        printf("\nEnd:      %d", end);
        printf("\nmidPoint: %d", midPoint);
        printf("\n----------");

        //--------------------------------
        if (refDiff < 0)//the refined difference is negative, therefore the number is not in the array
        {
            return -1;
        }
        else if(arr[midPoint] < data) //the number is in the upper part
        {
            start = midPoint + 1;
        }
        else //found the number or is in the lower part
        {

            if(arr[midPoint] == data) //number found
            {
                return midPoint;
                break;
            }
            else{ // number not foud, probably in the lower part

                end = midPoint - 1;
            }


        }

        //--------------------------------
        //remove the comment below to see every interaction of the loop
        //getchar();
    }


    return -1;
}



//-----------------------------------------------------------------
int main() {

    int length = 0;


    printf("\n====================================================");
    printf("\nInterpolation is very fast for elements distributed in linear scale, eg:\n");
    int arr1[] = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40 };
    length = sizeof(arr1)/sizeof(int);
    printf("\nElement found at location: %d" , find(28, arr1 , length)  );


    printf("\n====================================================");
    printf("\nBut performs poorly in a exponential scale, eg:\n");
    int arr2[] = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536 };
    length = sizeof(arr2)/sizeof(int);
    printf("\nElement found at location: %d" , find(256, arr2 , length)  );



    printf("\n====================================================");
    printf("\nHere is a example of a linear scale with the two last elements out of proportion, eg:\n");
    int arr3[] = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 99, 120};
    length = sizeof(arr3)/sizeof(int);
    printf("\nElement found at location: %d" , find(28, arr3 , length)  );



    printf("\n====================================================");
    printf("\nSearching for a non-existent element, eg:\n");
    int arr4[] = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36, 39, 42, 45, 48, 51, 54, 57, 60};
    length = sizeof(arr4)/sizeof(int);
    printf("\nElement found at location: %d" , find(32, arr4 , length)  );




   return 0;
}

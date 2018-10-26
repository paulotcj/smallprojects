#include <stdio.h>

//-------------
#define MAXSIZE 20
//-------------

//the values match the array index for an easier comparison
int elements[MAXSIZE] = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};


//-----------------------------------------------------------------
int find(int data)
{
   for(int i = 0 ;i<MAXSIZE; i++)
   {
     if(elements[i] == data ) { return i;}
   }

   return -1;
}


//-----------------------------------------------------------------
void displayElements() {

   printf("[ ");
   for(int i = 0;i<MAXSIZE;i++)
   {
      printf("%d, ",elements[i]);
   }
   printf(" ]\n");
}


//-----------------------------------------------------------------
int main() {
    printf("Array elements:\n ");
    displayElements();


    int location = find(9);

    if(location != -1)
    {
        printf("\nElement '9' found at location: %d" ,location);
    }
    else
    {
        printf("Element not found.");
    }
    printf("\n--------------------------------------------------------\n");

    return 0;
}

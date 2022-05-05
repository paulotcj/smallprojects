#include <stdio.h>
#include <stdlib.h>

//---------------
#define MAXSIZE 10
//---------------



//the structure of the node |*prev(key,data)*next|
struct node
{
    int data;
		struct node *next;
    struct node *prev;
};


struct node *first= NULL;
struct node *last = NULL;
int counter = 0;

//-----------------------------------------------------------------
int size() {
   return counter;
}


//-----------------------------------------------------------------
bool isFull()
{
   return counter >= MAXSIZE;
}


//-----------------------------------------------------------------
bool isEmpty()
{
   return counter <= 0;
}


//-----------------------------------------------------------------
bool insertQueue(int data)
{
    if(isFull() == true){ return false; }

    struct node *newLink = (struct node*) malloc(sizeof(struct node));
    newLink->data = data;

    if(isEmpty() == true)
    {
      first = newLink;
      last = newLink;
    }
    else{

      last->prev = newLink;
      newLink->next = last;
      last = newLink;
    }

    counter++;

    return true;
}


//-----------------------------------------------------------------
int retrieveQueue() {

    if(isEmpty() == true){ return NULL;}

    int data = first->data;
    struct node *linkDelete = first;

    if(counter==1)
    {
        first = NULL;
        last = NULL;
    }
    else
    {
        first = first->prev;
        first->next = NULL;
    }


    counter--;
    free(linkDelete);

    return data;

}


//-----------------------------------------------------------------
void printQueue()
{
    printf("[ ");
    while( isEmpty()==false )
    {
       printf("%d, ", retrieveQueue() );
    }
    printf(" ]\n");


}


//-----------------------------------------------------------------
int main() {

   insertQueue(2);
   insertQueue(3);
   insertQueue(5);
   insertQueue(7);
   insertQueue(11);
   insertQueue(13);
   insertQueue(17);
   insertQueue(19);
   insertQueue(23);
   insertQueue(29);

   //the elements below will be not inserted since the queue is already full
   insertQueue(31);
   insertQueue(37);


   printf("Is queue full?  %s\n", isFull() ? "true" : "false");


   printf("Element removed: %d\n",retrieveQueue());

   printf("inserting 999 in the queue, result: %s\n", insertQueue(999) ? "true" : "false - queue is full" );

   printf("inserting 111 in the queue, result: %s\n", insertQueue(111) ? "true" : "false - queue is full" );




   printf("\n\nQueue:  ");
   printQueue();

   printf("\n--------------------------------------------------------\n");

}

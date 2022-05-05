#include <stdio.h>

//----------------
#define MAXSIZE 10
//----------------


int stack[MAXSIZE];
int top = -1;


//-------------------------------------------------------------------------
int isEmpty()
{
		if(top < 0 ){ return true; }
		else { return false; }
}


//-------------------------------------------------------------------------
int isFull()
{
		if(top < (MAXSIZE-1) )  { return false; }
		else { return true; }
}


//-------------------------------------------------------------------------
int peek()
{
    return stack[top];
}


//-------------------------------------------------------------------------
int pop()
{
		if( isEmpty()==false )
		{
				return stack[top--];
		}
		else
		{
				return NULL;
		}
}


//-------------------------------------------------------------------------
bool push(int data)
{
    if(isFull()==false)
   	{
		    stack[++top] = data;
	  	  return true;
    }
    return false;
}

void printStack()
{

    printf("[ ");
		while(isEmpty() == false)
		{
				printf("%d, ", pop());
		}
		printf(" ]");

}


//-------------------------------------------------------------------------
int main()
{

		push(2);
		push(3);
		push(5);
		push(7);
		push(11);
		push(13);
		push(17);
		push(19);
		push(23);
		push(29);
		//the elements below won't be inserted as the stack is full
		push(31);
		push(37);
		push(41);

   	//-----------------------------------
		printf("Is the stack full?  -  %s\n", isFull() ? "true" : "false");
		printf("Stack length: %d\n\n", top+1);

		//-----------------------------------
		printf("Peek: %d\n\n" ,peek());


   	//-----------------------------------
   	printf("Stack POP : %d\n", pop());
   	printf("Stack length: %d\n", top+1);
   	printf("Is the stack full?  -  %s\n\n", isFull() ? "true" : "false");

   	//-----------------------------------
		printf("Elements: \n");
		printStack();

		printf("\n\n\nIs the stack full?    -  %s\n" , isFull()  ? "true" : "false" );
   	printf("Is the stack empty?   -  %s\n"   , isEmpty() ? "true" : "false" );

   	return 0;
}

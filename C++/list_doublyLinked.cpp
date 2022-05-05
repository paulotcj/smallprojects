#include <stdio.h>
#include <stdlib.h>

//the structure of the node |*prev(key,data)*next|
struct node
{
		int data;
		int key;
		//----------------
		struct node *next;
   	struct node *prev;
};

struct node *head    = NULL;
struct node *last    = NULL;
struct node *current = NULL;



//--------------------------------------------------
//is list empty
bool listIsEmpty()
{
	return head == NULL;
}

//--------------------------------------------------
bool deleteNode(int key) {

	//start from the first link
	struct node* current = last;

	//if list is empty
	if(listIsEmpty()==true) {
		return NULL;
	}

	//if the key to delete is out of range (ie, greater than the last key or smaller than the first key, return false)
	if(key > last->key || key < head->key){ return false;}

	//search for the node/link
	while(current->key != key )
	{
		current = current->next;
	}

	//case: deleting the head element
	if(current->key==head->key )
	{
		if(head->prev == NULL)
		{
			head = NULL;
			last= NULL;
		}
		else{
			head = head->prev;
			head->next = NULL;
		}
	}
	else if(current->key==last->key) //case: deleting the last element
	{
		last = last->next;
		last->prev = NULL;
	}
	else //it is a link somewhere in between the head and the last
	{
		struct node* previousLink = NULL;
		struct node* nextLink = NULL;

		previousLink = current->prev;
		nextLink = current->next;

		nextLink->prev = current->prev;
		previousLink->next = current->next;
	}


	//updates the key index (in -1) of all previous elements
	for(struct node* i = current; i != NULL; i=i->prev )
	{
		i->key--;
	}

	free (current);


	return true;


}


//--------------------------------------------------
// display all elements of the list from the head to last
void displayForward() {

	for (struct node *ptr = head; ptr != NULL ; ptr = ptr->prev)
	{
		printf("'%p'(%d,%d)'%p'\n ",ptr->prev,ptr->key,ptr->data,ptr->next);
	}

}


//--------------------------------------------------
//display all elements of the list from the last to the head
void displayBackward() {

	for (struct node *ptr = last; ptr != NULL ; ptr = ptr->next)
	{
		printf("'%p'(%d,%d)'%p'\n ",ptr->prev,ptr->key,ptr->data,ptr->next);
	}
}

//--------------------------------------------------
bool insertElement(int data) {

	struct node *link = (struct node*) malloc(sizeof(struct node));

	link->data = data;
	link->prev = NULL;
	link->next = NULL;


   if(listIsEmpty()) {
		//the new element will be the head of the list
		head = link;
		last = link;
		link->key = 0;
	}
	else
	{
		//adding another link in the list - this element will be the last
		last->prev = link;
		link->next = last;
		link->key = last->key + 1;
		last = link;
	}
	return true;

}


//--------------------------------------------------
//delete first item
void deleteFirst() {
	deleteNode(0);
}


//--------------------------------------------------
//delete link at the last location

void deleteLast()
{
	struct node *tempLink = last;
	deleteNode(last->key);
}



//--------------------------------------------------
bool insertAt(int key, int data)
{
	struct node *current = last;

	//------------------------
	//if list is empty
	if(listIsEmpty() == true) {
		insertElement(data);
		return true;
	}


	//if the key informed is bigger than the last key, then the element will be
	//added as the last element in the list
	if(key > last->key){
		insertElement(data);
		return true;
	}
	else if( key < head->key){ //if the key informed is smaller than the head key, the new element should assume the head position
		key = head->key;
	}




	//------------------------
	//searches  for the correct point to insert
	while(current->key != key)
	{
		current = current->next;
	}

	//create a new link
	struct node *newLink = (struct node*) malloc(sizeof(struct node));


	newLink->key = current->key;
	newLink->data = data;


	//------------------------
	if(current->next == NULL){ //current is the first/head node and the new node will assume the head position
		newLink->next = NULL;
		newLink->prev = current;
		current->next = newLink;
		head = newLink;
	}
	else{ // node must be in between two nodes (the case in which the new node is the last was taken care above)
		newLink->next = current->next;
		newLink->prev = current;

		current->next->prev = newLink;
		current->next = newLink;
	}


	//------------------------
	//updates all previous keys in -1
	while(current != NULL)
	{
		current->key++;
		current = current->prev;
	}

	return true;
}

//--------------------------------------------------
bool insertAfter(int key, int data)
{
	return insertAt(key+1, data);
}

//--------------------------------------------------
bool deleteAll()
{
	while(last != NULL)
	{
		deleteLast();
	}

	return true;
}

//--------------------------------------------------
int main() {

	for(int i = 10 ; i<=80 ; i=i+10 )
	{
		insertElement(10);
	}


	printf("\nFirst to Last (key, value):\n ");
	displayForward();

	printf("\n");
	printf("\nLast to first (key, value):\n ");
	displayBackward();


	printf("\nAfter deleting first record:\n ");
	deleteFirst();   //ok
	displayForward();



	printf("\nAfter deleting last record:\n ");
	deleteLast(); //ok
	displayForward();

	printf("\nINSERT AFTER key(3) data(99999):\n ");
	insertAfter(3, 99999);  //ok
	displayForward();

	printf("\nDELETE key(2):\n ");
	deleteNode(2); //ok
	displayForward();

	printf("\nINSERT AT key(1) data(7777):\n ");
	insertAt(1,7777);
	displayForward();

	deleteAll(); //ok
	printf("\nList after deleting all elements:\n ");
	displayForward();


	return 0;
}

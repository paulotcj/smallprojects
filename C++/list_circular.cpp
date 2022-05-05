#include <stdio.h>
#include <stdlib.h>


struct node {
   int data;
   int key;
   struct node *next;
};

struct node *last = NULL;
//struct node *current = NULL;


//--------------------------------------------------------------------------------------
bool isEmpty() {
   return last == NULL;
}


//--------------------------------------------------------------------------------------
int listLength() {
   return last->key+1;
}


//--------------------------------------------------------------------------------------
void insertNode( int data) {

   //create a link
   struct node *link = (struct node*) malloc(sizeof(struct node));

   link->data = data;

	
	if (isEmpty()==true) {
		
		link->key=0;
		last = link;
   		link->next = link;
   		
   } else {
		link->key = last->key +1;
		
		//assumes the last postion
		link->next = last->next;
		last->next = link;
		last = link;
   }    
}




//--------------------------------------------------------------------------------------
bool printList() {
	
	if(isEmpty()==true){ return false; }

	printf("[ address ( key , data ) next ] \n");

  	struct node *ptr = last->next;
	do{
        printf("[");
		printf(" %p ( %d , %d ) %p ", ptr ,  ptr->key,  ptr->data , ptr->next);
		ptr = ptr->next;
        
        printf("]\n");
	} while (ptr != last->next);
	

}



//--------------------------------------------------------------------------------------
//Delete a link/node at the informed index (key)
bool deleteAt(int key)
{
	
	
	//invalid key positions (lower than zero or bigger than the size of the list)
    if(key >= listLength() || key < 0 ){ return false;}
    
    
    //when the list has only one node
    if(listLength() == 1){ 
        free(last);
        last = NULL;
		return true;
	}
	else
	{
		bool deleted = false;
		
		//in order for the current (curr) node to be the first element in the loop 
		// the 'prev' must be the last (hence, circular list)
		struct node *prev = last; 
	  	struct node *curr = last->next;
		
		
		
		
	  	//it must run at least once, and the actual configuration of 'curr' and 'prev' 
		// is the stop condition, so that's the reason for using do{}while();
		do{
			if(curr->key == key){ //found the node/link to be deleted
				
				if(curr == last){ //special case when the node being excluded is the last
					last = prev;
					
					//----------------------
					prev->next = curr->next;
					free(curr);
					curr = prev->next;
					//----------------------
					
					deleted = true;
				}
				else{
				
					//----------------------
					prev->next = curr->next;
					prev = curr->next;
					free(curr);
					curr = prev->next;
					//----------------------
					prev->key--;
					deleted = true;
				}
				
			}
			else
			{
				//checks if a deletion has occured and if the current postion is after the deleted index
				if(deleted == true && curr->key > key) { curr->key--; }
				
				//set the pointers to the next loop
				prev = curr;
				curr = curr->next;
			}
			

		} while (curr != last->next);

		return deleted;
		

	}
    
}

//--------------------------------------------------------------------------------------
//Delete all the elements in the list
bool deleteAll()
{
	while(isEmpty() == false)
	{
		deleteAt(last->key);
	}
	
	return true;
	
}


bool updateAt(int key, int data)
{

	bool update = false;
	struct node *curr = last->next;
	
	
	//invalid key positions (lower than zero or bigger than the size of the list)
    if(key >= listLength() || key < 0 ){ return false;}
	
	do
	{
		if(curr->key == key) { 
			curr->data = data; 
			update = true;
		}
		curr = curr->next;
	}while(curr != last->next);
	
	return update;

}




//--------------------------------------------------------------------------------------
int main() {
	
	insertNode(10);
	insertNode(20);
	insertNode(30);
	insertNode(40);
	insertNode(50);
	insertNode(60); 

	//-------------------------------------------
	printf("Original List: "); 
	printList();
	
	
	printf("\n\nList length: %d \n\n", listLength());


	printf("\nDeleting at index 2 : "); 
	deleteAt(2);
	printList();
	
	
	printf("\nDeleting at index 4 : "); 
	deleteAt(4);
	printList();
	
	printf("\nDeleting at index 0 : "); 
	deleteAt(0);
	printList();
	

	printf("\n Update at index: 1 value: 999  "); 
	updateAt(1,999);
	printList();


	printf("\nList after deleting all items: ");
	deleteAll();
	printList();   
    return 0;
    

}

// ############################################################################
//
//This Hash Table implementation use Separate chaining with linked lists as a
// form to deal with hash collisions
//
// author: Paulo Costa
// ############################################################################


#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//-------------
#define MAXSIZE 26
//-------------

struct contact
{
		char name[20];
		int telephone;
		//----------------
		struct contact *next;
};

struct contact *contacts[MAXSIZE];



//-----------------------------------------------------------------
int hashFunction(char param[] )
{

  if(param[0] >= 65 && param[0] <= 90 ) //lower case letters
  {
    return param[0] - 65; //shifting the returned index/key
  }
  else if (param[0] >= 97 && param[0] <= 122) //upper case letters
  {
    return param[0] - 97; //shifting the returned index/key
  }
  else { return -1; } //invalid entry, return -1
}


//-----------------------------------------------------------------
bool insertHashTable(char name[], int telephone )
{
  int position = hashFunction(name);
  if(position == -1){ return false; } //invalid name

  //new contact
  struct contact *newContact = (struct contact*) malloc(sizeof(struct contact));
  strncpy(newContact->name , name, 20);
  newContact->telephone = telephone;
  newContact->next = NULL;

  //------------------
  if(contacts[position]== NULL) //the bucket is empty
  {
    contacts[position] = newContact;
  }
  else //collision case, the new link/node will assume the root index in the array
  {
    newContact->next = contacts[position];
    contacts[position] = newContact;
  }
  //------------------

  return true;
}



//-----------------------------------------------------------------
void printHash()
{
  //loop through the length of the array
  for(int i = 0 ; i < MAXSIZE ; i++)
  {

    //---------
    if (contacts[i] == NULL) //if the bucket is empty, print the memory address
    {
        printf("\n%c - '%p'", (i +65),  contacts[i]);
    }
    else //the bucket is not empty, printing the contact info...
    {
			printf("\n%c", (i +65) );
      //---------
      // There might be more than one contact in this bucket, in this case it is
      //  necessary to run through the list printing every contact within it
      for (struct contact* temp = contacts[i]; temp != NULL; temp = temp->next)
      {
        printf("\n    '%p'(name: %s, number: %d) next:'%p' ",temp,temp->name,temp->telephone,temp->next);
      }
      //---------
      printf("\n  ---------------------");

    }

  }
}


//-----------------------------------------------------------------
// this function searches for the contact informed in the parameter 'name', and then
//   if the contact is found returns the target contact in contParam[1]
//   and the previous contact (if it exists) in contParam[0]
bool findContact(char name[] , struct contact *contParam[] )
{
  int position = hashFunction(name);
  if(position == -1){ return false; } //invalid position


  struct contact* prev = NULL;

  //runs through the list in the index array 'contacts[position]'
  for (struct contact* temp = contacts[position]; temp != NULL; temp = temp->next)
  {
    if (strcmp(name,temp->name)== 0 )//contact found
    {
      contParam[0] = prev;
      contParam[1] = temp;
      return true;
    }
    prev = temp; //keeping track of the prev link/node
  }

  return false;
}


//-----------------------------------------------------------------
// This function print the contact info in details
bool getContactDetails(char name[])
{
  struct contact *prevAndTarget[2];
  findContact(name,prevAndTarget);

  if ( prevAndTarget[1] == NULL) //contact not found
  {
    printf("\nContact Not Found");
    return false;
  }
  else { //contact found
    printf("\n  addr: '%p'(name: %s, number: %d) next:'%p' ",prevAndTarget[1],prevAndTarget[1]->name,prevAndTarget[1]->telephone,prevAndTarget[1]->next);
    return true;
  }

}

//-----------------------------------------------------------------
bool deleteContact(char name[])
{
  int position = hashFunction(name);
  if(position == -1) { return NULL; }


  //-----------------
  // The code below brings the target contact (considering it exists) to the position prevAndTarget[1]
  //  and the previous node/link (considering it exists) to the postion prevAndTarget[0]
  //
  //  if the target contar does not exist in the list the function findContact() will return false.
  struct contact *prevAndTarget[2];
  if ( findContact(name,prevAndTarget) == false) { return false; }
  //-----------------


  if (contacts[position] == prevAndTarget[1]) //the target contact is the first in the array-list
  {
    contacts[position] = prevAndTarget[1]->next;
  }
  else //contact is a node/link after the root index
  {
    prevAndTarget[0]->next = prevAndTarget[1]->next;
  }
  free (prevAndTarget[1]);
  return true;

}


//-----------------------------------------------------------------
int main()
{

  char name1[20] = "Joanna";
  int  tel1 = 1111111;

  char name2[20] = "mike";
  int  tel2 = 2222222;

  char name3[20] = "Jen";
  int  tel3 = 3333333;

  char name4[20] = "Paul";
  int  tel4 = 4444444;

  char name5[20] = "kurt";
  int  tel5 = 5555555;

  char name6[20] = "JIM";
  int  tel6 = 6666666;

  char name7[20] = "Corey";



  insertHashTable(name1, tel1);
  insertHashTable(name2, tel2);
  insertHashTable(name3, tel3);
  insertHashTable(name4, tel4);
  insertHashTable(name5, tel5);
  insertHashTable(name6, tel6);

  printf("\nPrinting the hash table:\n");
  printHash();
  printf("\n==========================");

  printf("\n\nSearching for a contact in the list (Jen):");
  getContactDetails(name3);
  printf("\n\nSearching for a contact NOT in the list (Corey):");
  getContactDetails(name7);
  printf("\n\n\n");


  printf("\nRemoving Jen from the list");
  deleteContact(name3);
  printf("\nPrinting the hash table:\n");
  printHash();


  return 0;
}

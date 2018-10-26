#include <stdio.h>


int arraySize = 5;
int* elementsArray;

	
//--------------------------------------------------------------
//creates an array with 5 elements ranging from 10 to 50
bool createArray()
{
	elementsArray  = new int[arraySize];
	
	for(int i = 0; i<= 4; i++)
	{
		elementsArray[i] = i*10 + 10;
	}
	
	return true;
}


//--------------------------------------------------------------
bool printArrayElements()
{
   for(int i = 0; i < arraySize ; i++) 
	{
		printf("elementsArray[%d] = %d \n", i, elementsArray[i]);
	}
	
	return true;
}

//--------------------------------------------------------------
// inserts the new element in the position indicated by the key
bool insertAt(int key, int number)
{
	
	//it is not permitted to insert at an index below 0 or higher than the array size
	if(key < 0){ key = 0;} 
	else if (key>arraySize ) {key = arraySize;	}
	
	//-------------------------
	//copy the contents of the old array to the new one
	int* new_array = new int[arraySize + 1];
	for (int i = 0; i < arraySize; i++)
	{
		
		if(i < key) { new_array[i] = elementsArray[i]; } //copying the elements before the insertion point
		else { 	new_array[i+1] = elementsArray[i]; 	} //copying the elements after the insertion point (copy to the next position leaving the key slot available)
		
	}
	
	new_array[key] = number;
	arraySize++;
	
	delete [] elementsArray;
	elementsArray = new_array; 

	return true;
   
}


//--------------------------------------------------------------
bool updateAt(int key, int number)
{
	//trying to update an invalid position
	if(key < 0 || key>arraySize-1 ){ return false;} 
	
	elementsArray[key] = number;

	return true;
}


//--------------------------------------------------------------
int arraySearch(int number)
{

	//searches for the element within the array
	for(int i = 0; i<arraySize; i++)
	{
		if(elementsArray[i]==number){ return i;} //return the element position in the array
	}
	
	//element not found
	return -1;
}


//--------------------------------------------------------------
bool deleteAt(int key)
{
	//trying to delete an invalid position
	if(key < 0 || key>arraySize-1 ){ return false;} 
	
	int* new_array = new int[arraySize - 1];
	
	
	for (int i = 0; i < arraySize; i++)
	{
		
		if(i < key) { new_array[i] = elementsArray[i]; } //copying the elements before the deletion point
		else { 	new_array[i] = elementsArray[i+1]; 	} //copying the elements after the deletion point (copy to the next position)
		
	}
	

	arraySize--;
	
	delete [] elementsArray;
	elementsArray = new_array; 

	return true;
	
}

bool deleteAll()
{
	
	while(arraySize>0)
	{
		deleteAt(arraySize-1);
	}

	return true;
}


//--------------------------------------------------------------
int main() {

	createArray();
	
	//-------------------------
	printf("_________________________________________\n");
	printf("Original array elements :\n");
	printArrayElements();

	//-------------------------
	insertAt(-1,999);
	printf("_________________________________________\n");
	printf("The array elements after insertion (-1,999) :\n");
 	printArrayElements();
	
	//-------------------------
	updateAt(6,33);
	printf("_________________________________________\n");
	printf("The array elements after update (6,33) :\n");
 	printArrayElements();
	
	//-------------------------
	printf("_________________________________________\n");
	printf("Search for elements within the array (Position -1 means the element was not found)\n");
	printf("Position of the element 30 in the array :\n");
	printf("%d\n", arraySearch( 30));
	printf("Position of the element -333 in the array :\n");
	printf("%d\n", arraySearch( -333));
	
	
	//-------------------------
	deleteAt(2);
	printf("_________________________________________\n");
	printf("The array elements after a delete at position 2 :\n");
 	printArrayElements();
	
	
	//-------------------------
	deleteAll();
	printf("_________________________________________\n");
	printf("The array elements after deleting all the elements :\n");
 	printArrayElements();
	
   return 0;
}

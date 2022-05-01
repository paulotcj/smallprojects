// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;
print("Hello, World!");

Simple_LinkedList();




static void Simple_LinkedList()
{
    Action<string> print = Console.WriteLine;

    var myBaseLinkedList = new MyBaseLinkedList(2);
    myBaseLinkedList.PrintList();
    print("################################");

    myBaseLinkedList.Add(4);
    myBaseLinkedList.Add(6);
    myBaseLinkedList.Add(8);
    myBaseLinkedList.Add(10);

    myBaseLinkedList.PrintList();

    print("################################");

    myBaseLinkedList.AddAtBeginning(99);

    myBaseLinkedList.PrintList();

    print("################################");

    myBaseLinkedList.AddAtIndex(2,11);

    myBaseLinkedList.PrintList();

    print("################################");

    print($"Trying to find 11 : {myBaseLinkedList.LookUp(11)}");

    print($"Trying to find 200 : {myBaseLinkedList.LookUp(200)}");


    print("################################");
    print("Deleting elements...");
    myBaseLinkedList.Delete(11);
    myBaseLinkedList.PrintList();
    print("----");
    myBaseLinkedList.Delete(10);
    myBaseLinkedList.PrintList();
    print("----");
    myBaseLinkedList.Delete(99);
    myBaseLinkedList.PrintList();
}


//--------------------------------------------



public class MyBaseLinkedList
{
    public MyBaseNode? lastAdded = null;
    public int count = 0;


    public MyBaseLinkedList(int value)
    {
        Add(value);
    }

    public void Add(int value)
    {
        var newEntry = new MyBaseNode();
        newEntry.nodeValue = value;
        newEntry.next = lastAdded;
        lastAdded = newEntry;
        count++;
    }

    public void AddAtBeginning(int value)
    {
        var current = lastAdded;
        while (current.next != null)
        {
            current = current.next;
        }

        //reached the end of the list
        var newEntry = new MyBaseNode();
        newEntry.nodeValue = value;
        newEntry.next = null;

        current.next = newEntry;
        count++;

    }

    public void AddAtIndex(int index, int value)
    {
        if (index < 0 || index >= count) { return; }
        MyBaseNode current = lastAdded;
        MyBaseNode previous = null;

        for (int i = 0; i< index; i++)
        {

            previous = current;
            current = current.next;
        }



        var newEntry = new MyBaseNode();
        newEntry.nodeValue = value;

        if (previous != null)
        {
            previous.next = newEntry;
        }

        newEntry.next = current;

        if (lastAdded == current) { lastAdded = newEntry; }

        count++;


    }

    public int? LookUp(int value)
    {
        var current = lastAdded;
        while (current != null)
        {
            if (current.nodeValue == value) { return current.nodeValue; }
            current = current.next;
        }

        return null;

    }

    public void Delete(int value)
    {
        MyBaseNode current = lastAdded;
        MyBaseNode previous = null;

        if (count <= 0) { return; }

        while (current != null)
        {
            if (current.nodeValue == value) { break; }
            previous = current;
            current = current.next;
        }

        //the loop is over, we wither have the value on the current node, or the value doesn't exist
        // in this list
        if (current.nodeValue != value) { return; }

        if (previous != null) { previous.next = current.next; }
        else { lastAdded = lastAdded.next; }

        count--;

    }

    public void PrintList()
    {
        var current = lastAdded;
        while (current != null)
        {
            Console.WriteLine($"Value : {current.nodeValue}");
            current = current.next;
        }
    }


}

public class MyBaseNode
{
    public MyBaseNode? next;
    public int nodeValue;
}


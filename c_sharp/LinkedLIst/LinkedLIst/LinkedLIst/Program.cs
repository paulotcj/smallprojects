﻿// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;
print("Hello, World!");

var myLinkedList = new MyLinkedList(2);
myLinkedList.PrintList();
print("################################");


myLinkedList.Append(4);
myLinkedList.Append(6);
myLinkedList.Append(8);
myLinkedList.Append(10);
myLinkedList.PrintList();
print("################################");

myLinkedList.Prepend(1);
myLinkedList.PrintList();
print("################################");

print($"Traverse to index -99 : {myLinkedList.TraverseToIndex(-99)?.nodeValue}");
print($"Traverse to index 0 : {myLinkedList.TraverseToIndex(0)?.nodeValue}");
print($"Traverse to index 2 : {myLinkedList.TraverseToIndex(2)?.nodeValue}");
print($"Traverse to index 5 : {myLinkedList.TraverseToIndex(5)?.nodeValue}");
print($"Traverse to index 99 : {myLinkedList.TraverseToIndex(99)?.nodeValue}");


print("################################");
print("Insert test - start");
myLinkedList.Insert(0, 11);
myLinkedList.PrintList();
print(" -----");
myLinkedList.Insert(7, 22); //should be added at the end
myLinkedList.PrintList();
print(" -----");
myLinkedList.Insert(33, 33); //should be added at the end
myLinkedList.PrintList();
print(" -----");
myLinkedList.Insert(6, 44);
myLinkedList.PrintList();
print(" -----");
myLinkedList.Insert(2, 55);
myLinkedList.PrintList();
print("Insert test - end");

print("################################");
print("Remove from index -1");
myLinkedList.RemoveIndex(-1);
myLinkedList.PrintList();
print(" -----");
print("Remove from index 0");
myLinkedList.RemoveIndex(0);
myLinkedList.PrintList();
print(" -----");
print("Remove from index 99");
myLinkedList.RemoveIndex(99);
myLinkedList.PrintList();
print(" -----");
print("Remove from index 9");
myLinkedList.RemoveIndex(9);
myLinkedList.PrintList();
print(" -----");
print("Remove from index 2");
myLinkedList.RemoveIndex(2);
myLinkedList.PrintList();
print(" -----");
//-------------------------------------------------------------
public class MyLinkedList
{
    private int _count = 0;
    private Node head = null;
    private Node tail = null;

    
    public MyLinkedList(int value)
    {
        var current = NewNode(value);

        head = current;
        tail = current;

        _count++;
    }

    private Node NewNode(int value) 
    {
        var current = new Node();
        current.next = null;
        current.nodeValue = value;

        return current;
    }

    //goes at the end
    // list is supposed to be inserted as 1,2,3,4 and then be displayed 1,2,3,4
    public void Append(int value)
    {
        var current = NewNode(value);
        if (head == null) { head = current; }
        tail.next = current;
        tail = current;
        _count++;
    }

    //goes at the beginning, if the list is 1,2,3 and we prepend 11
    // then the list should be 11, 1,2,3,4
    public void Prepend(int value)
    {
        var current = NewNode(value);
        if (tail == null) { tail = current; }
        current.next = head;
        head = current;
        _count++;
    }

    public void Insert(int index, int value)
    {
        if (index < 0) { index = 0; }


        //is it at the head?
        if (index == 0) { Prepend(value); }

        //is it at the tail?
        else if (index >= _count) { Append(value); }

        //then it's in the middle
        else 
        {
            var newNode = NewNode(value);
            var prev = TraverseToIndex(index - 1);

            newNode.next = prev.next;
            prev.next = newNode;
            _count++;
        }

    }

    public void RemoveIndex(int index)
    {
        if (index < 0 || index >= _count) { Console.WriteLine($"    RemoveIndex - Index out of bound : {index}"); return; }

        //is there only one item in the list?
        if (_count == 1)
        {
            head = null;
            tail = null;
        }
        //is it at the head?
        else if (index == 0)
        {
            head = head.next;
        }
        //are we removing from tail?
        else if (index >= _count - 1)
        {
            var previous = TraverseToIndex(index - 1);
            previous.next = null;
            tail = previous;
        }
        //then we are removing from the middle
        else 
        {
            var previous = TraverseToIndex(index - 1);
            previous.next = previous.next?.next;

        }

        _count--;



    }


    //--------

    public Node? TraverseToIndex(int index)
    {
        if (index < 0 ) { index = 0; }
        else if (index >= _count) { index = _count - 1; };

        var current = head; // this is index 0
        for (var i = 0; i < index; i++) //this applies to index 1 and forward
        {
            current = current?.next;
        }

        return current;

    }

    public void PrintList()
    {
        var current = head;
        while (current != null)
        {
            Console.WriteLine($"Value : {current.nodeValue}");
            current = current.next;
        }
    }

    //--------
}

public class Node
{
    public Node? next;
    public int nodeValue;
}
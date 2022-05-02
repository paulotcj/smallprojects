// See https://aka.ms/new-console-template for more information
//based on a problem from LeetCode https://leetcode.com/problems/implement-queue-using-stacks

Action<string> print = Console.WriteLine;

print("Hello, World!");


var myQueue = new MyQueueStack();
myQueue.Enqueue(2);
myQueue.PrintQueue();
print("##############################");
print("Adding many elements (4,6,8) to the Queue");
myQueue.Enqueue(4);
myQueue.Enqueue(6);
myQueue.Enqueue(8);
myQueue.PrintQueue();
print("##############################");
print("Peeking the Queue");
print(myQueue.Peek().ToString());
myQueue.PrintQueue();
print("##############################");
print("Info: 2 was the first added and 8 was the last added");
myQueue.PrintQueue();
print("##############################");
print($"Dequeue: {myQueue.Dequeue()}");
myQueue.PrintQueue();
print("##############################");
print($"Dequeue: {myQueue.Dequeue()}");
myQueue.PrintQueue();
print("##############################");

print("Adding many elements (10,12,14) to the Queue");
myQueue.Enqueue(10);
myQueue.Enqueue(12);
myQueue.Enqueue(14);
myQueue.PrintQueue();

print("##############################");
print("Multiple Dequeue operations coming up...");
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print(myQueue.Dequeue().ToString());
print("Queue should be empty and no errors should've occurred.");
myQueue.PrintQueue();


//---------------------------------

public class MyQueueStack 
{
    Stack<int> _stack = new Stack<int>();
    Stack<int> _stackReversed = new Stack<int>();

    public void Enqueue(int value) //push
    {
        _stack.Push(value);
    }


    public int? Peek() 
    {
        //-----
        if (_stackReversed.Count <= 0) 
        {
            if (_stack.Count <= 0) { return null; }
            while (_stack.Count != 0)
            {
                _stackReversed.Push(_stack.Pop());
            }
        }

        //-----

        return _stackReversed.Peek();

    }

    public int? Dequeue() //pop
    {
        if (Peek() == null) { return null; }
        return _stackReversed.Pop();


    }



    public void PrintQueue()
    {
        Console.WriteLine($"--------------------------\nPrint Queue/Stack");
        Console.WriteLine($"    From: _stack");
        foreach (var i in _stack) 
        {
            Console.WriteLine($"        Value {i}");
        }

        Console.WriteLine($"    From: _stackReversed");
        foreach (var i in _stackReversed)
        {
            Console.WriteLine($"        Value {i}");
        }
    }
}

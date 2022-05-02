// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;
print("Hello, World!");

var myQueue = new MyQueue();
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


print("Multiple Dequeue operations coming up...");
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
myQueue.Dequeue();
print("Queue should be empty and no errors should've occurred.");
myQueue.PrintQueue();
//------------------------------


public class MyQueue
{
    List<int> _list = new List<int>();

    public void Enqueue(int value) 
    {
        _list.Add(value);
    }

    public int? Peek()
    {
        if (_list.Count <= 0) { return null; }
        return _list[0];
    }

    public int? Dequeue() 
    {
        if (_list.Count <= 0 ) { return null; }
        var returnObj = Peek();
        _list.RemoveAt(0);

        return returnObj;
    }

    public void PrintQueue() 
    {
        Console.WriteLine($"--------------------------\nPrint Queue/List");
        foreach (var i in _list)
        {
            Console.WriteLine($"Value : {i}");
        }
    }
}

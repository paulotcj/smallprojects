// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;
print("Hello, World!");

var myPQ = new MyPriorityQueue();

myPQ.Enqueue(value: 1, priority: 10);
myPQ.Enqueue(value: 2, priority: 10);
myPQ.Enqueue(value: 3, priority: 10);
myPQ.Enqueue(value: 4, priority: 10);
myPQ.Enqueue(value: 5, priority: 10);
myPQ.Enqueue(value: 6, priority: 10);
myPQ.Print();
print($"############################");
myPQ.Enqueue(value: 7, priority: 11);
myPQ.Print();
print($"############################");
myPQ.Enqueue(value: 8, priority: 11);
myPQ.Enqueue(value: 9, priority: 11);
myPQ.Enqueue(value: 10, priority: 11);
myPQ.Print();
print($"############################");
myPQ.Enqueue(value: 11, priority: 12);
myPQ.Enqueue(value: 12, priority: 13);
myPQ.Enqueue(value: 13, priority: 14);
myPQ.Enqueue(value: 14, priority: 9);
myPQ.Print();
print($"############################");
var tempVar = myPQ.Front();
print($"Front -> Priority: {tempVar?.priority} - Value: {tempVar?.value}");
tempVar = myPQ.Rear();
print($"Rear -> Priority: {tempVar?.priority} - Value: {tempVar?.value}");
print($"############################");
tempVar = myPQ.Dequeue();
print($"Dequeue -> Priority: {tempVar?.priority} - Value: {tempVar?.value}");
myPQ.Print();

//-----------------------------------------------


public class MyPriorityQueue
{
    List<QElement> data = new List<QElement>();

    //enqueue
    public void Enqueue(int value, int priority) 
    { 
        var qNewItem = new QElement();
        qNewItem.value = value;
        qNewItem.priority = priority;

        var priorityInserted = false;

        for (var i = 0; i < data.Count; i++)
        {
            var item = data[i];
            if (priority > item.priority) { 
                data.Insert(i, qNewItem); 
                priorityInserted = true;
                break;
            }
        }

        if (priorityInserted == false) { data.Add(qNewItem); }


    }
    //dequeue
    public QElement? Dequeue()
    {
        var returnObj = Front();
        
        if (returnObj != null) { data.RemoveAt(0); }
        
        return returnObj;
    }


    public QElement? Front()
    {
        if (data.Count <= 0) { return null; }

        var returnObj = data[0];

        return returnObj;
    }

    public QElement? Rear()
    {
        var returnObj = data.LastOrDefault();

        return returnObj;
    }


    public bool IsEmpty()
    {
        return data.Count == 0 ? true : false;
    }


    public void Print()
    {
        Console.WriteLine($"--------------------------\nPriority Queue Print");
        for(var i = 0; i < data.Count; i++)
        {
            var item = data[i];
            Console.WriteLine($"    Index: {i} - Priority: {item.priority} - Value : {item.value}");
        }
    }
}


public class QElement
{
    public int value = 0;
    public int priority = 0;
}

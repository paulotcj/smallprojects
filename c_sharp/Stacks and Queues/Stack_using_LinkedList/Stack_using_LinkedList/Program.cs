// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;
print("Hello, World!");

var myStack = new MyStack(2);
print(myStack.Peek().ToString());
print("##############################");
myStack.Push(4);
myStack.Push(6);
myStack.Push(8);
print(myStack.Peek().ToString());
print("##############################");
print("Info: 2 was the first added and 8 was the last added");
print("##############################");
myStack.PrintList();

print("##############################");
print($"Stack Pop: {myStack.Pop()}");

myStack.PrintList();
print("##############################");
print($"Stack Pop: {myStack.Pop()}");

myStack.PrintList();

print("##############################");
print("Multiple Pop operations coming up...");
myStack.Pop();
myStack.Pop();
myStack.Pop();
myStack.Pop();
myStack.Pop();
myStack.Pop();
myStack.Pop();
myStack.Pop();
myStack.Pop();
myStack.Pop();
myStack.Pop();
print("Stack should be empty and no errors should've occurred.");
myStack.PrintList();




//------------------------------------

public class MyStack
{
    private List<int> _list =  new List<int>();
    public MyStack(int value) 
    {
        _list.Add(value);
    }

    public void Push(int value) 
    {
        _list.Add(value);
    }

    public int Peek()
    {
        var lastAdded = _list[_list.Count -1];
        return lastAdded;
    }

    public int? Pop()
    {
        var lastIndex = _list.Count - 1;
        if (lastIndex < 0) { return null; }
        var returnObj = _list[lastIndex];

        _list.RemoveAt(lastIndex);

        return returnObj;
    }

    public void PrintList()
    {
        Console.WriteLine("--------------------------\nPrint Stack/List:");
        foreach (var i in _list)
        {
            Console.WriteLine($"Value : {i}");
        }
    }
}

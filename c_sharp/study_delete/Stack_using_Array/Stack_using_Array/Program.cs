// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;

print("Hello, World!");

var myStack = new MyStack(10);
myStack.Push(2);
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





//------------------------------------------
public class MyStack
{
    //private List<int> _list = new List<int>();
    private int?[] _array;
    private int _lastAddedIndex = -1;
    public MyStack(int arraySize)
    {
        _array = new int?[arraySize];
    }

    public void Push(int value)
    {
        if (_lastAddedIndex + 1 >= _array.Length) { return; }
        _array[++_lastAddedIndex] = value;
    }

    public int? Peek()
    {
        if (_lastAddedIndex < 0) { return null; }
        return _array[_lastAddedIndex];
    }

    public int? Pop()
    {
        var returnObj = Peek();
        if (returnObj != null) 
        {
            _array[_lastAddedIndex] = null;
            _lastAddedIndex--;
        }

        return returnObj;
    }

    public void PrintList()
    {
        Console.WriteLine("--------------------------\nPrint Stack/Array:");
        foreach (var i in _array)
        {
            if (i == null) { continue; }
            Console.WriteLine($"Value : {i}");
        }
    }
}

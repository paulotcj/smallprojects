// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var myarray = new MyArray();
myarray.PrintArray();

myarray.Push(3);
myarray.Push(4);
myarray.Push(7);
myarray.Push(5);
myarray.Push(6);
myarray.PrintArray();
myarray.Push(9);
myarray.PrintArray();
myarray.Pop();
myarray.PrintArray();

myarray.DeleteAtIndex(2);
myarray.PrintArray();


myarray.DeleteAtIndex(111);
myarray.DeleteAtIndex(-1);
myarray.PrintArray();


for (var i = 0; i < 30; i++) { myarray.Pop(); }
myarray.PrintArray();


for (var i = 1; i< 30; i++) { myarray.Push(i); }
myarray.PrintArray();

public class MyArray
{
    public int length = 0; //these properties are public only to serve as an example and to quickly prototype this concept
    public int[] data;
    public MyArray(int preAllocatedSize  = 10)
    {
        Console.WriteLine($"MyArray constructor");
        this.length = 0;
        this.data = new int[preAllocatedSize];

    }

    public void PrintArray() 
    {
        if (this.length <= 0) { Console.WriteLine($"PrintArray - Array is empty");  }
        for (var i = 0 ; i < this.length; i++) 
        { Console.WriteLine($"Item: {this.data[i]}");  }
        Console.WriteLine($"-------------");
    }

    //--------------------------------------------------
    public int? Get(int index)
    {
        if (index >= this.length || index < 0) { return null; }
        return this.data[index];
    }
    public int[]? Push(int item)
    {
        if (this.length >= data.Length) { Console.WriteLine($"Cannot Push - Array limits reached. Array Length: {this.length}");  return null; } //finish this

        this.data[this.length++] = item;
        return this.data;
    }

    public int? Pop()
    {
        if (this.length <= 0) { Console.WriteLine($"Cannot Pop - Array is empty"); return null; }
        this.length--;
        var lastItem = this.data[this.length];
        this.data[length] = 0;
        

        return lastItem;
    }
    public int? DeleteAtIndex(int index)
    {
        if (index >= this.length || index < 0) { Console.WriteLine($"Cannot Delete - Index out of bounds. Index: {index} - Array Length: {this.length}"); return null; }
        var item = this.data[index];
        ShiftIndex(index);
        return item;
    }

    private void ShiftIndex(int index) 
    {
        for (var i = index; i < this.length; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.data[length] = 0;
        this.length--;
    }
}
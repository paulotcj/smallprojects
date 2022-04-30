// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Action<string> print = Console.WriteLine;


var myarr1 = new MyArray(5);
print($"Pop with an empty array: '{ myarr1.Pop() }'");
print($"Get Invalid index: -1 -> '{ myarr1.Get(-1) }'");
print($"Get Invalid index: 99 -> '{ myarr1.Get(99) }'");

print($"pushing more than the array capacity - start");
myarr1.Push(11);
myarr1.Push(22);
myarr1.Push(33);
myarr1.Push(44);
myarr1.Push(55);
myarr1.Push(66);
myarr1.Push(77);
myarr1.Push(88);
myarr1.Push(99);
print($"pushing more than the array capacity - end - we should see no errors here");

print($"Getting index 3. Expected Value: 44 - Actual Value: {myarr1.Get(3)}");

myarr1.PrintArray();

print($"Shiftting array at Index 2 - Results:");
myarr1.ShiftIndex(2);
myarr1.PrintArray();



public class MyArray 
{
    int?[] data;
    int length = 0;
    public MyArray(int size)
    {
        data = new int?[size];
    }

    public int? Get(int index) 
    {
        if (index < 0 || index >= data.Length) { return null; }
        return this.data[index];
    }

    public void Push(int item) 
    {
        if (this.length + 1 > data.Length) { return; }
        this.data[length++] = item;
    }

    public int? Pop() 
    {
        if ((length - 1) < 0) { return null; }
        var returnvalue = this.data[length-1];
        this.data[length - 1] = null;
        length--;

        return returnvalue;
    }
    //---------

    public void ShiftIndex(int index)
    {
        if (index < 0 || index >= this.length) { return; }

        for (var i = index; i < data.Length-1; i++) 
        {
            this.data[i] = this.data[i + 1];
        }
        Pop();

    }

    public void PrintArray()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("PrintArray - start");
        for (var i = 0; i < data.Length; i++)
        {
            Console.WriteLine($"Array[{i}] = {data[i]}");
        }
        Console.WriteLine("PrintArray - end");
    }

}
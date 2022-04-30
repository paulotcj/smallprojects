// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;

print("Hello, World!");

var hashObj = new MyHashTable(5);

print($"Value of 'aa' : {hashObj.Hash("aa")}");
print($"Value of 'ab' : {hashObj.Hash("ab")}");

hashObj.Insert("a");
hashObj.Insert("b"); //provoking collision
hashObj.Insert("f"); //provoking collision
hashObj.Insert("z"); //provoking collision
hashObj.Insert("g"); //provoking collision
hashObj.Insert("h"); //provoking collision
hashObj.Insert("t"); //provoking collision

hashObj.PrintHashTable();

hashObj.Insert("Mike");
hashObj.Insert("Lia");
hashObj.Insert("Mel");
hashObj.Insert("John");
hashObj.Insert("Marlene");
hashObj.Insert("Pfutzenreuter"); // :P haha

hashObj.PrintHashTable();

print("------------------------------------");
print($"trying to find: Mike -> {hashObj.Get("Mike")}");
print($"trying to find: z -> {hashObj.Get("z")}");
print($"trying to find: Bob -> {hashObj.Get("Bob")}");




public class MyHashTable
{
    //we need to have an array
    //  of lists - and these lists are lists of tempdata

    private List<string>[] data;
    public MyHashTable(int size)
    {
        data = new List<string>[size];
    }

    public int Hash(string value)
    {
        var returnObj = 0;
        for (var i = 0; i < value.Length; i++)
        {
            returnObj = (returnObj + (int)value[i] * i);
        }
        returnObj = returnObj % this.data.Length;

        return returnObj;
    }

    public void Insert(string value)
    {
        var hash = Hash(value);
        if (this.data[hash] == null) { this.data[hash] = new List<string>(); }
        this.data[hash].Add( value);
    }


    public string? Get(string value)
    {
        var hash = Hash(value);
        var itemArray = this.data[hash];
        foreach (var tempObj in itemArray)
        {
            if (value.CompareTo(tempObj) == 0)
            {
                //Console.WriteLine($"Item found : { tempObj }");
                return tempObj;
            }
        }
        return "(Not Found)";
    }

    public void PrintHashTable()
    {
        Console.WriteLine("-----------------------------------------\nPrintHashTable");
        for (int i = 0; i < this.data.Length; i++)
        {
            Console.WriteLine($"Key{i}");
            foreach (var item in this.data[i]??new List<string>())
            {
                Console.WriteLine($"    Value:{item}");
            }
        }
    }
}

//public class TempData
//{
//    public int objKey = 0;
//    public string objValue;
//    public TempData(int value, string key)
//    {
//        objKey = value;
//        objValue = key;
//    }
//}
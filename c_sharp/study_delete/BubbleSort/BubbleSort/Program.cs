// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;

print("Hello, World!");

var arr = new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

arr = BubbleSort.Sort(arr);

BubbleSort.Print(arr);




//-----------------------

public static class BubbleSort
{
    public static int[] Sort(int[] arr)
    {

        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                int a = arr[i];
                int b = arr[j];
                if (a > b) //swap!
                {
                    arr[i] = b;
                    arr[j] = a;
                }

            }
        }

        return arr;
        
    }

    public static void Print(int[] arr)
    {
        for (int i = 0; i< arr.Length; i++)
        {
            Console.WriteLine($"Arr[{i}] : {arr[i]}");
        }
    }
}

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int[] arr = new int[] { 10, 7, 8, 9, 1, 5 };
arr = QuickSort.Sort(arr);
Console.WriteLine($"Sorted array: ");
QuickSort.Print(arr);
Console.WriteLine($"###########################");
var list = new List<int>() { 9,7,5,1,3,2,4,0,8,6 };
list = QuickSort2.Sort(list);
QuickSort2.Print(list.ToArray());

public static class QuickSort2
{
    public static List<int> Sort(List<int> list)
    {
        if (list.Count <= 1) { return list; }
        int pivot_index = list.Count - 1;
        int pivot = list[pivot_index];

        int capacity = (int)Math.Round((decimal)list.Count / (decimal)2);

        var leftList = new List<int>(capacity: capacity);
        var rightList = new List<int>(capacity: capacity);


        for(int i = 0; i < pivot_index; i++)
        {
            var item = list[i];

            if (item < pivot) { leftList.Add(item); }
            else { rightList.Add(item); }
        }
        
        leftList = Sort(leftList);
        leftList.Add(pivot);
        rightList = Sort(rightList);

        return leftList.Concat(rightList).ToList();
    }


    public static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"Arr[{i}] : {arr[i]}");
        }
    }
}




public static class QuickSort
{
    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static int[] Sort(int[] arr)
    {
        Sort(arr : arr, low : 0, high :  arr.Length - 1);

        return arr;

    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];

        int i = (low - 1);

        for(var j = low; j <= high-1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i+1, high);

        return (i + 1);
    }



    private static void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            var part_idx = Partition(arr, low, high);

            Sort(arr, low, part_idx - 1);
            Sort(arr, part_idx + 1, high);

        }


    }



    public static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"Arr[{i}] : {arr[i]}");
        }
    }
}


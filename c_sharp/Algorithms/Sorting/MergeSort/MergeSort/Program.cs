// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;

print("Hello, World!");

var arr = new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };

arr = SortingClass.MergeSort(arr);

SortingClass.Print(arr);

//-----------------

public static class SortingClass
{
    public static int[] MergeSort(int[] arr)
    {
        if (arr.Length == 1) { return arr;  } 
        var half_array = arr.Length/2;
        int[] left = arr.Take(half_array).ToArray<int>();
        int[] right = arr.Skip(half_array).ToArray<int>();

        return Merge
            (
                MergeSort(left), 
                MergeSort(right)
            );
    }

    public static int[] Merge(int[] left , int[] right)
    {
        var returnObj = new int[left.Length + right.Length];

        int l_idx = 0, r_idx = 0;
        for (int i = 0; i < returnObj.Length; i++  )
        {
            int? l_val = null;
            int? r_val = null;

            
            if (l_idx >= left.Length) //what if left is out of range?
            { 
                l_val = null;
                r_val = right[r_idx];
            }
            else if (r_idx >= right.Length)  // what if right is out of range?
            { 
                r_val = null;
                l_val = left[l_idx];
            }
            else //if everything else is normal, proceed normally
            {
                l_val = left[l_idx];
                r_val = right[r_idx];
            }


            if (r_val == null) { returnObj[i] = (int)l_val; l_idx++; }
            else if (l_val == null) { returnObj[i] = (int)r_val; r_idx++; }
            else if (r_val == null || l_val <= r_val) { returnObj[i] = (int)l_val; l_idx++; } 
            else { returnObj[i] = (int)r_val; r_idx++; }
        }


        return returnObj;
    }

    public static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"Arr[{i}] : {arr[i]}");
        }
    }
}

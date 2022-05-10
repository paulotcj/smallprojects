// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;
print("Hello, World!");

var arr = new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };
print($"Before sort");
SelectionSort.Print(arr);

print("######################");
arr = SelectionSort.Sort(arr);
SelectionSort.Print(arr);


//---------


public static class SelectionSort
{
    public static int[] Sort(int[] arr)
    {
        //steps
        // 1 - loop through the array
        // 2 - find the minimum value from the rest of the array, and replace with the current position

        for (int i = 0; i < arr.Length; i++)
        {
            var min_idx = i;
            var min_value = arr[i];

            //-----
            for (var j = i+1; j < arr.Length; j ++) //let's compare and find out the minimum value
            {
                var j_value = arr[j];

                if (j_value < min_value)
                {
                    min_value = j_value;
                    min_idx = j;
                }
            }// end of for j

            //-----
            //now what's the min value and index from the array?
            // and let's replace it with what we have on index I

            var temp = arr[i];
            arr[i] = min_value;
            arr[min_idx] = temp;


        }// end of for i

        return arr;

    }

    public static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"Arr[{i}] : {arr[i]}");
        }
    }
}

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var arr = new int[] { 99, 44, 6, 2, 1, 5, 63, 87, 283, 4, 0 };
//var arr = new int[] { 2,6,1,0 };

arr = InsertionSort.Sort(arr);

InsertionSort.Print(arr);


//--------------------------

public static class InsertionSort
{

    public static int[] Sort(int[] arr)
    {
        //the idea here is you have one number (curr), look at the number at the previous position (prev)
        //  if this number (prev) is bigger than your current number you should switch their places
        //   e.g.: [...,4,1,...] -> [...,1,4,...] where in this case current=1 and prev=4
        // and you should keep repeating this last leg until the previous element is less than your current element

        
        for (var i = 1; i < arr.Length; i++) 
        {
            var current_value = arr[i]; //start at idx=1 and then we move from there

            //-----------------
            //let's look at all the previous values
            for (int j = i-1; j >= 0; j--) 
            {
                var prev_value = arr[j];

                if (prev_value > current_value) // if the previous value is bigger we should switch in order to make the array sorted
                {
                    arr[j + 1] = prev_value;
                    arr[j] = current_value;
                }
                else if (prev_value <= current_value) { break; } //then it's ordered - let's not waste cpu cycles
            } // end of for j - it's important to note that we are moving the current value step by step back into the
            // array until we find the correct position, where the previous element is smaller than the current element

        }
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
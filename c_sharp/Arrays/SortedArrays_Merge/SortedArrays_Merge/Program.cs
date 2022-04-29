// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var array1 = new[] { 0, 3, 4, 31 };
var array2 = new[] { 4, 6, 30 };

var merged = MergeSortedArrays(array1, array2);

Console.WriteLine($"Merged Array in order:");
foreach (var i in merged) { Console.WriteLine(i); }



//----------

var merged2 = MergSrotedArrays_2(array1, array2);
Console.WriteLine("---------------------------------");
Console.WriteLine($"Merged Array in order:");
foreach (var i in merged2) { Console.WriteLine(i); }



static int?[] MergeSortedArrays(int[] array1, int[] array2)
{
    var mergedArray = new int?[array1.Length + array2.Length];
    int a_idx = 0; int b_idx = 0;

    for (int i = 0; i < mergedArray.Length; i++) 
    {
        int? a = null; int? b = null;

        if (a_idx < array1.Length) { a = array1[a_idx]; }
        if (b_idx < array2.Length) { b = array2[b_idx]; }

        //if a != null && b == null -> a
        //   a != null && a <= b    -> a
        //   b != null && a == null -> b
        //   b != null && b <= a    -> b     .... also A and B will never be null at the same time
        if      (a != null && (b == null || a <= b)) { mergedArray[i] = a; a_idx++; }
        else if (b != null && (a == null || b <= a) ) { mergedArray[i] = b; b_idx++; }

    }

    return mergedArray;
}


static int?[] MergSrotedArrays_2(int[] arr1, int[] arr2 ) 
{
    var mergedArr = new int?[arr1.Length + arr2.Length];

    int? a = null; int? b = null;
    var a_idx = 0; var b_idx = 0; 
    for (int i = 0; i < mergedArr.Length; i++) 
    {
        //we need to fetch the next element from the arrays
        if (a_idx < arr1.Length) { a = arr1[a_idx]; }
        if (b_idx < arr2.Length) { b = arr2[b_idx]; }

        //we need to set mergedArr[i]

        //conditions:
        // a == null && b == int  -> b
        // a == int  && b == null -> a
        //    note: we will never have (a == null && b == null)
        // a <= b -> a
        // else   -> b

        a = a ?? b + 1; //just fixing in case there's a null value
        b = b ?? a + 1; // we want them to be bigger as this will make the system pick the other variable

        if (a <= b) { mergedArr[i] = a; a_idx++; }
        else { mergedArr[i] = b; b_idx++; }

        a = null; b = null;
    }

    return mergedArr;
}
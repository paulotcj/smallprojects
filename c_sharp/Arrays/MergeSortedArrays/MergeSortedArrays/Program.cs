// See https://aka.ms/new-console-template for more information

Action<string> print = Console.WriteLine;

print("Hello, World!");

int[] ret;
int[] arr1;
int[] arr2;

//---------------
print($"arr1 empty, and arr2 with only 1 element");
arr1 = new int[] { };
arr2 = new int[] { 1 };
ret = MergeSortedArrays.Merge1(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"both arrays empty");
arr1 = new int[] { };
arr2 = new int[] { };
ret = MergeSortedArrays.Merge1(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"arr1 with 1 element, and arr2 empty");
arr1 = new int[] { 1 };
arr2 = new int[] { };
ret = MergeSortedArrays.Merge1(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"Both arrays populated, with ordered elements, but not with the same size - test 1");
arr1 = new int[] { 2, 4, 6, 8, 10 };
arr2 = new int[] { 1, 3, 5 };
ret = MergeSortedArrays.Merge1(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"Both arrays populated, with ordered elements, but not with the same size - test 2");
arr1 = new int[] { 2, 4, };
arr2 = new int[] { 1, };
ret = MergeSortedArrays.Merge1(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
print($"###############################################################");

//---------------
print($"arr1 empty, and arr2 with only 1 element");
arr1 = new int[] { };
arr2 = new int[] { 1 };
ret = MergeSortedArrays.Merge3(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"both arrays empty");
arr1 = new int[] { };
arr2 = new int[] { };
ret = MergeSortedArrays.Merge3(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"arr1 with 1 element, and arr2 empty");
arr1 = new int[] { 1 };
arr2 = new int[] { };
ret = MergeSortedArrays.Merge3(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"Both arrays populated, with ordered elements, but not with the same size - test 1");
arr1 = new int[] { 2, 4, 6, 8, 10 };
arr2 = new int[] { 1, 3, 5 };
ret = MergeSortedArrays.Merge3(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"Both arrays populated, with ordered elements, but not with the same size - test 2");
arr1 = new int[] { 2, 4, };
arr2 = new int[] { 1, };
ret = MergeSortedArrays.Merge3(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
print($"###############################################################");


//---------------
print($"arr1 empty, and arr2 with only 1 element");
arr1 = new int[] { };
arr2 = new int[] { 1 };
ret = MergeSortedArrays.Merge4(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"both arrays empty");
arr1 = new int[] { };
arr2 = new int[] { };
ret = MergeSortedArrays.Merge4(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"arr1 with 1 element, and arr2 empty");
arr1 = new int[] { 1 };
arr2 = new int[] { };
ret = MergeSortedArrays.Merge4(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"Both arrays populated, with ordered elements, but not with the same size - test 1");
arr1 = new int[] { 2, 4, 6, 8, 10 };
arr2 = new int[] { 1, 3, 5 };
ret = MergeSortedArrays.Merge4(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
//---------------
print($"Both arrays populated, with ordered elements, but not with the same size - test 2");
arr1 = new int[] { 2, 4, };
arr2 = new int[] { 1, };
ret = MergeSortedArrays.Merge4(arr1, arr2);
MergeSortedArrays.PrintArray(ret);
print($"###############################################################");

public static class MergeSortedArrays
{
    public static int[] Merge1(int[] arr1, int[] arr2)
    {
        var returnObj = new int[arr1.Length + arr2.Length];

        int arr1_idx = 0, arr2_idx = 0;
        for (var i = 0; i < returnObj.Length; i++) //loop populating the returnObj
        {
            int insert = 0;
            //their indexes may be out of range
            int? v_arr1 = arr1 != null && arr1.Length > 0 && arr1_idx < arr1.Length ? arr1[arr1_idx] : null;
            int? v_arr2 = arr2 != null && arr2.Length > 0 && arr2_idx < arr2.Length ? arr2[arr2_idx] : null;



            //below is the base case
            //now we need to define which element from both arrays will be picked
            if (v_arr1 == null || v_arr2 == null)
            {
                if (v_arr1 == null) { insert = (int)v_arr2; arr2_idx++; }
                else { insert = (int)v_arr1; arr1_idx++; }
            }
            else if (v_arr1 <= v_arr2) { insert = (int)v_arr1; arr1_idx++; }
            else { insert = (int)v_arr2; arr2_idx++; }

            returnObj[i] = insert;
        }


        return returnObj;
    }

    //--------------------------------------
    public static int[] Merge3(int[] arr1, int[] arr2) 
    {
        var st1 = new Stack<int>(arr1);
        var st2 = new Stack<int>(arr2);
        int[] returnObj = new int[arr1.Length + arr2.Length];

        for (var i = returnObj.Length-1; i >= 0; i--)
        {
            if (st1.Count == 0) { returnObj[i] = st2.Pop(); }
            else if (st2.Count == 0) { returnObj[i] = st1.Pop(); }
            else if (st1.Peek() > st2.Peek()) { returnObj[i] = st1.Pop(); }
            else { returnObj[i] = st2.Pop(); }
        }


        return returnObj;
    }
    //--------------------------------------
    public static int[] Merge4(int[] arr1, int[] arr2) 
    {
        int[] returnObj = arr1.Concat(arr2).OrderBy(x => x).ToArray();
        return returnObj;

    }


    //--------------------------------------
    //fundamentally flawed
    // resizing the arrays did not help
    //public static int?[] Merge2(int?[] arr1, int?[] arr2) 
    //{
    //    var biggerArraySize = arr1.Length > arr2.Length ? arr1.Length+1 : arr2.Length+1;
    //    var new_arr1 = ResizeArray(arr1, biggerArraySize);
    //    var new_arr2 = ResizeArray(arr2, biggerArraySize);
    //    //-----
    //    var returnObj = new int?[arr1.Length + arr2.Length];

    //    int arr1_idx = 0, arr2_idx = 0;
    //    for (var i = 0; i < returnObj.Length; i++) 
    //    {
    //        int? insert;
    //        // GENERALLY:
    //        //arr1[i] == null -> arr2[i]
    //        //arr2[i] == null -> arr1[i]

    //        //arr1[i] < arr2[i] -> arr1[i]
    //        //else arr2[i]

    //        if (new_arr1[arr1_idx] == null) { insert = new_arr2[arr1_idx++]; }
    //        else if (new_arr2[arr2_idx] == null) { insert = new_arr1[arr2_idx++]; }
    //        else if (new_arr1[arr1_idx] < new_arr2[arr2_idx]) { insert = new_arr1[arr1_idx++]; }
    //        else { insert = new_arr2[arr2_idx++]; }


    //        returnObj[i] = insert;
    //    }


    //    //-----
    //    return returnObj;
    //}

    //private static int?[] ResizeArray(int?[] arr, int newSize)
    //{
    //    int?[] newArr = new int?[newSize];
    //    for(var i = 0; i < arr.Length; i++)
    //    {
    //        newArr[i] = arr[i];
    //    }
    //    return newArr;
    //}

    //--------------------------------------


    //try to implement with a stack or queue



    public static void PrintArray(int[] arr)
    {
        Console.WriteLine($"-------------------------------");
        Console.WriteLine($"PrintArray");
        for (var i = 0; i < arr.Length; i++) 
        {
            Console.WriteLine($"Array[{i}] : {arr[i]}");
        }
        Console.WriteLine();
    }
}

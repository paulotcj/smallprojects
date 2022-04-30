// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;

print("Hello, World!");
int[] arr;

arr = new int[] {  };
RecurringCharacters.FindFirstOccurence(arr);

arr = new int[] { 1 };
RecurringCharacters.FindFirstOccurence(arr);

arr = new int[] { 2,1 };
RecurringCharacters.FindFirstOccurence(arr);

arr = new int[] { 2,2 };
RecurringCharacters.FindFirstOccurence(arr);

arr = new int[] {1,2,1 };
RecurringCharacters.FindFirstOccurence(arr);



print("##############################");

//Google Question
//Given an array = [2,5,1,2,3,5,1,2,4]:
//It should return 2
arr = new int[] { 2, 5, 1, 2, 3, 5, 1, 2, 4 };
RecurringCharacters.FindFirstOccurence(arr);
print("-----------");


//Given an array = [2,1,1,2,3,5,1,2,4]:
//It should return 1

arr = new int[] { 2, 1, 1, 2, 3, 5, 1, 2, 4 };
RecurringCharacters.FindFirstOccurence(arr);
print("This result is not what is expected according to the guidelines");
print("-----------");

print("##############################");


//Given an array = [2,5,1,2,3,5,1,2,4]:
//It should return 2
arr = new int[] { 2, 5, 1, 2, 3, 5, 1, 2, 4 };
RecurringCharacters.FindFirstOccurence2(arr);
print("-----------");


//Given an array = [2,1,1,2,3,5,1,2,4]:
//It should return 1
arr = new int[] { 2, 1, 1, 2, 3, 5, 1, 2, 4 };
RecurringCharacters.FindFirstOccurence2(arr);
print("-----------");

//Given an array = [2,3,4,5]:
//It should return undefined
arr = new int[] { 2, 3, 4, 5 };
RecurringCharacters.FindFirstOccurence2(arr);
print("-----------");

//Bonus... What if we had this:
// [2,5,5,2,3,5,1,2,4]
// return 5 because the pairs are before 2,2

arr = new int[] { 2, 5, 5, 2, 3, 5, 1, 2, 4 };
RecurringCharacters.FindFirstOccurence2(arr);
print("-----------");



//-------------------------------------

public static class RecurringCharacters
{
    //this will work if we consider valid the values alongside the array
    public static int? FindFirstOccurence(int[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            for (int j = i+1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                { Console.WriteLine($"Found {arr[j]}"); return arr[j]; }
            }

        }

        Console.WriteLine($"(Not Found)");
        return null;
    }

    
    public static int? FindFirstOccurence2(int[] arr)
    {

        var dic = new Dictionary<int, int>();
        foreach (var i in arr)
        {
            if (dic.ContainsKey(i) == true)
            {
                dic[i] = dic[i]++;
                Console.WriteLine($"Found {i}");
                return i;
            }

            dic.Add(i, 1);
            
        }


        Console.WriteLine($"(Not Found)");
        return null;
    }
}

//Google Question
//Given an array = [2,5,1,2,3,5,1,2,4]:
//It should return 2

//Given an array = [2,1,1,2,3,5,1,2,4]:
//It should return 1

//Given an array = [2,3,4,5]:
//It should return undefined


//function firstRecurringCharacter(input)
//}

//Bonus... What if we had this:
// [2,5,5,2,3,5,1,2,4]
// return 5 because the pairs are before 2,2
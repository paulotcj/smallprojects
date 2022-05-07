// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;
print("Hello, World!");

print($"Test Reverse: 'test' -> {MyReverseString.Reverse("test")}");
print("#######################################");

var temp = "Reverse this string with a recursive function";
print($"Test Reverse: '{temp}' -> {MyReverseString.Reverse(temp)}");
//----------------------------

public static class MyReverseString
{
    public static string Reverse(string input)
    {
        if (String.IsNullOrEmpty(input)) { return ""; }
        else if (input.Length == 1) { return input; }



        return input[input.Length - 1] + Reverse(input.Substring(0,input.Length-1)  );
    }
}

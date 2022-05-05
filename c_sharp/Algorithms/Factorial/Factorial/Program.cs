// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;

print("Hello, World!");

int valueToCompute = 5;
print($"Factorial Iterative: {MyFactorial.FactorialIterative(valueToCompute)}");
print("---------------");
print($"Factorial Recursive: {MyFactorial.FactorialIterative(valueToCompute)}");



//-----------------------------------

public static class MyFactorial
{
    public static int FactorialIterative(int number)
    {
        var answer = 1;
        for (var i = 5; i >= 2 ; i--)
        {
            answer = answer * i;
        }
        return answer;
    }

    public static int FactorialRecursive(int number) 
    {
        if (number == 2) { return 2; }
        return number * FactorialRecursive(number - 1);

    }
}

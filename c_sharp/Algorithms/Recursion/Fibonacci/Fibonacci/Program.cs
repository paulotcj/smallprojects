// See https://aka.ms/new-console-template for more information
using System.Numerics;

Action<string> print = Console.WriteLine;

print("Hello, World!");


print("Validating Iterative method, output expected: 1,1,2,3,5,8,13");
for (var i = 1; i <= 7; i++) 
{
    print($"Fibonacci Iterative n= {i}: { Fibonacci.Iterative(i) }");
}
print("###############################");
print($"Fibonacci Iterative - Testing hard cases n = 50: { Fibonacci.Iterative(50) }");
print("###############################");

print("Validating Recursive method, output expected: 1,1,2,3,5,8,13");
for (var i = 1; i <= 7; i++)
{
    print($"Fibonacci Recursive n= {i}: { Fibonacci.Recursive(i) }");
}
print("###############################");
int hardcase2 = 39;
print($"Fibonacci Recursive - Testing hard cases n = {hardcase2}: { Fibonacci.Recursive(hardcase2) }");
print("###############################");


public static class Fibonacci
{
    public static BigInteger Iterative(int number)
    {
        if (number < 1) { return -1; }
        else if (number <= 2) { return 1; }

        BigInteger num_minus_one = 1;
        BigInteger num_minus_two = 1;
        BigInteger temp = 0;

        for (var i = 2; i < number; i++)
        {
            temp = num_minus_one + num_minus_two;
            num_minus_two = num_minus_one;
            num_minus_one = temp;
        }

        return temp;
    }


    public static BigInteger Recursive(int value) 
    {
        if (value < 2) { return value; }

        return Recursive(value - 1) + Recursive(value - 2);

    }
}


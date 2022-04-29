// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

var abc = ClosureTest();

abc();
abc();
abc();



static Func<int> ClosureTest()
{
    int foo = 0;

    Func<int> Bar = () => 
    { 
        foo++;
        Console.WriteLine($"Foo: {foo}");
        return foo; 
    };

    return Bar;
}
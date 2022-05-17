// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ComplexObject test;
Console.WriteLine($"Starting tests, each line should come 2s apart. This is simulating getting a complex result from the system.");
test = DynamicPrograming.Memoization(1); //should take 2s
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(2); //should take 2s
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(3); //should take 2s
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(4); //should take 2s
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
//--------------
Console.WriteLine("###################################");
Console.WriteLine($"Now let's try to execute these functions with parameters submitted previously\nThe results below should take no time.");


test = DynamicPrograming.Memoization(1); //should take no time
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(3); //should take no time
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(1); //should take no time
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(3); //should take no time
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(1); //should take no time
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(3); //should take no time
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(1); //should take no time
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");
test = DynamicPrograming.Memoization(3); //should take no time
Console.WriteLine($"Test - ComplexValueCalculation: {test.ComplexValueCalculation} , CpuIntensiveString: {test.CpuIntensiveString}");





public static class DynamicPrograming
{
    private static Dictionary<int, ComplexObject> data = new();

    public static ComplexObject Memoization(int param)
    {
        //try to fetch work done previously
        ComplexObject? fetch;
        data.TryGetValue(param, out fetch);

        if (fetch != null) { return fetch; }
        //---------


        //else we need to do some lenghty work
        Thread.Sleep(2000);
        //---------


        //Save work
        var newObj = new ComplexObject();
        data[param] = newObj;
        //---------

        return newObj;

    }

}

public class ComplexObject
{
    public int ComplexValueCalculation { get; set; }
    public string? CpuIntensiveString { get; set; }
    //etc.
    //---



    public ComplexObject()
    {
        var rand = new System.Random();
        ComplexValueCalculation = rand.Next();
        CpuIntensiveString = $"|string|{ComplexValueCalculation}|string|";


    }



}

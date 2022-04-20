// See https://aka.ms/new-console-template for more information
using System.Text;

Console.WriteLine("Hello, World!");

var test = Reverse("This is a very long sentence....");

Console.WriteLine(test);

var test2 = Esrever("Reverse");
Console.WriteLine(test2);


static string Reverse(string toBeReversed) 
{
    
    var sb = new StringBuilder();
    for(int i = toBeReversed.Length-1; i >= 0; i--)
    {
        var c = toBeReversed[i];
        //Console.WriteLine(c);
        sb.Append(toBeReversed[i]);
    }

    return sb.ToString();
}

static string? Esrever(string toBeReverted) 
{
    var charArray = new Char[toBeReverted.Length];
    var cA_i = 0;
    for (int i = toBeReverted.Length-1; i >= 0; i--) 
    {
        var c = toBeReverted[i];
        charArray[cA_i++] = c;

    }

    return new string(charArray);
}
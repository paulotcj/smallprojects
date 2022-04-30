// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;
print("Hello, World!");

print($"Reverse1 - My Name Is... -> {MyString.Reverse1("My Name Is...")}");

print($"Reverse2 - My Name Is... -> {MyString.Reverse2("My Name Is...")}");

print($"Reverse3 - My Name Is... -> {MyString.Reverse3("My Name Is...")}");


public static class MyString
{
    public static string Reverse1(string strIn)
    {
        var sb = new System.Text.StringBuilder();

        for (var i = strIn.Length-1; i >= 0; i--) 
        {
            sb.Append(strIn[i]);
        }

        return sb.ToString();
    }

    public static string Reverse2(string strIn)
    {
        var charArr = new Char[strIn.Length];

        var charArr_idx = 0;
        for (var i = strIn.Length - 1; i>= 0; i--) 
        {
            charArr[charArr_idx++] = strIn[i];
        }
        return new string(charArr);
    }

    public static string Reverse3(string strIn)
    {
        var x = strIn.Reverse().ToArray();
        return new string(x);
    }
}
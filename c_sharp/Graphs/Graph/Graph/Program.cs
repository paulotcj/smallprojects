// See https://aka.ms/new-console-template for more information
Action<string> print = Console.WriteLine;

Console.WriteLine("Hello, World!");


var myGraph = new MyGraph();
//myGraph.AddVertex(0);
//myGraph.AddVertex(1);
//myGraph.AddVertex(2);
//myGraph.AddVertex(3);
//myGraph.AddVertex(4);
//myGraph.AddVertex(5);
//myGraph.AddVertex(6);
//myGraph.Print();

//print("#############################");

myGraph.AddEdge(3, 1);
myGraph.AddEdge(3, 4);
myGraph.AddEdge(4, 2);
myGraph.AddEdge(4, 5);
myGraph.AddEdge(1, 2);
myGraph.AddEdge(1, 0);
myGraph.AddEdge(0, 2);
myGraph.AddEdge(6, 5);
myGraph.Print();



//----------------------------

public class MyGraph
{
    Dictionary<int, List<int>> data = new();

    public void AddVertex(int node) 
    {
        if (data.ContainsKey(node) == false)
        {
            data[node] = new List<int>();
        }
    }

    public void AddEdge(int node1, int node2)
    {
        AddVertex(node1);
        AddVertex(node2);
        data[node1].Add(node2);
        data[node2].Add(node1);
    }

    public void Print()
    {
        var tempData = data.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        foreach (var tempNode in tempData)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var edge in tempNode.Value)
            {
                sb.Append($"{edge}, ");
            }

            Console.WriteLine($"Node: { tempNode.Key } - Connects to : {sb.ToString()}");
        }
    }

}

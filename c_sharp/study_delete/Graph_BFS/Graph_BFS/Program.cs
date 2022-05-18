// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var myGraph = new MyGraph();

//      0
//    /   \
//   1-----2
//   |     |
//   3-----4
//         |
//   6-----5
//
// 0 -> 1,2
// 1 -> 0,2,3
// 2 -> 0,1,4
// 3 -> 1,4
// 4 -> 2,3,5
// 5 -> 4,6
// 6 -> 5


myGraph.AddEdge(3, 1);
myGraph.AddEdge(3, 4);
myGraph.AddEdge(4, 2);
myGraph.AddEdge(4, 5);
myGraph.AddEdge(1, 2);
myGraph.AddEdge(1, 0);
myGraph.AddEdge(0, 2);
myGraph.AddEdge(6, 5);
myGraph.Print();


Console.WriteLine($"##############################");
var myGraph2 = new MyGraph2();

//---------------------------------------

//    A-------B
//    |     / |  \ 
//    |   /   |    C
//    | /     |  /
//    D-------E

//       (6)
//    A-------B
//    | (2) / |  \(5)
// (1)|   /   |    C
//    | /  (2)|  /(5)
//    D-------E
//       (1)

myGraph2.AddEdge("A", "B", 6);
myGraph2.AddEdge("A", "D", 1);
myGraph2.AddEdge("B", "D", 2);
myGraph2.AddEdge("B", "E", 2);
myGraph2.AddEdge("B", "C", 5);
myGraph2.AddEdge("D", "E", 1);
myGraph2.AddEdge("E", "C", 5);
myGraph2.Print();
Console.WriteLine($"##############################");
Console.WriteLine($"Dijkstra Shortest Path");
myGraph2.Dijkstra(start: "A");

myGraph2.PrintDistanceTable();
Console.WriteLine($"##############################");
Console.WriteLine($"Dijkstra Shortest Path - System Identified solution");
myGraph2.DijkstraPrintSolution("C");

public class MyGraph2
{
    private Dictionary<string, List<NodeDist>> data = new();
    private Dictionary<string, ShortestDistCls> distanceTable = new();
    private string Start;

    Queue<string> q = new();

    public void DijkstraPrintSolution(string endPoint)
    {
        Dictionary<string, ShortestDistCls>? select = null;
        Dictionary<string, ShortestDistCls>? prev = null;

        while (true)
        {
            prev = select;
            select = distanceTable
                .Where(x => x.Key.CompareTo(endPoint) == 0)
                .Take(1)
                .ToDictionary(x => x.Key, x => x.Value);

            if (select.FirstOrDefault().Key.CompareTo(prev?.FirstOrDefault().Key) == 0) { break; }
            
            PrintDistanceTable(select);

            endPoint = select.FirstOrDefault().Value.Prev;

        }




    }

    public void Dijkstra(string start)
    {
        this.Start = start;
        string current;
        q.Enqueue(start);
        distanceTable.Add(start, new ShortestDistCls(dist: 0, prev: start));

        while (q.Count > 0)
        {
            current = q.Dequeue();
            CalculateDistanceTable(current);
        }

    }

    public void CalculateDistanceTable(string currentNode)
    {
        ShortestDistCls currentNodeDist = distanceTable[currentNode];
        List<NodeDist> connectionList = data[currentNode]; //get a list with all connections for the node which we are accessing

        //now we need to check the distance of all connections from this node
        //---
        for (int i = 0; i < connectionList.Count; i++)
        {
            NodeDist connToCurrent = connectionList[i];


            if (distanceTable.ContainsKey(connToCurrent.Node) == false) //no previous connection exists
            {
                int sumDistances = connToCurrent.Distance + currentNodeDist.ShortestDist;
                distanceTable.Add(connToCurrent.Node, new ShortestDistCls(dist: sumDistances, prev: currentNode));
                q.Enqueue(connToCurrent.Node);
            }
            else //a connection exists, lets try to update
            {
                //we need to update the existing reference if the added distance of the current node and its previous node is less than
                // the distance of the existing conn

                ShortestDistCls existingConn = distanceTable[connToCurrent.Node];



                int sumDistances = (connToCurrent.Distance + existingConn.ShortestDist);

                if (currentNodeDist.ShortestDist > sumDistances) 
                {
                    currentNodeDist.ShortestDist = sumDistances;
                    currentNodeDist.Prev = connToCurrent.Node;
                }

            }
                    
        } //end for
        //---

    }


    public void AddVertex(string node)
    {
        if (data.ContainsKey(node) == false)
        {
            data[node] = new List<NodeDist>();
        }
    }

    public void AddEdge(string node1, string node2, int dist)
    {
        AddVertex(node1);
        AddVertex(node2);
        data[node1].Add(new NodeDist(node2, dist));
        data[node2].Add(new NodeDist(node1, dist));
    }

    public void PrintDistanceTable()
    {
        PrintDistanceTable(distanceTable);
    }
    private void PrintDistanceTable(Dictionary<string, ShortestDistCls> param)
    {

        foreach (var i in param)
        {
            Console.WriteLine($"Vertex: {i.Key} - Shortest Distance from start: {i.Value.ShortestDist} - Previous Vertex: {i.Value.Prev} ");
        }
    }

    public void Print()
    {
        var tempData = data.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        foreach (var tempNode in tempData)
        {
            var sb = new System.Text.StringBuilder();
            foreach (var edge in tempNode.Value)
            {
                sb.Append($"{edge.Node} (dist:{edge.Distance}), ");
            }

            Console.WriteLine($"Node: { tempNode.Key } - Connects to : {sb.ToString()}");
        }
    }

}


public class ShortestDistCls
{
    public ShortestDistCls(int dist, string prev)
    { this.ShortestDist = dist; this.Prev = prev; }
    /// <summary>
    /// Previous node
    /// </summary>
    public string Prev;

    /// <summary>
    /// Shortest distance from origin
    /// </summary>
    public int ShortestDist;
    
}


public class NodeDist
{
    public string Node { get; set; }
    public int Distance { get; set; }
    public NodeDist(string node, int dist)
    {
        Node = node;
        Distance = dist;
    }
}

//------------------------------------------------------------

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
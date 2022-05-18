using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_BFS
{
    public static class MyGraphTest
    {
        public static void Test()
        {
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

        }
    }


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
}

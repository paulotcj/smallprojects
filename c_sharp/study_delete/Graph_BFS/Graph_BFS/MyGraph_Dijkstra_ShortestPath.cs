namespace Graph_BFS
{

    // Algorithm:
    // Let distance of start vertex from start vertex = 0
    // Let distance of all other vertices from start = infinity (in this example we simply dont have them in the list)
    // 
    // Repeat:
    //    Visit the unvisited vertez with the smallest known distance from the start vertex
    //    For the current vertex, examine its unvisited neighbours
    //    For the current vertex, calculate distance of each neighbour from start vertex
    //    If the calculated distance of a vertex is less than the know distance, update the shortest distance
    //    Update the previous vertez for each of the updated distances
    //    Add the current vertez to the list of visited vertices
    // until all vertices visited



    public static class MyGraph_Dijkstra_ShortestPath_Test
    {
        public static void Test()
        {

            var myGraph2 = new MyGraph_Dijkstra_ShortestPath();

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

            myGraph2 = null;

            Console.WriteLine($"\n\n##############################");
            Console.WriteLine($"##");
            Console.WriteLine($"## NEW TEST");
            Console.WriteLine($"##");
            Console.WriteLine($"##############################");
            Console.WriteLine($"\n\nMatrix input");
            //possible test:
            //
            //     A  B  C  D  E
            //  A  1  1  0  1  0        
            //  B  1  1  1  1  1    
            //  C  0  1  1  0  1    
            //  D  1  1  0  1  1    
            //  E  0  1  1  1  1    
            //


            var nodesArray = new string[] { "A", "B", "C", "D", "E" };
            var edgesArray = new int[][] 
            {
                new int[]{1,  1,  0,  1,  0},
                new int[]{1,  1,  1,  1,  1},
                new int[]{0,  1,  1,  0,  1},
                new int[]{1,  1,  0,  1,  1},
                new int[]{0,  1,  1,  1,  1}
            };
            var distanceArray = new int[][]
            {
                //          A   B   C   D   E
                new int[]{  0,  6, -1,  1, -1 }, //A
                new int[]{  6,  0,  5,  2,  2 }, //B
                new int[]{ -1,  5,  0, -1,  5 }, //C
                new int[]{  1,  2, -1,  0,  1 }, //D
                new int[]{ -1,  2,  5,  1,  0 }  //E
            };


            var myGraph3 = new MyGraph_Dijkstra_ShortestPath();
            myGraph3.InputDataFromMatrix(headers: nodesArray, rows: edgesArray, distances: distanceArray);
            myGraph3.Print();
            Console.WriteLine($"##############################");
            Console.WriteLine($"Dijkstra Shortest Path");
            myGraph3.Dijkstra(start: "A");

            myGraph3.PrintDistanceTable();
            Console.WriteLine($"##############################");
            Console.WriteLine($"Dijkstra Shortest Path - System Identified solution");
            myGraph3.DijkstraPrintSolution("C");

        }
    }


    public class MyGraph_Dijkstra_ShortestPath
    {
        public void InputDataFromMatrix(string[] headers, int[][] rows, int[][] distances)
        {
            
            for(int i = 0; i< headers.Length; i++)
            {
                string node1 = headers[i];

                for(int j = 0; j < rows[i].Length; j++)
                {
                    string node2;
                    int distance;
                    if (rows[i][j] == 1)
                    {
                        node2 = headers[j];
                        distance = distances[i][j];
                        AddEdge(node1, node2, distance);
                    }
                }

            }



        }

        #region distanceTable_comments
        // This table (distanceTable) should work like this:
        //  
        //  VERTEX | SHORTEST DISTANCE FROM START | PREVIOUS VERTEX
        //    A    |   0                          |  A             
        //    B    |   3                          |  D                   
        //    C    |   7                          |  E                     
        //    D    |   1                          |  A                     
        //    E    |   2                          |  D                     
        //
        // And since we want to ideally access this data in contant time through the VERTEX, a dictionary (hash table) seems
        //  a good solution where we are going to store 'Shortest Distance from start' and 'Previous vertex' in a separate
        //  class, just so we can simplify things a little.
        #endregion

        private Dictionary<string, ShortestDistCls> distanceTable = new();
        private Dictionary<string, List<NodeDist>> data = new();
        private string Start;

        Queue<string> q = new(); 
        //LinkedList<string> q = new();

        #region Dijkstra_Algorithm
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
            //q.AddLast(start);
            distanceTable.Add(start, new ShortestDistCls(dist: 0, prev: start));

            while (q.Count > 0) //standard BFS approach, queue the first node and then reach for all its children and then explore from there
            {
                current = q.Dequeue();
                //current = q.First();
                //q.RemoveFirst();
                CalculateDistanceTable(current); //this step is far too complicated so it is better to place it in a separate place
            }

        }

        public void CalculateDistanceTable(string currentNode)
        {
            //---
            ShortestDistCls currentNodeDistance = distanceTable[currentNode];
            List<NodeDist> currentNodeConnections = data[currentNode]; //get a list with all connections for the node which we are accessing
            //---

            Console.WriteLine($"node being investigated {currentNode}");
            //debug
            if (currentNode.CompareTo("C") == 0) 
            { 
            }

            if (currentNode.CompareTo("B") == 0)
            {
            }

            if (currentNode.CompareTo("E") == 0)
            {
            }

            //---
            // Standard BFS, we will look at every child of the current node
            //    now we need to check the distance of all connections from this node
            for (int i = 0; i < currentNodeConnections.Count; i++)
            {
                NodeDist child = currentNodeConnections[i];

                if(child.Node.CompareTo("E") == 0)
                {
                }
                if (child.Node.CompareTo("C") == 0)
                {
                }

                //the options below are simple, we need to identify:
                // 1 - is there a previous path?
                //      if so, is the distance of this path shorter than the existing distance?
                // 2 - If no previous path is found, add one

                //---
                if (distanceTable.ContainsKey(child.Node) == true) //a path exists, lets try to update
                {
                    //we need to update the existing reference if the added distance of the current node and its previous node is less than
                    // the distance of the existing conn

                    ShortestDistCls pathSoFar = distanceTable[child.Node];

                    //sum the shortest path so far, and add the distance of the current edge 
                    int sumDistances = (pathSoFar.ShortestDistance + child.EdgeDistance);

                    //did we find a shorter path? if yes update!
                    if (currentNodeDistance.ShortestDistance > sumDistances)
                    {
                        currentNodeDistance.ShortestDistance = sumDistances; //updated new shorter distance
                        currentNodeDistance.Prev = child.Node; //the shortest path now is taken through the current child node

                        //if the shortest distance of this path is altered we need to reevaluate all paths connected to this path
                        // therefore, we need to enqueue again
                        q.Enqueue(currentNode);

                    }

                }
                else //no previous path exists
                {
                    //add the distances ( current distance + shortest distance so far)
                    //  and then add the current node being inspected to que queue
                    int sumDistances = child.EdgeDistance + currentNodeDistance.ShortestDistance;
                    distanceTable.Add(child.Node, new ShortestDistCls(dist: sumDistances, prev: currentNode));
                    q.Enqueue(child.Node);
                    //q.AddLast(child.Node);

                }


                //---

            } //end for
            //---

        }
        #endregion

        #region DataEntry
        public void AddVertex(string node)
        {
            if (data.ContainsKey(node) == false)
            {
                data[node] = new List<NodeDist>();
            }
        }

        public void AddEdge(string node1, string node2, int dist)
        {
            if (node1.CompareTo(node2) == 0) { return; }
            AddVertex(node1);
            AddVertex(node2);
            bool entryExists;
            entryExists = data[node1].Any(x => x.Node.CompareTo(node2) == 0);
            if (entryExists == false) { data[node1].Add(new NodeDist(node2, dist)); }
            entryExists = data[node2].Any(x => x.Node.CompareTo(node1) == 0);
            if (entryExists == false) { data[node2].Add(new NodeDist(node1, dist)); }
            
        }
        #endregion

        #region print
        public void PrintDistanceTable()
        {
            PrintDistanceTable(distanceTable);
        }
        private void PrintDistanceTable(Dictionary<string, ShortestDistCls> param)
        {

            foreach (var i in param)
            {
                Console.WriteLine($"Vertex: {i.Key} - Shortest Distance from start: {i.Value.ShortestDistance} - Previous Vertex: {i.Value.Prev} ");
            }
        }

        public void Print()
        {
            var tempData = data.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var tempNode in tempData)
            {
                var sb = new System.Text.StringBuilder();
                foreach (var edge in tempNode.Value.OrderBy(x=> x.Node).ToList())
                {
                    sb.Append($"{edge.Node} (dist:{edge.EdgeDistance}), ");
                }

                Console.WriteLine($"Node: { tempNode.Key } - Connects to : {sb.ToString()}");
            }
        }
        #endregion

    }

    #region support_classes
    public class ShortestDistCls
    {
        public ShortestDistCls(int dist, string prev)
        { this.ShortestDistance = dist; this.Prev = prev; }
        /// <summary>
        /// Previous node
        /// </summary>
        public string Prev;

        /// <summary>
        /// Shortest distance from origin
        /// </summary>
        public int ShortestDistance;

    }


    public class NodeDist
    {
        public string Node { get; set; }
        public int EdgeDistance { get; set; }
        public NodeDist(string node, int dist)
        {
            Node = node;
            EdgeDistance = dist;
        }
    }
    #endregion

}

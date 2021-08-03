using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphDFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = ReadGraph();

            int startVertex = int.Parse(Console.ReadLine());
            int endVertex = int.Parse(Console.ReadLine());
            bool isFound = false;
            graph.DFS(startVertex, endVertex, ref isFound);
            if (isFound)
            {
                Console.WriteLine($"Path from {startVertex} to {endVertex} is found");
            }
            else
            {
                Console.WriteLine($"Path from {startVertex} to {endVertex} is not found");
            }
        }

        private static Graph ReadGraph()
        {
            int verticiesCount = int.Parse(Console.ReadLine());
            Graph graph = new Graph(verticiesCount);
            int edgesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < edgesCount; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                graph.AddEdge(data[0], data[1]);
            }
            return graph;
        }

        class Graph
        {
            private int verticiesCount;
            private List<int>[] adjacents;

            public Graph(int _verticiesCount)
            {
                adjacents = new List<int>[_verticiesCount];
                for (int i = 0; i < adjacents.Length; i++)
                {
                    adjacents[i] = new List<int>();
                }
                verticiesCount = _verticiesCount;
            }

            public void AddEdge(int firstVertex, int secondVertex)
            {
                adjacents[firstVertex].Add(secondVertex);
            }

            public void DFS(int startVertex, int endVertex, ref bool isFound)
            {
                bool[] visited = new bool[verticiesCount];
                DFSUntil(startVertex, visited, endVertex, ref isFound);
            }

            private void DFSUntil(int startVertex, bool[] visited, int endVertex, ref bool isFound)
            {
                if(isFound)
                    return;
                visited[startVertex] = true;              
                List<int> verticiesList = adjacents[startVertex];
                foreach (var v in verticiesList)
                {
                    if (!visited[v])
                      DFSUntil(v, visited, endVertex, ref isFound);

                    if(v == endVertex)
                    {
                        isFound = true;
                        return;
                    }
                }
            }
        }
    }
}
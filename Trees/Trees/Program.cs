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

            Console.Write("Following is Depth First " + "Traversal(starting from " + $"vertex {startVertex})\n");

            graph.DFS(startVertex);
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

            public void DFS(int vertex)
            {
                bool[] visited = new bool[verticiesCount];
                DFSUntil(vertex, visited);
            }

            private void DFSUntil(int vertex, bool[] visited)
            {
                visited[vertex] = true;
                Console.Write(vertex + " ");

                List<int> verticiesList = adjacents[vertex];
                foreach (var v in verticiesList)
                {
                    if (!visited[v])
                        DFSUntil(v, visited);
                    {

                    }
                }
            }
        }
    }
}
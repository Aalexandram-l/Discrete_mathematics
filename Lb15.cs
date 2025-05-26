/*Форд-Фалкерсон
 
using System;
using System.Collections.Generic;

public class FordFulkerson
{
    private readonly int[,] residualGraph;
    private readonly int[] parent;        
    private readonly int numVertices;      

    public FordFulkerson(int[,] graph)
    {
        numVertices = graph.GetLength(0);
        residualGraph = new int[numVertices, numVertices];
        Array.Copy(graph, residualGraph, graph.Length);
        parent = new int[numVertices];
    }


    public int MaxFlow(int source, int sink)
    {
        int maxFlow = 0;

        while (BFS(source, sink))
        {
            int pathFlow = int.MaxValue;
            for (int v = sink; v != source; v = parent[v])
            {
                int u = parent[v];
                pathFlow = Math.Min(pathFlow, residualGraph[u, v]);
            }

            for (int v = sink; v != source; v = parent[v])
            {
                int u = parent[v];
                residualGraph[u, v] -= pathFlow;
                residualGraph[v, u] += pathFlow;
            }

            maxFlow += pathFlow;
        }

        return maxFlow;
    }


    private bool BFS(int source, int sink)
    {
        bool[] visited = new bool[numVertices];
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(source);
        visited[source] = true;
        parent[source] = -1;

        while (queue.Count > 0)
        {
            int u = queue.Dequeue();

            for (int v = 0; v < numVertices; v++)
            {
                if (!visited[v] && residualGraph[u, v] > 0)
                {
                    queue.Enqueue(v);
                    parent[v] = u;
                    visited[v] = true;
                }
            }
        }

        return visited[sink]; 
    }
}
public class Program
{
    public static void Main()
    {
        int[,] graph = new int[,]
        {
            // s   1   2   3   4   t
            { 0, 19, 29, 0,  0,  0 }, // s (исток)
            { 0, 0,  0,  0,  9,  14 }, // 1
            { 0, 0,  0,  31,  15,  0 }, // 2
            { 0, 14,  0,  0,  0,  10 }, // 3
            { 0, 0,  0,  34,  0,  15 }, // 4
            { 0, 0,  0,  0,  0,  0 }  // t (сток)
        };

        FordFulkerson fordFulkerson = new FordFulkerson(graph);
        int source = 0; 
        int sink = 5;  

        int maxFlow = fordFulkerson.MaxFlow(source, sink);
        Console.WriteLine($"Максимальный поток: {maxFlow}");
    }
}
*/
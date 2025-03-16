/*Лабораторная работа 3
 * 25.02.2025
найти остовное дерево и из него выделить ребра(с помощью компонента связанности)
найти мосты в графе 

using System;
using System.Collections.Generic;

public class Graph
{
    private int VerticesCount;
    private List<int>[] AdjList;

    public Graph(int verticesCount)
    {
        VerticesCount = verticesCount;
        AdjList = new List<int>[verticesCount];
        for (int i = 0; i < verticesCount; i++)
        {
            AdjList[i] = new List<int>();
        }
    }
    public void AddEdge(int u, int v)
    {
        AdjList[u].Add(v);
    }

    private void DFS(int u, ref int time, int[] disc, int[] low, int[] parent, HashSet<Tuple<int, int>> bridges)
    {
        disc[u] = low[u] = ++time;

        foreach (var v in AdjList[u])
        {
            if (disc[v] == -1) 
            {
                parent[v] = u;
                DFS(v, ref time, disc, low, parent, bridges);

                low[u] = Math.Min(low[u], low[v]);

                if (low[v] > disc[u])
                {
                    bridges.Add(new Tuple<int, int>(u, v));
                }
            }
            else if (v != parent[u]) 
            {
                low[u] = Math.Min(low[u], disc[v]);
            }
        }
    }

    public HashSet<Tuple<int, int>> FindBridges()
    {
        int[] disc = new int[VerticesCount];
        int[] low = new int[VerticesCount];
        int[] parent = new int[VerticesCount];
        HashSet<Tuple<int, int>> bridges = new HashSet<Tuple<int, int>>();
       
        for (int i = 0; i < VerticesCount; i++)
        {
            disc[i] = -1;
            low[i] = -1;
            parent[i] = -1;
        }

        int time = 0; 

        for (int i = 0; i < VerticesCount; i++)
        {
            if (disc[i] == -1)
            {
                DFS(i, ref time, disc, low, parent, bridges);
            }
        }

        return bridges;
    }
}

public class Program
{
    public static void Main()
    {
        Graph graph = new Graph(5); 

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(3, 4);

        HashSet<Tuple<int, int>> bridges = graph.FindBridges();

        Console.WriteLine("Мосты в графе:");
        foreach (var bridge in bridges)
        {
            Console.WriteLine($"({bridge.Item1}, {bridge.Item2})");
        }
    }
}

 */
/* Лабораторная работа 1
   11.02.2025

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int[,] graph = {
            { 0, 1, 0, 0, 1 },
            { 1, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 1 },
            { 1, 0, 0, 1, 0 }
        };

        FindComponents(graph);
    }

    static void FindComponents(int[,] graph)
    {
        int vertices = graph.GetLength(0);
        bool[] visited = new bool[vertices];
        List<List<int>> components = new List<List<int>>();

        for (int v = 0; v < vertices; v++)
        {
            if (!visited[v])
            {
                List<int> component = new List<int>();
                DFS(graph, v, visited, component);
                components.Add(component);
            }
        }

        Console.WriteLine("Компоненты связности:");
        foreach (var component in components)
        {
            Console.WriteLine(string.Join(", ", component));
        }
    }

    static void DFS(int[,] graph, int v, bool[] visited, List<int> component)
    {
        visited[v] = true;
        component.Add(v);

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            if (graph[v, i] == 1 && !visited[i]) 
            {
                DFS(graph, i, visited, component);
            }
        }
    }
}



*/
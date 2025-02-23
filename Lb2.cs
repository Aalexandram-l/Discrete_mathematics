/*Лабораторная работа 2
17.02.2025

using System;
using System.Collections.Generic;
using System.Linq;

public class Kruskal
{
    public class Edge
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public Edge(int source, int destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
    }
    public class DisjointSet
    {
        private int[] parent;
        private int[] rank;

        public DisjointSet(int size)
        {
            parent = new int[size + 1];
            rank = new int[size + 1];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]); 
            }
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                {
                    parent[rootY] = rootX;
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                }
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }
    }
    public static (List<Edge>, int) KruskalMST(int vertices, List<Edge> edges)
    {
        var sortedEdges = edges.OrderBy(e => e.Weight).ToList();

        DisjointSet ds = new DisjointSet(vertices);

        List<Edge> mst = new List<Edge>();
        int totalWeight = 0;

        foreach (var edge in sortedEdges)
        {
            int rootSource = ds.Find(edge.Source);
            int rootDestination = ds.Find(edge.Destination);

            if (rootSource != rootDestination)
            {
                mst.Add(edge);
                totalWeight += edge.Weight;
                ds.Union(rootSource, rootDestination);
            }
        }

        return (mst, totalWeight);
    }

    public static void Main(string[] args)
    {
        int vertices = 7; 
        List<Edge> edges = new List<Edge>
        {
            new Edge(1, 2, 9),
            new Edge(1, 7, 9),
            new Edge(1, 6, 4),
            new Edge(2, 5, 2),
            new Edge(5, 3, 7),
            new Edge(5, 4, 15),
            new Edge(5, 7, 6),
            new Edge(3, 4, 8),
            new Edge(4, 6, 1)
        };

        var (mst, totalWeight) = KruskalMST(vertices, edges);

        Console.WriteLine("Минимальное остовное дерево:");
        foreach (var edge in mst)
        {
            Console.WriteLine($"{edge.Source} - {edge.Destination}: {edge.Weight}");
        }

        Console.WriteLine($"Суммарный вес рёбер остовного дерева: {totalWeight}");
    }
}
*/
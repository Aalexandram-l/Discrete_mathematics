/*Лабораторная работа 5
11.03.2025
алгоритм Форда-Беллмана
на вход весовая матрица
спросить вершину вхождения
на выход последнию лямбду (от заданной до всех остальных)


using System;

class Program
{
    public static void FordBellman(int[,] graph, int tops, int start)
    {
        int[] distan = new int[tops];

        for (int i = 0; i < tops; i++)
        {
            distan[i] = int.MaxValue;
        }
        distan[start] = 0; 

        for (int i = 1; i < tops; i++)
        {
            for (int u = 0; u < tops; u++)
            {
                for (int v = 0; v < tops; v++)
                {
                    if (graph[u, v] != 0 && distan[u] != int.MaxValue && distan[u] + graph[u, v] < distan[v])
                    {
                        distan[v] = distan[u] + graph[u, v];
                    }
                }
            }
        }

        for (int u = 0; u < tops; u++)
        {
            for (int v = 0; v < tops; v++)
            {
                if (graph[u, v] != 0 && distan[u] != int.MaxValue && distan[u] + graph[u, v] < distan[v])
                {
                    Console.WriteLine("Граф содержит отрицательный цикл.");
                    return;
                }
            }
        }

        Console.WriteLine("Расстояния от вершины " + start + ":");
        for (int i = 0; i < tops; i++)
        {
            if (distan[i] == int.MaxValue)
            {
                Console.WriteLine($"До вершины {i} нет пути.");
            }
            else
            {
                Console.WriteLine($"До вершины {i}: {distan[i]}");
            }
        }
    }

    static void Main(string[] args)
    {
        int[,] graph = {
            { 0, 1, 0, 0, 3 },
            { 0, 0, 8, 7, 1},
            { 0, 0, 0, 1, -5 },
            { 0, 0, 2, 0, 0 },
            { 0, 0, 0, 4, 0 }
        };

        Console.WriteLine("Введите номер стартовой вершины (0, 1, 2, ...): ");
        int start = int.Parse(Console.ReadLine());

        FordBellman(graph, graph.GetLength(0), start);
    }
}*/
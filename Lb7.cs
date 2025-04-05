/*
Лабораторная работа 7
31.03.2025

Волновой алгоритм 
массив на две строки и два столбца больше, и по краю обкладываем "камнями"(единичками)
на вход дается матрица со стенками
пользователь задает начальную точку и конечную
на выход минимальный путь (длина)
 

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[,] grid = {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 0, 0, 1, 1, 1 },
            { 1, 0, 1, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 1, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1 }

        };

        Console.WriteLine("Введите начальную точку (x, y):");
        var start = Console.ReadLine().Split(',');
        int stX = int.Parse(start[0]);
        int stY = int.Parse(start[1]);

        Console.WriteLine("Введите конечную точку (x, y):");
        var end = Console.ReadLine().Split(',');
        int eX = int.Parse(end[0]);
        int eY = int.Parse(end[1]);

        List<(int, int)> path = FindPath(grid, (stX, stY), (eX, eY));


        if (path != null)
        {
            Console.WriteLine("Минимальный путь:");
            foreach (var point in path)
            {
                Console.WriteLine($"({point.Item1}, {point.Item2})");
            }
            Console.WriteLine($"Длина пути: {path.Count - 1}"); 
        }
        else
        {
            Console.WriteLine("Путь не найден.");
        }
    }

    static List<(int, int)> FindPath(int[,] grid, (int, int) start, (int, int) end)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);
        bool[,] visited = new bool[rows, cols];
        Queue<(int, int)> queue = new Queue<(int, int)>();
        Dictionary<(int, int), (int, int)> parent = new Dictionary<(int, int), (int, int)>();

        int[,] directions = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };


        queue.Enqueue(start);
        visited[start.Item1, start.Item2] = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current == end)
            {
                return BuildPath(parent, start, end);
            }

            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newX = current.Item1 + directions[i, 0];
                int newY = current.Item2 + directions[i, 1];

                if (newX >= 0 && newX < rows && newY >= 0 && newY < cols &&
                    grid[newX, newY] == 0 && !visited[newX, newY])
                {
                    queue.Enqueue((newX, newY));
                    visited[newX, newY] = true;
                    parent[(newX, newY)] = current; 
                }
            }
        }

        return null; 
    }

    static List<(int, int)> BuildPath(Dictionary<(int, int), (int, int)> parent, (int, int) start, (int, int) end)
    {
        List<(int, int)> path = new List<(int, int)>();
        var current = end;

        while (current != start)
        {
            path.Add(current);
            current = parent[current];
        }
        path.Add(start);
        path.Reverse();

        return path;
    }
}
*/

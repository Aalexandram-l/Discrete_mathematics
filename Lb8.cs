/*Лабораторная работа 8
14.04.2025
только правую ветку алгоритма литла
возвращает длину дороги

using System;
using System.Collections.Generic;

class LittleAlgorithmSimple
{
    const int INF = int.MaxValue;

    static void Main()
    {
        int[,] distances = {
            {INF, 10, 15, 20},
            {10, INF, 35, 25},
            {15, 35, INF, 30},
            {20, 25, 30, INF}
        };

        List<int> bestPath = FindShortestPath(distances);

        Console.WriteLine("Лучший путь: " + string.Join(" -> ", bestPath));
        Console.WriteLine("Длина пути: " + CalculatePathLength(distances, bestPath));
    }

    static List<int> FindShortestPath(int[,] distances)
    {
        int n = distances.GetLength(0);
        List<int> path = new List<int>();
        bool[] visited = new bool[n];

        path.Add(0);
        visited[0] = true;

        while (path.Count < n)
        {
            int lastCity = path[path.Count - 1];
            int nearestCity = -1;
            int minDistance = INF;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i] && distances[lastCity, i] < minDistance)
                {
                    minDistance = distances[lastCity, i];
                    nearestCity = i;
                }
            }

            path.Add(nearestCity);
            visited[nearestCity] = true;
        }

        path.Add(0);
        return path;
    }

    static int CalculatePathLength(int[,] distances, List<int> path)
    {
        int length = 0;
        for (int i = 0; i < path.Count - 1; i++)
        {
            length += distances[path[i], path[i + 1]];
        }
        return length;
    }
}
*/

 
 
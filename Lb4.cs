/*Лабораторная работа 4
 03.03.2025
 * Алгоритм Дейкстры
 на вход подается вершина и куда идем
 дан весовой граф 
 на выход длина пути до определенной вершины


using System.Collections.Generic;
using System.Linq;

public class Dijkstra
{
    public static void Main()
    {
        
        int[,] graph = {
            { 0, 3, 45, 0, 58},
            { 0, 0, 7, 5, 0 },
            { 9, 78, 0, 58, 36 },
            { 87, 0,0, 0, 78},
            { 0, 9, 4, 0, 0},
        };
        Console.WriteLine("Введите стартовую вершину (от 0 до 4): ");
        int start = Convert.ToInt32(Console.ReadLine()); 
        Console.WriteLine("Введите конечную вершину (от 0 до 4): ");
        int target = Convert.ToInt32(Console.ReadLine()); 

        var result = DijkstrasAlgorithm(graph, start, target);

        Console.WriteLine("Минимальный путь от вершины " + start + " до вершины " + target + ": " + result.Item1);
        Console.WriteLine("Путь: " + string.Join(" -> ", result.Item2));
    }

    public static Tuple<int, List<int>> DijkstrasAlgorithm(int[,] graph, int start, int target)
    {
        int verticesCount = graph.GetLength(0);
        int[] dist = new int[verticesCount];
        int[] prev = new int[verticesCount];
        bool[] visited = new bool[verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            dist[i] = int.MaxValue; 
            prev[i] = -1; 
            visited[i] = false;
        }
        dist[start] = 0; 

        for (int i = 0; i < verticesCount - 1; i++)
        {
            int u = GetMin(dist, visited);
            visited[u] = true;

            for (int v = 0; v < verticesCount; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && dist[u] != int.MaxValue &&
                    dist[u] + graph[u, v] < dist[v])
                {
                    dist[v] = dist[u] + graph[u, v];
                    prev[v] = u;
                }
            }
        }

        List<int> path = new List<int>();
        int current = target;
        while (current != -1)
        {
            path.Insert(0, current);
            current = prev[current];
        }

        return new Tuple<int, List<int>>(dist[target], path);
    }

    private static int GetMin(int[] dist, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int i = 0; i < dist.Length; i++)
        {
            if (!visited[i] && dist[i] < min)
            {
                min = dist[i];
                minIndex = i;
            }
        }
        return minIndex;
    }
}
*/

/*Лабороторная работа 6
 * 17.03.2025
Алгоритм Флойда 
на вход весовая матрица
на выход матрица, которая отобрабражает кратчайщие пути

using System;

class Program
{
    static void Main()
    {
        int[,] wM = {
            { 0, 10, 18, 8, int.MaxValue, int.MaxValue},
            { 10, 0, 16, 9, 21 , int.MaxValue},
            { int.MaxValue, 16, 0, int.MaxValue, int.MaxValue , 15},
            { 7, 9, int.MaxValue, 0, int.MaxValue, 12 },
            { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 0 , 23},
            { int.MaxValue, int.MaxValue, 15, int.MaxValue, 23, 0}
            
        };

        int[,] shortestPaths = Floyd(wM);

        Console.WriteLine("Матрица кратчайших путей:");
        Print(shortestPaths);
    }

    static int[,] Floyd(int[,] wMat)
    {
        int n = wMat.GetLength(0);
        int[,] d = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                d[i, j] = wMat[i, j];
            }
        }

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (d[i, k] != int.MaxValue && d[k, j] != int.MaxValue)
                    {
                        d[i, j] = Math.Min(d[i, j], d[i, k] + d[k, j]);
                    }
                }
            }
        }

        return d;
    }

    static void Print(int[,] mat)
    {
        int n = mat.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i, j] == int.MaxValue)
                {
                    Console.Write("INF\t");
                }
                else
                {
                    Console.Write(mat[i, j] + "\t");
                }
            }
            Console.WriteLine();
        }
    }
}
*/
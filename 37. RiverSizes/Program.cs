using System;
using System.Collections.Generic;

namespace _37._RiverSizes
{
    class Program
    {
        // Time (wh)
        // Space (wh)

        static List<int> riverSizes = new List<int>();

        static void Main(string[] args)
        {
            //int[,] array = { {1, 0, 0, 1, 0},
            //                 {1, 0, 1, 0, 0},
            //                 {0, 0, 1, 0, 1},
            //                 {1, 0, 1, 0, 1},
            //                 {1, 0, 1, 1, 0}};


            int[,] array = {    {1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0},
                                {1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0},
                                {0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1},
                                {1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0},
                                {1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1}
                              };

            bool[,] visited = new bool[array.GetLength(0), array.GetLength(1)];
            
           

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (visited[i, j]) { continue; }

                    if(array[i,j] == 1)
                    {
                        GetRiverSize(i, j, visited, array);
                    }
                    else
                    {
                        visited[i, j] = true;
                    }
                }
            }

            Console.Write("River Sizes are : ");
            foreach (var river in riverSizes)
            {
                Console.Write(river.ToString() + " ");
            }

            Console.ReadKey();
        }

        private static int GetRiverSize(int i, int j, bool[,] visited, int[,] array)
        {
            int currentRiverCount = 0;
            Stack<int[]> nodesToVisit = new Stack<int[]>();        
            
            nodesToVisit.Push(new int[] { i, j });
            while (nodesToVisit.Count != 0)
            {
                var currentNode = nodesToVisit.Pop();
                
                i = currentNode[0];
                j = currentNode[1];

                if (visited[i, j]) { continue; }
                currentRiverCount++;
                visited[i, j] = true;
                GetUnvistedNeighbours(nodesToVisit, i,j, visited, array);

            }
            riverSizes.Add(currentRiverCount);
            return currentRiverCount;
        }

        private static void GetUnvistedNeighbours(Stack<int[]> nodesToVisit, int i, int j, bool[,] visited, int[,] array)
        {
            if (i > 0 && array[i-1, j] == 1 && !visited[i-1,j])
            {
                nodesToVisit.Push(new int[] { i-1, j });
                // up && not at edge
            }
            if (j > 0 && array[i,j-1] == 1 && !visited[i, j -1])
            {
                nodesToVisit.Push(new int[] { i, j - 1 });
                // left && not at edge
            }
            if (i < array.GetLength(0) - 1 && array[i + 1, j] == 1 && !visited[i + 1, j])
            {
                nodesToVisit.Push(new int[] { i + 1, j });
                // down && not at edge
            }
            if (j < array.GetLength(1) - 1 && array[i, j + 1] == 1 && !visited[i, j + 1])
            {
                nodesToVisit.Push(new int[] { i, j + 1 });
                // right 
            }

        }
    }
}

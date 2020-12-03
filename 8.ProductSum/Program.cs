using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.ProductSum
{
    class Program
    {
        static List<object> array = new List<object>();
        static void Main(string[] args)
        {
            array.Add(5);
            array.Add(2);
            array.Add(new List<object> { 7, -1 });
            array.Add(3);
            array.Add(new List<object> { 6, new List<object> { -13, 8 }, 4 });
            array.Add(4);
            Console.WriteLine($"Product sum from my attempt : { ProductSumMyAttempt(array)}");
            Console.WriteLine($"Product sum from algoexpert : { ProductSum(array)}");
            Console.ReadLine();
        }

        public static int ProductSumMyAttempt(List<object> array, int multiplier = 1)
        {
            int sum = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i].GetType() == typeof(int))
                {
                    sum += (int)array[i];
                }
                if (array[i].GetType() == typeof(List<object>))
                {
                    sum += ProductSumHelper((List<object>)array[i], multiplier + 1);
                }
            }
            return sum * multiplier;
        }

        public static int ProductSum(List<object> array)
        {
            return ProductSumHelper(array, 1);
        }
        public static int ProductSumHelper(List<object> array, int multiplier)
        {
            int sum = 0;

            foreach (object element in array)
            {
                if(element.GetType() == typeof(List<object>))
                {
                    sum += ProductSumHelper((List<object>)element, multiplier + 1);
                }
                else
                {
                    sum += (int)element;
                }
            }

            return sum * multiplier;
            
        }

    }
}

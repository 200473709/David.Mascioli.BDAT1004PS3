using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace PS3Q2
{
    public class Question2
    {

        public static void run(string inputFile)
        {
            /*
                2 3
                2 4
                16 32 96
             */

            string[] lines = System.IO.File.ReadAllLines(inputFile);

            int[] a;
            int[] b;

            var temporalVar = lines[0].Split(" ");  // First line: number of elements in both arrays
            int elementsInA = int.Parse(temporalVar[0]);
            int elementsInB = int.Parse(temporalVar[1]);

            a = new int[elementsInA];
            b = new int[elementsInB];

            temporalVar = lines[1].Split(" ");      // Second line: integers in the first array
            for (int i = 0; i < temporalVar.Length; i++)
            {
                a[i] = int.Parse(temporalVar[i]);
            }

            temporalVar = lines[2].Split(" ");      // Thrid line: integers in the second array
            for (int i = 0; i < temporalVar.Length; i++)
            {
                b[i] = int.Parse(temporalVar[i]);
            }

            // By this point, we have both arrays populated with the input
            Console.WriteLine(getTotalX(a, b));

        }

        private static string getTotalX(int[] a, int[] b)
        {
            List<int> numbersFound = new List<int>();

            // [smallest int in A] < i < X < i < [biggest int in B]

            int smallestInA = getSmallestInArray(a);
            int biggestInB = getBiggestInArray(b);

            // Now we test our list, that includes every int from smallestInA to biggestInB (including them)
            for (int x = smallestInA; x <= biggestInB; x++)
            {

                if (matchesArrayACondition(a, x) && matchesArrayBCondition(b, x))
                {
                    numbersFound.Add(x);
                }
            }

            return numbersFound.Count.ToString();
        }

        private static int getSmallestInArray(int[] array)
        {
            int smallest = array[0];
            foreach (var item in array)
            {
                if (item < smallest)
                {
                    smallest = item;
                }
            }
            return smallest;
        }

        private static int getBiggestInArray(int[] array)
        {
            int biggest = array[0];
            foreach (var item in array)
            {
                if (item > biggest)
                {
                    biggest = item;
                }
            }
            return biggest;
        }

        private static bool matchesArrayACondition(int[] a, int intToConsider)
        {
            // "The elements of the first array are all factors of the integer being considered".
            foreach (int itemInA in a)
            {

                if (intToConsider % itemInA != 0)   
                    return false;                
            }
            return true;
        }

        private static bool matchesArrayBCondition(int[] b, int intToConsider)
        {
            // "The integer being considered is a factor of all elements of the second array".
            foreach (int itemInB in b)
            {
                if (itemInB % intToConsider != 0)
                    return false;
            }
            return true;
        }
    }
}

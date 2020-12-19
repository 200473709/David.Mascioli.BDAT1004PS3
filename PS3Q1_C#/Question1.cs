using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PS3Q1
{
    public class Question1
    {

        public static void run(string inputFile)
        {
            /* input
                2
                4 3
                -1 -3 4 2
                4 2
                0 -1 2 1
            */

            string[] lines = System.IO.File.ReadAllLines(inputFile);

            // First line from the input is "t", the number of test cases
            int numberOfTestCases = int.Parse(lines[0]);
            //String numberOfTestCases = lines[0];

            int lineNumber = 1; // We skip line number 0, we've already read that one, 

            // Every test case is 2 lines. We read those lines and process them
            //for (int i = 0; i < int.Parse(numberOfTestCases); i++) // if we didn't convert it beforehand
            for (int i = 0; i < numberOfTestCases; i++)
            {
                int numberOfStudents = 0;
                int cancellationThreshold = 0;
                int[] studentArrivals;

                // First line brings the number of students and the cancellation threshold
                string line1 = lines[lineNumber];
                lineNumber++;

                // line1 would be, for example, "4 3". We need to get "4" and "3"
                var temporalVar = line1.Split(" "); // we now have temporalVar[0] = "4" and temporalVar[1] = "3"
                numberOfStudents = int.Parse(temporalVar[0]);
                cancellationThreshold = int.Parse(temporalVar[1]);

                studentArrivals = new int[numberOfStudents];

                // line2 would be, for example, "-1 -3 4 2". We store those in the testcase
                string line2 = lines[lineNumber];
                lineNumber++;

                temporalVar = line2.Split(" ");
                for (int j = 0; j < temporalVar.Length; j++)
                {
                    studentArrivals[j] = int.Parse(temporalVar[j]);
                }

                Console.WriteLine(angryProfessor(cancellationThreshold, studentArrivals));
            }

        }

        /// <summary>
        /// Returns YES if class is cancelled or NO otherwise
        /// </summary>
        /// <param name="k">Cancellation threshold</param>
        /// <param name="a">Arrival times</param>
        /// <returns></returns>
        private static string angryProfessor(int k, int[] a)
        {
            int arrivedOnTime = 0;
            foreach (int arrival in a)
            {
                if (arrival <= 0) arrivedOnTime++;
            }

            if (arrivedOnTime >= k)
                return "NO";
            else
                return "YES";
        }
               
    }
}



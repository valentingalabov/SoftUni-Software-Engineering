using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] entry = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (students.ContainsKey(entry[0]))
                {
                    students[entry[0]].Add(double.Parse(entry[1]));
                }
                else
                {
                    students[entry[0]] = new List<double>()
                    {
                        double.Parse(entry[1])
                    };
                }

            }

            foreach (var item in students)
            {
                Console.Write($"{item.Key} -> ");
                foreach (var grades in item.Value)
                {
                    Console.Write($"{grades:F2} ");
                }
                Console.Write($"(avg: {item.Value.Average():F2})");
                Console.WriteLine();
            }


        }
    }
}

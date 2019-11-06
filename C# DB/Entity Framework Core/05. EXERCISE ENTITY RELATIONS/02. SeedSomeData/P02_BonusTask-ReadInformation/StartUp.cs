using P01_StudentSystem.Data;
using System;
using System.Text;
using System.Linq;

namespace P02_BonusTask_ReadInformation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            StudentSystemContext context = new StudentSystemContext();

            StringBuilder sb = new StringBuilder();

            var courses = context
                .Courses
                .Select(c => new
                { 
                    c.CourseId,
                    c.Name,
                    c.Description,
                    c.StartDate,
                    c.EndDate,
                    c.Price

                
                })
                .ToList();
            sb.AppendLine("Courses :");

            foreach (var item in courses)
            {
                sb.AppendLine(item.ToString());
            }


            var students = context
                .Students
                .Select(s => new
                {
                    s.StudentId,
                    s.Name,
                    s.PhoneNumber,
                    s.RegisteredOn,
                    s.Birthday

                }).ToList();

            sb.AppendLine("Students :");

            foreach (var item in students)
            {
                sb.AppendLine(item.ToString());
            }


            Console.WriteLine(sb.ToString().TrimEnd());

        }
    }
}

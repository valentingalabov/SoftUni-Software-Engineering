using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Student_System
{
    public class StudentSystem
    {
        private Dictionary<string, Student> repo;

        public StudentSystem()
        {
            repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo { get; private set; }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            switch (args[0])
            {
                case "Create":
                    CreateStudents(args);
                    break;
                case "Show":
                    ShowStudents(args);
                    break;
                case "Exit":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }

        }

        private void ShowStudents(string[] args)
        {
            string name = args[0];
            var age = int.Parse(args[1]);
            var grade = double.Parse(args[2]);
        }

        private void Exit()
        {
            throw new NotImplementedException();
        }

        private void CreateStudents(string[] args)
        {
            string name = args[0];
            var age = int.Parse(args[1]);
            var grade = double.Parse(args[2]);

            var newStudent = new Student(name, age, grade);

            if (!repo.ContainsKey(name))
            {
                repo.Add(name, newStudent);
            }
        }
    }
}

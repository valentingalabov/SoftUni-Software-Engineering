using System;
using System.Collections.Generic;


namespace _03._Student_System
{
    public class StudentSystem
    {
      

        public StudentSystem()
        {
            Repo = new Dictionary<string, Student>();
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
            string name = args[1];
            if (Repo.ContainsKey(name))
            {
                var student = Repo[name];
                Console.WriteLine(student);

            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void CreateStudents(string[] args)
        {

            string name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            var newStudent = new Student(name, age, grade);

            if (!Repo.ContainsKey(name))
            {
                Repo.Add(name, newStudent);
            }
        }
    }
}

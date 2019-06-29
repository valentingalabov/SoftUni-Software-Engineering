

namespace _03._Student_System
{
    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Grade { get; set; }



        public override string ToString()
        {
            string view = $"{Name} is {Age} years old. ";
            if (Grade > 5.00)
            {
                view += $"Excellent Studen";
            }
            else if (Grade < 5.00 && Grade >= 3.50)
            {
                view += $"Average Student";
            }
            else
            {
                view += $"Perfect Student";
            }

            return view;
        }

    }
}

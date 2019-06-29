

namespace _03._Student_System
{
    class StartUp
    {
        static void Main(string[] args)
        {
           var StudentSystem = new StudentSystem();

            while (true)
            {
                StudentSystem.ParseCommand();
            }

        }
    }
}

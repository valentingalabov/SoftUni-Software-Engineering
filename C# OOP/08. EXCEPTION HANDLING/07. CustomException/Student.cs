namespace CustomException
{
    public class Student
    {
        private string name;
       

        public Student(string name, string email)
        {
           this.Name = name;
           this.Email = email;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                foreach (var item in value)
                {
                    if (char.IsSymbol(item)||char.IsNumber(item))
                    {
                        throw new InvalidPersonNameException("Name does not allow any special character or numeric value in a name of any of the students.");
                    }
                }

                this.name = value;

                
            }

        }

        public string Email { get; set; }
    }
}

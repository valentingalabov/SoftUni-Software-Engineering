namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        const string currentModel = "488-Spider";

        public Ferrari( string driver)
        {
            this.Model = currentModel;
            this.Driver = driver;
        }

        public string Model { get; private set; }

        public string Driver { get; private set; }

        public string Break()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{Break()}/{Gas()}/{this.Driver}";
        }
    }
}

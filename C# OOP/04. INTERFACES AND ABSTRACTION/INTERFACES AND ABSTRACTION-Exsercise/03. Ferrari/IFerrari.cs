namespace Ferrari
{
    public interface IFerrari
    {
        string Model { get; }
        string Driver { get; }

        string Break();

        string Gas();
    }
}

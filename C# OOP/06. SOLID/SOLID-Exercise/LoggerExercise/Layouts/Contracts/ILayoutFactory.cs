using LoggerExerciseExercise.Layouts.Contracts;

namespace LoggerExercise.Layouts.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);

    }
}

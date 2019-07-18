using LoggerExerciseExercise.Layouts.Contracts;

namespace LoggerExerciseExercise.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}

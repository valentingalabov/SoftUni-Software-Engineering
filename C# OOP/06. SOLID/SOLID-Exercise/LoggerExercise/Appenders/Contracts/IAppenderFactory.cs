using LoggerExerciseExercise.Appenders.Contracts;
using LoggerExerciseExercise.Layouts.Contracts;

namespace LoggerExercise.Appenders.Contracts
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}

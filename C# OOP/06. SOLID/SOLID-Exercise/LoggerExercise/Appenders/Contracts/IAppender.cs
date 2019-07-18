using LoggerExercise.Loggers.Enums;

namespace LoggerExerciseExercise.Appenders.Contracts
{
    public interface IAppender
    {
        void Append(string dateTime, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }
    }
}

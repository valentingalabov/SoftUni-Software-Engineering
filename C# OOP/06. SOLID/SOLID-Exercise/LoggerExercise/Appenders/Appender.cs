using LoggerExercise.Loggers.Enums;
using LoggerExerciseExercise.Appenders.Contracts;
using LoggerExerciseExercise.Layouts.Contracts;

namespace LoggerExercise.Appenders
{
    public abstract class Appender : IAppender
    {

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        protected ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

    }
}

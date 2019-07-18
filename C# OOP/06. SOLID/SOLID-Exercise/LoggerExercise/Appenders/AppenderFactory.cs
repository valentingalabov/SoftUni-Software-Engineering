using LoggerExercise.Appenders.Contracts;
using LoggerExercise.Loggers;
using LoggerExerciseExercise.Appenders;
using LoggerExerciseExercise.Appenders.Contracts;
using LoggerExerciseExercise.Layouts.Contracts;
using System;

namespace LoggerExercise.Appenders
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}

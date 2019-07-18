using LoggerExercise.Appenders;
using LoggerExercise.Loggers.Enums;
using LoggerExerciseExercise.Appenders.Contracts;
using LoggerExerciseExercise.Layouts.Contracts;
using System;

namespace LoggerExerciseExercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        private int messageCount = 0;
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {

        }


        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                messageCount++;
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.messageCount}";
        }
    }
}

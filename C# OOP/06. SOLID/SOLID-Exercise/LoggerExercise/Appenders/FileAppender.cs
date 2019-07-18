using LoggerExercise.Loggers.Contracts;
using LoggerExercise.Loggers.Enums;
using LoggerExerciseExercise.Appenders.Contracts;
using LoggerExerciseExercise.Layouts.Contracts;
using System;
using System.IO;

namespace LoggerExercise.Appenders
{
    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";

        private int messageCount = 0;

        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

       


        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;
                logFile.Write(content);
                File.AppendAllText(Path, content);
                messageCount++;
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.messageCount}, File size: {logFile.Size}";
        }
    }
}

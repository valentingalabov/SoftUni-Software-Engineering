﻿
using System;
using System.Text;
using LoggerExercise.Loggers.Enums;
using LoggerExerciseExercise.Appenders.Contracts;
using LoggerExerciseExercise.Loggers.Contracts;

namespace LoggerExerciseExercise.Loggers
{
    public class Logger : ILogger
    {

        private IAppender consoleAppender;
        private IAppender fileAppender;
        private IAppender apenders;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAppender = consoleAppender;

        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            : this(consoleAppender)
        {

            this.fileAppender = fileAppender;
        }

        public void Info(string dateTime, string infoMessage)
        {
            this.Append(dateTime, ReportLevel.INFO, infoMessage);
        }

        public void Warning(string dateTime, string warningMessage)
        {
            this.Append(dateTime, ReportLevel.WARNING, warningMessage);
        }

        public void Error(string dateTime, string errorMessage)
        {
            this.Append(dateTime, ReportLevel.ERROR, errorMessage);
        }

        public void Critical(string dateTime, string criticalMessage)
        {
            this.Append(dateTime, ReportLevel.CRITICAL, criticalMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            this.Append(dateTime, ReportLevel.FATAL, fatalMessage);
        }
 
        private void Append(string dateTime, ReportLevel type, string message)
        {
            consoleAppender?.Append(dateTime, type, message);
            fileAppender?.Append(dateTime, type, message);
        }

      
    }
}

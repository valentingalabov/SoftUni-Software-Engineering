﻿namespace LoggerExerciseExercise.Loggers.Contracts
{
    public interface ILogger
    {
        void Info(string dateTime, string infoMessage);

        void Warning(string dateTime, string infoMessage);

        void Error(string dateTime, string errorMessage);

        void Critical(string dateTime, string errorMessage);

        void Fatal(string dateTime, string errorMessage);


    }
}

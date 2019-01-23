using System;
using System.IO;
using TShirtPicker.Data;
using TShirtPicker.Data.Models;

namespace TShirtPicker
{
    internal class Log
    {
        private string localLogPath = @"log.txt";
        private LogRepository logRepository = new LogRepository();

        public void LogData(string message, Severity severity)
        {
            try
            {
                this.logRepository.Insert(message, severity);
            }
            catch (Exception exception)
            {
                File.AppendAllText(this.localLogPath,
                    $"{DateTime.UtcNow} - Severity: {severity} Message: {exception.Message}," +
                    $" Stack Trace: {exception.StackTrace}" + Environment.NewLine);
            }

        }
    }
}

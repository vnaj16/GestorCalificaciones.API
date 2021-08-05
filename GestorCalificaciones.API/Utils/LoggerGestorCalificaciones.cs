using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Utils
{
    public class LoggerGestorCalificaciones : ILoggerGC
    {
        public void WriteLog(Exception ex)
        {
            var time = DateTime.Now;
            File.AppendAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/logs_gc.txt", $"{time} - Message: {ex.Message} - Stacktrace: {ex.StackTrace}\n\n");
        }
    }
}

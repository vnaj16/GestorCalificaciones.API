using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorCalificaciones.API.Utils
{
    public interface ILoggerGC
    {
        public void WriteLog(Exception ex);
    }
}

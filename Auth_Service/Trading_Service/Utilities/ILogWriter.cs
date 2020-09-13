using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Utilities
{
   public interface ILogWriter
    {
        string LogWrite(string message);
    }
}

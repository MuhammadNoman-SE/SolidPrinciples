using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface ILogger{
        void Logg(string message);
    }
    public class Logger:ILogger
    {
        public void Logg(string message) {
            Console.WriteLine(message);
        }
    }
}

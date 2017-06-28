using System;

namespace DragonsOfMugloar.Services.Logger
{
    public class ConsoleLogger : AbstractLogger
    {
        protected override void LogMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}

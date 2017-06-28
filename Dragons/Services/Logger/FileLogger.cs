using System.IO;

namespace DragonsOfMugloar.Services.Logger
{
    public class FileLogger : AbstractLogger
    {
        private string _fileName;

        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }

        protected override void LogMessage(string message)
        {
            var logPath = Directory.GetCurrentDirectory() + _fileName;

            if (!File.Exists(logPath))
            {
                File.Create(logPath);
            }

            var logWriter = File.AppendText(logPath);

            logWriter.WriteLine(message);
            logWriter.Dispose();
        }


    }
}

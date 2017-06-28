namespace DragonsOfMugloar.Services.Logger
{
    public abstract class AbstractLogger : ILogger
    {
        public AbstractLogger NextLogger { get; set; }

        protected abstract void LogMessage(string message);

        public void Write(string message)
        {
            LogMessage(message);

            NextLogger?.LogMessage(message);
        }
    }
}

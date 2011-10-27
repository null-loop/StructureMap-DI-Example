namespace ServiceLibrary
{
    using ServiceLibrary.Contract;

    public class TimeService : ITimeService
    {
        public TimeService(ITimeProvider timeProvider, ITimeFormatter timeFormatter)
        {
            TimeProvider = timeProvider;
            TimeFormatter = timeFormatter;
        }

        public string GetServerTime()
        {
            return TimeFormatter.Format(TimeProvider.ServerTime);
        }

        protected ITimeProvider TimeProvider { get; private set; }
        protected ITimeFormatter TimeFormatter { get; private set; }

        public string GetFormattedServerTime(string format)
        {
            return TimeFormatter.Format(TimeProvider.ServerTime, format);
        }
    }
}
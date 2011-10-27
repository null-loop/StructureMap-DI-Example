namespace ServiceLibrary
{
    using System;

    public class DefaultTimeProvider : ITimeProvider
    {
        public DateTime ServerTime
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
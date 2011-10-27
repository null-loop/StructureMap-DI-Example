namespace ServiceLibrary
{
    using System;

    using ServiceLibrary.Configuration;

    public class TimeFormatter : ITimeFormatter
    {
        protected IConfigurationAccessor ConfigurationAccessor { get; set; }

        private string _defaultFormat;

        public TimeFormatter(string defaultFormat)
        {
            if (string.IsNullOrEmpty(defaultFormat))
            {
                throw new ArgumentNullException("defaultFormat", "DefaultFormat must be not null and not an empty string");
            }

            _defaultFormat = defaultFormat;
        }

        public TimeFormatter(IConfigurationAccessor configurationAccessor)
        {
            if (configurationAccessor == null) throw new ArgumentNullException("configurationAccessor");

            ConfigurationAccessor = configurationAccessor;

            _defaultFormat = ConfigurationAccessor.GetString("DefaultFormat");
        }

        public string Format(DateTime dateTime)
        {
            return dateTime.ToString(_defaultFormat);
        }

        public string Format(DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }
    }
}

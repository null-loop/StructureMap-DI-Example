namespace ServiceLibrary.Configuration
{
    using System.Configuration;

    public class WebAppConfigurationAccessor : ConfigurationAccessorBase
    {
        public override string GetString(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
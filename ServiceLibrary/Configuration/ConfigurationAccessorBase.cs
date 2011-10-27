namespace ServiceLibrary.Configuration
{
    using System;

    public abstract class ConfigurationAccessorBase : IConfigurationAccessor
    {
        public abstract string GetString(string key);

        public IConfigurationAccessor Scope(Type typeScope)
        {
            return new ConfigurationAccessorScope(typeScope, this);
        }
    }
}
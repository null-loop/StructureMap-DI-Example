namespace ServiceLibrary.Configuration
{
    using System;

    public interface IConfigurationAccessor
    {
        string GetString(string key);

        IConfigurationAccessor Scope(Type typeScope);
    }
}
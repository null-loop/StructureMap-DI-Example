namespace ServiceLibrary.Configuration
{
    using System;

    public class ConfigurationAccessorScope : IConfigurationAccessor
    {
        private readonly string _scopeName;

        private readonly IConfigurationAccessor _parent;

        internal ConfigurationAccessorScope(Type scopeType, IConfigurationAccessor parent)
        {
            this._scopeName = scopeType.Name;
            _parent = parent;
        }

        internal string ScopeName { get { return _scopeName; } }

        public void Dispose()
        {
        }

        public string GetString(string key)
        {
            return _parent.GetString(GetKeyWithScope(key));
        }

        private string GetKeyWithScope(string key)
        {
            return string.Format("{0}.{1}", this._scopeName, key);
        }

        public IConfigurationAccessor Scope(Type typeScope)
        {
            return _parent.Scope(typeScope);
        }
    }
}
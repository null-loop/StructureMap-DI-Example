using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IisServiceHost
{
    using ServiceLibrary;
    using ServiceLibrary.Configuration;

    using StructureMap.Configuration.DSL;

    public class ServiceHostRegistry : Registry
    {
        private WebAppConfigurationAccessor _appConfigurationAccessor;

        public ServiceHostRegistry()
        {
            _appConfigurationAccessor = new WebAppConfigurationAccessor();


            For<ITimeProvider>().Use<DefaultTimeProvider>();
            For<ITimeFormatter>().Use<TimeFormatter>();

            SelectConstructor(() => new TimeFormatter(_appConfigurationAccessor));
            For<IConfigurationAccessor>().AlwaysUnique().Use(x => _appConfigurationAccessor.Scope(x.ParentType));


            // don't like this - tying to constructor parameters... no refactor safe
            //For<ITimeFormatter>().Use<TimeFormatter>().Ctor<string>("defaultFormat").EqualToAppSetting("TimeFormatter.DefaultFormat");

        }
    }
}
namespace StructureMapWcfIntegration
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;

    using StructureMap;

    public class StructureMapInstanceProvider : IInstanceProvider
    {
        public Type ServiceType { get; set; }

        public StructureMapInstanceProvider(Type serviceType)
        {
            ServiceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return ObjectFactory.GetInstance(ServiceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }
    }
}
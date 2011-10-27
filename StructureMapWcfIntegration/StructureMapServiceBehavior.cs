namespace StructureMapWcfIntegration
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    public class StructureMapServiceBehavior : IServiceBehavior
    {
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcher in serviceHostBase.ChannelDispatchers.Cast<ChannelDispatcher>())
                foreach (var endpointDispatcher in channelDispatcher.Endpoints)
                    endpointDispatcher.DispatchRuntime.InstanceProvider = new StructureMapInstanceProvider(serviceDescription.ServiceType);
        }
    }
}
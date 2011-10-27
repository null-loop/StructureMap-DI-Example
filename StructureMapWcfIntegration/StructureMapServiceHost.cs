namespace StructureMapWcfIntegration
{
    using System;
    using System.ServiceModel;

    public class StructureMapServiceHost : ServiceHost
    {
        public StructureMapServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new StructureMapServiceBehavior());
            base.OnOpening();
        }
    }
}
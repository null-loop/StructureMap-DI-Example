namespace ServiceLibrary.Contract
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ITimeService
    {
        [OperationContract]
        string GetServerTime();

        [OperationContract]
        string GetFormattedServerTime(string format);
    }
}
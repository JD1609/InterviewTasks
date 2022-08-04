using System.ServiceModel;

namespace Administration_app
{
    [ServiceContract]
    interface IDeviceControl
    {
        [OperationContract]
        string SendMessage(int id, string message);
    }
}

using System;
using System.ServiceModel;
using System.Threading.Tasks;
using dts.gui.Commons;
using dts.gui.DtsServiceClients;
using dts.gui.Person;
using dts.gui.PersonSubscriptionService;

namespace dts.gui.Services
{
    public class PersonServiceClient : DisposeableObject, IPubSubServiceClient
    {
        private static readonly Uri _baseAddress = new Uri("http://localhost:3031/PersonSubscriptionService");
        private readonly PersonSubscriptionServiceClient _dtsPersonServiceClient;

        public PersonServiceClient(IPersonServiceCallBack callBack)
        {
            _dtsPersonServiceClient = new PersonSubscriptionServiceClient(new InstanceContext(null, callBack));
            var uniqueCallbackAddress = _baseAddress.AbsoluteUri;
            // make it unique - append a GUID
            uniqueCallbackAddress += Guid.NewGuid().ToString();
            ((WSDualHttpBinding)_dtsPersonServiceClient.Endpoint.Binding).ClientBaseAddress = new Uri(uniqueCallbackAddress);
        }

        public bool Subscribe()
        {
            //return _dtsPersonServiceClient.Subscribe();
            Task.Factory.StartNew(() => _dtsPersonServiceClient.Subscribe());
            return true;
        }

        public bool UnSubscribe()
        {
            return true;
        }
    }
}

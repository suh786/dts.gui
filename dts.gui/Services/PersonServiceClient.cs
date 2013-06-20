using System;
using System.ServiceModel;
using dts.gui.DtsServiceClients;
using dts.gui.Models;
using dts.gui.Person;
using dts.gui.RegistrationService;

namespace dts.gui.Services
{
    public class PersonServiceClient : DisposeableObject, IPubSubServiceClient
    {
        private static readonly Uri _baseAddress = new Uri("http://localhost:3031/RegistrationService");
        private readonly RegistrationServiceClient _dtsPersonServiceClient;

        public PersonServiceClient(IPersonServiceCallBack callBack)
        {
            _dtsPersonServiceClient = new RegistrationServiceClient(new InstanceContext(null, callBack));
            var uniqueCallbackAddress = _baseAddress.AbsoluteUri;
            // make it unique - append a GUID
            uniqueCallbackAddress += new Guid().ToString();
            ((WSDualHttpBinding)_dtsPersonServiceClient.Endpoint.Binding).ClientBaseAddress = new Uri(uniqueCallbackAddress);
        }

        public bool Subscribe()
        {
            return _dtsPersonServiceClient.Subscribe()
        }

        public bool UnSubscribe()
        {
            throw new System.NotImplementedException();
        }
    }
}

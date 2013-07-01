
using System.ComponentModel.Composition;
using dts.gui.Person;
using dts.gui.Services;

namespace dts.gui.DtsServiceClients
{
    public interface IPubSubServiceClientFactory
    {
        IPubSubServiceClient CreatePersonServiceClient(IPersonServiceCallBack callback);
    }

    [Export(typeof(IPubSubServiceClientFactory))]
    public class PubSubServiceClientFactory : IPubSubServiceClientFactory
    {
        public IPubSubServiceClient CreatePersonServiceClient(IPersonServiceCallBack callback)
        {
            return new PersonServiceClient(callback);
        }
    }
}

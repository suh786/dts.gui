using System;

namespace dts.gui.DtsServiceClients
{
    public interface IPubSubServiceClient : IDisposable
    {
        bool Subscribe();
        bool UnSubscribe();
    }
}

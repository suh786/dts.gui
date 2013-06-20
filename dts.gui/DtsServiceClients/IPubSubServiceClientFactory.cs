﻿
using dts.gui.Models;
using dts.gui.Person;
using dts.gui.Services;

namespace dts.gui.DtsServiceClients
{
    public interface IPubSubServiceClientFactory
    {
        IPubSubServiceClient CreatePersonServiceClient(IPersonServiceCallBack callback);
    }

    public class PubSubServiceClientFactory : IPubSubServiceClientFactory
    {
        public IPubSubServiceClient CreatePersonServiceClient(IPersonServiceCallBack callback)
        {
            
        }
    }
}
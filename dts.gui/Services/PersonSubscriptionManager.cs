using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dts.gui.DtsServiceClients;
using dts.gui.Models;
using dts.gui.Person;

namespace dts.gui.Services
{
    public class PersonSubscriptionManager : SubscriptionManagerBase<IPersonRecord, IPersonServiceCallBack>
    {
        protected override IPubSubServiceClient GetServiceClient(IPubSubServiceClientFactory clientFactory, IPersonServiceCallBack callback)
        {
            return clientFactory.CreatePersonServiceClient(callback);
        }

        protected override IPersonServiceCallBack GetCallBack()
        {
            return new PersonServiceCallBack();
        }
    }

}

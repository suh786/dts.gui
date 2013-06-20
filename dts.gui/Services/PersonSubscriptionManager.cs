using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dts.gui.DtsServiceClients;
using dts.gui.Models;
using dts.gui.Person;
using dts.gui.RegistrationService;

namespace dts.gui.Services
{
    public class PersonSubscriptionManager : SubscriptionManagerBase<IPersonRecord, IPersonServiceCallBack>
    {
        public PersonSubscriptionManager() : base(new Guid().ToString())
        {
        }

        protected override IPubSubServiceClient GetServiceClient(IPubSubServiceClientFactory clientFactory, IPersonServiceCallBack callback)
        {
            return clientFactory.CreatePersonServiceClient(callback);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dts.gui.Models;
using dts.gui.RegistrationService;

namespace dts.gui.Services
{
    public class PersonSubscriptionManager<TRecord, TCallBack> : SubscriptionManagerBase<TRecord, TCallBack> where TRecord : IPubSubRecord where TCallBack : IPubSubServiceCallback<TRecord>
    {
        public PersonSubscriptionManager() : base(new Guid().ToString())
        {
        }

        protected override bool OnSubscribe(RegistrationServiceClient dtsServiceClient)
        {
            throw new NotImplementedException();
        }

        protected override bool OnUnSubscribe(RegistrationServiceClient dtsServiceClient)
        {
            throw new NotImplementedException();
        }

        protected override TCallBack GetCallBack()
        {
            throw new NotImplementedException();
        }
    }

}

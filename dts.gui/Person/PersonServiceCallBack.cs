using System;
using dts.gui.RegistrationService;
using dts.gui.Services;

namespace dts.gui.Person
{
    public interface IPersonServiceCallBack : IPubSubServiceCallback<IPersonRecord>
    {
    }

    public class PersonServiceCallBack : IPersonServiceCallBack, IRegistrationServiceCallback
    {
        public event System.EventHandler<PubSubServiceRecordAddedEventArgs<IPersonRecord>> RecordAdded;
        public void RaiseRecordAdded(PubSubServiceRecordAddedEventArgs<IPersonRecord> e)
        {
            if (RecordAdded != null)
            {
                RecordAdded(this, e);
            }
        }

        public event EventHandler<PubSubServiceRecordUpdatedEventArgs<IPersonRecord>> RecordUpdated;

        public event EventHandler<PubSubServiceRecordDeletedEventArgs> RecordDeleted;
        
        void IRegistrationServiceCallback.RecordAdded(RegistrationService.Person record)
        {
            RaiseRecordAdded(new PubSubServiceRecordAddedEventArgs<IPersonRecord>(new PersonRecord(record)));
        }
    }
}

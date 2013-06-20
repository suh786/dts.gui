using System;
using System.Threading.Tasks;
using dts.gui.PersonSubscriptionService;
using dts.gui.Services;

namespace dts.gui.Person
{
    public interface IPersonServiceCallBack : IPubSubServiceCallback<IPersonRecord>
    {
    }

    public class PersonServiceCallBack : IPersonServiceCallBack, IPersonSubscriptionServiceCallback
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

        void IPersonSubscriptionServiceCallback.RecordAdded(PersonSubscriptionService.Person record)
        {
            /*var person = record;
            Task.Factory.StartNew(() => RaiseRecordAdded(new PubSubServiceRecordAddedEventArgs<IPersonRecord>(new PersonRecord(person))));*/
            RaiseRecordAdded(new PubSubServiceRecordAddedEventArgs<IPersonRecord>(new PersonRecord(record)));
        }
    }
}

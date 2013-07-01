using System;
using System.Threading.Tasks;
using dts.gui.PersonSubscriptionService;
using dts.gui.Services;
using System.Linq;

namespace dts.gui.Person
{
    public interface IPersonServiceCallBack : IPubSubServiceCallback<IPersonRecord>
    {
    }

    public class PersonServiceCallBack : IPersonServiceCallBack, IPersonSubscriptionServiceCallback
    {
        public event EventHandler<PubSubServiceRecordAddedEventArgs<IPersonRecord>> RecordAdded;
        public void RaiseRecordAdded(PubSubServiceRecordAddedEventArgs<IPersonRecord> e)
        {
            if (RecordAdded != null)
            {
                RecordAdded(this, e);
            }
        }

        public event EventHandler<PubSubServiceRecordUpdatedEventArgs<IPersonRecord>> RecordUpdated;

        public event EventHandler<PubSubServiceRecordDeletedEventArgs> RecordDeleted;

        void IPersonSubscriptionServiceCallback.RecordsAdded(PersonSubscriptionService.Person[] records)
        {
            /*var person = record;
            Task.Factory.StartNew(() => RaiseRecordAdded(new PubSubServiceRecordAddedEventArgs<IPersonRecord>(new PersonRecord(person))));*/
            RaiseRecordAdded(new PubSubServiceRecordAddedEventArgs<IPersonRecord>(records.Select(x => new PersonRecord(x))));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dts.gui.Models;

namespace dts.gui.Services
{
    
    public interface IPubSubServiceCallback<T>  where T : IPubSubRecord
    {
        event EventHandler<PubSubServiceRecordAddedEventArgs<T>> RecordAdded;
        event EventHandler<PubSubServiceRecordUpdatedEventArgs<T>> RecordUpdated;
        event EventHandler<PubSubServiceRecordDeletedEventArgs> RecordDeleted;
    }

    public class PubSubServiceRecordDeletedEventArgs : EventArgs
    {
        public PubSubServiceRecordDeletedEventArgs(string id)
        {
            RecordId = id;
        }

        public string RecordId { get; private set; }
    }

    public class PubSubServiceRecordUpdatedEventArgs<T> : EventArgs where T : IPubSubRecord
    {
        public PubSubServiceRecordUpdatedEventArgs(T record)
        {
            Record = record;
        }
        public T Record { get; private set; }
    }

    public class PubSubServiceRecordAddedEventArgs<T> : EventArgs where T: IPubSubRecord
    {
        public PubSubServiceRecordAddedEventArgs(T record)
        {
            Record = record;
        }
        public T Record { get; private set; }
    }
}

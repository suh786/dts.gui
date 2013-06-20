using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dts.gui.Models;

namespace dts.gui.Services
{
    public interface ISubscriptionManager<T> : IDisposable where T : IPubSubRecord
    {
        bool Subscribe();
        bool Unsubscribe();

        event EventHandler<RecordAddedEventArgs<T>> RecordAdded;
        event EventHandler<RecordUpdatedEventArgs<T>> RecordUpdated;
        event EventHandler<RecordDeletedEventArgs> RecordDeleted;
    }

    public class RecordDeletedEventArgs : EventArgs
    {
        public RecordDeletedEventArgs(string id)
        {
            RecordId = id;
        }

        public string RecordId { get; private set; }
    }

    public class RecordUpdatedEventArgs<T> : EventArgs where T : IPubSubRecord
    {
        public RecordUpdatedEventArgs(T record)
        {
            Record = record;
        }
        public T Record { get; private set; }
    }

    public class RecordAddedEventArgs<T> : EventArgs where T : IPubSubRecord
    {
        public RecordAddedEventArgs(T record)
        {
            Record = record;
        }
        public T Record { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dts.gui.Commons;

namespace dts.gui.Services
{
    public interface ISubscriptionManager<T> : IDisposable where T : IPubSubRecord
    {
        bool Subscribe();
        bool Unsubscribe();

        event EventHandler<RecordAddedEventArgs<T>> RecordsAdded;
        event EventHandler<RecordUpdatedEventArgs<T>> RecordsUpdated;
        event EventHandler<RecordDeletedEventArgs> RecordsDeleted;
    }

    public class RecordDeletedEventArgs : EventArgs
    {
        public RecordDeletedEventArgs(IEnumerable<string> ids)
        {
            RecordIds = ids;
        }

        public IEnumerable<string> RecordIds { get; private set; }
    }

    public class RecordUpdatedEventArgs<T> : EventArgs where T : IPubSubRecord
    {
        public RecordUpdatedEventArgs(IEnumerable<T> records)
        {
            Records = records;
        }
        public IEnumerable<T> Records { get; private set; }
    }

    public class RecordAddedEventArgs<T> : EventArgs where T : IPubSubRecord
    {
        public RecordAddedEventArgs(IEnumerable<T> records)
        {
            Records = records;
        }
        public IEnumerable<T> Records { get; private set; }
    }
}

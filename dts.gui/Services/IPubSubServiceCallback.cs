using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dts.gui.Commons;

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
        public PubSubServiceRecordDeletedEventArgs(IEnumerable<string> ids)
        {
            RecordIds = ids;
        }

        public IEnumerable<string> RecordIds { get; private set; }
    }

    public class PubSubServiceRecordUpdatedEventArgs<T> : EventArgs where T : IPubSubRecord
    {
        public PubSubServiceRecordUpdatedEventArgs(IEnumerable<T> records)
        {
            Records = records;
        }
        public IEnumerable<T> Records { get; private set; }
    }

    public class PubSubServiceRecordAddedEventArgs<T> : EventArgs where T: IPubSubRecord
    {
        public PubSubServiceRecordAddedEventArgs(IEnumerable<T> records)
        {
            Records = records;
        }
        public IEnumerable<T> Records { get; private set; }
    }
}

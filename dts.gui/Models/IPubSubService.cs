using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dts.gui.Models
{
    public interface IPubSubService<T> : IDisposable where T : IPubSubRecord
    {
        void Start();
        void Stop();
        event EventHandler<RecordAddEventArgs<T>> RecordAdded;
        event EventHandler<RecordUpdateEventArgs<T>> RecordUpdated;
        event EventHandler<RecordDeleteEventArgs> RecordDeleted;
    }

    public class RecordAddEventArgs<T> : EventArgs where T : IPubSubRecord
    {
        public RecordAddEventArgs(T record)
        {
            Record = record;
        }
        public T Record { get; private set; }
    }

    public class RecordUpdateEventArgs<T> : EventArgs where T : IPubSubRecord
    {
        public RecordUpdateEventArgs(T record)
        {
            Record = record;
        }

        public T Record { get; private set; }
    }

    public class RecordDeleteEventArgs : EventArgs
    {
        public RecordDeleteEventArgs(string id)
        {
            RecordId = id;
        }

        public string RecordId { get; private set; }
    }
}

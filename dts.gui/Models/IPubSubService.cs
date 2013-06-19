using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dts.gui.Person;

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

    public class FakePubSubService : IPubSubService<IPersonRecord>
    {
        #region Implementation of IDisposable

        public void Dispose()
        {
            
        }

        #endregion

        #region Implementation of IPubSubService<IPersonRecord>

        public void Start()
        {
            
        }

        public void Stop()
        {
            
        }

        public event EventHandler<RecordAddEventArgs<IPersonRecord>> RecordAdded;
        public event EventHandler<RecordUpdateEventArgs<IPersonRecord>> RecordUpdated;
        public event EventHandler<RecordDeleteEventArgs> RecordDeleted;

        #endregion
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

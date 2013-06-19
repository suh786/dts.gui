using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using dts.gui.Models;
using dts.gui.RegistrationService;

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

    public abstract class SubscriptionManagerBase<TRecord, TCallBack> : DisposeableObject, ISubscriptionManager<TRecord> where TRecord : IPubSubRecord where TCallBack : IPubSubServiceCallback<TRecord>
    {
        private readonly string _id;
        private static readonly Uri _baseAddress = new Uri("http://localhost:3031/RegistrationService");
        private RegistrationServiceClient _dtsServiceClient;
        private TCallBack _callback;

        protected SubscriptionManagerBase(string id)
        {
            _id = id;
        }

        public bool Subscribe()
        {
            _callback = GetCallBack();
            _dtsServiceClient = InitializeService(_callback);

            AttachCallBackEventHandler();

            return OnSubscribe(_dtsServiceClient);
        }
        
        public bool Unsubscribe()
        {
            var result = OnSubscribe(_dtsServiceClient);
            _dtsServiceClient.Close();

            return result;
        }

        #region Update sending
        public event EventHandler<RecordAddedEventArgs<TRecord>> RecordAdded;
        public void RaiseRecordAdded(RecordAddedEventArgs<TRecord> e)
        {
            if (RecordAdded != null)
            {
                RecordAdded(this, e);
            }
        }

        public event EventHandler<RecordUpdatedEventArgs<TRecord>> RecordUpdated;
        public void RaiseRecordUpdated(RecordUpdatedEventArgs<TRecord> e)
        {
            if (RecordUpdated != null)
            {
                RecordUpdated(this, e);
            }
        }

        public event EventHandler<RecordDeletedEventArgs> RecordDeleted;
        public void RaisesRecordDeleted(RecordDeletedEventArgs e)
        {
            if (RecordDeleted != null)
            {
                RecordDeleted(this, e);
            }
        }
        #endregion

        protected abstract bool OnSubscribe(RegistrationServiceClient dtsServiceClient);
        protected abstract bool OnUnSubscribe(RegistrationServiceClient dtsServiceClient);
        protected abstract TCallBack GetCallBack();
        
        #region Callback Handling
        private void AttachCallBackEventHandler()
        {
            _callback.RecordAdded += HandleRecordAdded;
            _callback.RecordUpdated += HandleRecordUpdated;
            _callback.RecordDeleted += HandleRecordDeleted;
        }

        private void DettachCallBackEventHandler()
        {
            _callback.RecordAdded -= HandleRecordAdded;
            _callback.RecordUpdated -= HandleRecordUpdated;
            _callback.RecordDeleted -= HandleRecordDeleted;
        }

        private void HandleRecordDeleted(object sender, PubSubServiceRecordDeletedEventArgs e)
        {
            RaisesRecordDeleted(new RecordDeletedEventArgs(e.RecordId));
        }

        private void HandleRecordUpdated(object sender, PubSubServiceRecordUpdatedEventArgs<TRecord> e)
        {
            RaiseRecordUpdated(new RecordUpdatedEventArgs<TRecord>(e.Record));
        }

        private void HandleRecordAdded(object sender, PubSubServiceRecordAddedEventArgs<TRecord> e)
        {
            RaiseRecordAdded(new RecordAddedEventArgs<TRecord>(e.Record));
        }

        #endregion

        private RegistrationServiceClient InitializeService(TCallBack callBack)
        {
            var dtsServiceClient = new RegistrationServiceClient(new InstanceContext(null, callBack));
            var uniqueCallbackAddress = _baseAddress.AbsoluteUri;
            // make it unique - append a GUID
            uniqueCallbackAddress += _id;
            ((WSDualHttpBinding)_dtsServiceClient.Endpoint.Binding).ClientBaseAddress = new Uri(uniqueCallbackAddress);

            return dtsServiceClient;
        }

        protected override void DisposeInternal()
        {
            DettachCallBackEventHandler();

            base.DisposeInternal();
        }
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

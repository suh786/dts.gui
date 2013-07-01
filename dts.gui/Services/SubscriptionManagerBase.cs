using System;
using System.ComponentModel.Composition;
using System.ServiceModel;
using dts.gui.Commons;
using dts.gui.DtsServiceClients;

namespace dts.gui.Services
{
    public abstract class SubscriptionManagerBase<TRecord, TCallBack> : DisposeableObject, ISubscriptionManager<TRecord> where TRecord : IPubSubRecord where TCallBack : IPubSubServiceCallback<TRecord>
    {
        private IPubSubServiceClient _dtsServiceClient;
        private TCallBack _callback;

        [Import]
        private IPubSubServiceClientFactory _clientFactory;

        protected SubscriptionManagerBase()
        {
            SystemManager.InjectServices(this);
        }

        public bool Subscribe()
        {
            _callback = GetCallBack();
            _dtsServiceClient = GetServiceClient(_clientFactory, _callback);

            AttachCallBackEventHandler();

            return _dtsServiceClient.Subscribe();
        }
        
        public bool Unsubscribe()
        {
            return _dtsServiceClient.UnSubscribe();
        }

        #region Update sending
        public event EventHandler<RecordAddedEventArgs<TRecord>> RecordsAdded;
        public void RaiseRecordAdded(RecordAddedEventArgs<TRecord> e)
        {
            if (RecordsAdded != null)
            {
                RecordsAdded(this, e);
            }
        }

        public event EventHandler<RecordUpdatedEventArgs<TRecord>> RecordsUpdated;
        public void RaiseRecordUpdated(RecordUpdatedEventArgs<TRecord> e)
        {
            if (RecordsUpdated != null)
            {
                RecordsUpdated(this, e);
            }
        }

        public event EventHandler<RecordDeletedEventArgs> RecordsDeleted;
        public void RaisesRecordDeleted(RecordDeletedEventArgs e)
        {
            if (RecordsDeleted != null)
            {
                RecordsDeleted(this, e);
            }
        }
        #endregion

        protected abstract TCallBack GetCallBack();
        
        protected abstract IPubSubServiceClient GetServiceClient(IPubSubServiceClientFactory clientFactory, TCallBack callback);
        
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
            RaisesRecordDeleted(new RecordDeletedEventArgs(e.RecordIds));
        }

        private void HandleRecordUpdated(object sender, PubSubServiceRecordUpdatedEventArgs<TRecord> e)
        {
            RaiseRecordUpdated(new RecordUpdatedEventArgs<TRecord>(e.Records));
        }

        private void HandleRecordAdded(object sender, PubSubServiceRecordAddedEventArgs<TRecord> e)
        {
            RaiseRecordAdded(new RecordAddedEventArgs<TRecord>(e.Records));
        }

        #endregion
        
        protected override void DisposeInternal()
        {
            DettachCallBackEventHandler();

            _dtsServiceClient.Dispose();

            base.DisposeInternal();
        }
    }
}
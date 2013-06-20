using System;
using System.ServiceModel;
using dts.gui.DtsServiceClients;
using dts.gui.Models;
using dts.gui.RegistrationService;

namespace dts.gui.Services
{
    public abstract class SubscriptionManagerBase<TRecord, TCallBack> : DisposeableObject, ISubscriptionManager<TRecord> where TRecord : IPubSubRecord where TCallBack : IPubSubServiceCallback<TRecord>
    {
        private readonly string _id;
        private static readonly Uri _baseAddress = new Uri("http://localhost:3031/RegistrationService");
        private IPubSubServiceClient _dtsServiceClient;
        private TCallBack _callback;
        private readonly IPubSubServiceClientFactory _clientFactory;

        protected SubscriptionManagerBase(string id)
        {
            _id = id;
        }

        public bool Subscribe()
        {
            _callback = CreateCallBack();
            _dtsServiceClient = GetServiceClient(_clientFactory, _callback);

            AttachCallBackEventHandler();

            return _dtsServiceClient.Subscribe();
        }
        
        public bool Unsubscribe()
        {
            return _dtsServiceClient.UnSubscribe();
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

        private TCallBack CreateCallBack()
        {
            var callback = (TCallBack)Activator.CreateInstance(typeof (TCallBack));

            return callback;
        }

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
            /*var uniqueCallbackAddress = _baseAddress.AbsoluteUri;
            // make it unique - append a GUID
            uniqueCallbackAddress += _id;
            ((WSDualHttpBinding)_dtsServiceClient.Endpoint.Binding).ClientBaseAddress = new Uri(uniqueCallbackAddress);
*/
            return dtsServiceClient;
        }

        protected override void DisposeInternal()
        {
            DettachCallBackEventHandler();

            base.DisposeInternal();
        }
    }
}
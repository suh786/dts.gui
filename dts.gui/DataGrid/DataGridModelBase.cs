using System;
using System.ComponentModel.Composition;
using dts.gui.Models;
using dts.gui.Services;

namespace dts.gui.DataGrid
{
    public abstract class DataGridModelBase<TRowModel, TPubSubRecord> : DisposeableObject, IDataGridModel<TRowModel> where TPubSubRecord : IPubSubRecord where TRowModel : IDataGridRowModel
    {
        private ISubscriptionManager<TPubSubRecord> _subscriptionManager;

        protected DataGridModelBase()
        {
            SystemManager.InjectServices(this);
        }

        [Import]
        private IDtsService _dtsService;
        
        private void HandleRecordDeleted(object sender, RecordDeletedEventArgs e)
        {
            RaiseRowDeleted(new DataGridRowDeleteEventArgs(e.RecordId));
        }

        private void HandleRecordUpdated(object sender, RecordUpdatedEventArgs<TPubSubRecord> e)
        {
            RaiseRowUpdated(new DataGridRowUpdateEventArgs<TRowModel>(CreateRow(e.Record)));
        }

        protected abstract TRowModel CreateRow(TPubSubRecord record);

        private void HandleRecordAdded(object sender, RecordAddedEventArgs<TPubSubRecord> e)
        {
            RaiseRowAdded(new DataGridRowAddedEventArgs<TRowModel>(CreateRow(e.Record)));
        }
        
        public void Init()
        {
            _subscriptionManager = GetSubscriptionManager(_dtsService);
            AttachSubscriptionManagerHandlers();

            _subscriptionManager.Subscribe();
        }

        private void AttachSubscriptionManagerHandlers()
        {
            _subscriptionManager.RecordAdded += HandleRecordAdded;
            _subscriptionManager.RecordUpdated += HandleRecordUpdated;
            _subscriptionManager.RecordDeleted += HandleRecordDeleted;
        }

        private void DettachSubscriptionManagerHandlers()
        {
            if (_subscriptionManager != null)
            {
                _subscriptionManager.RecordAdded -= HandleRecordAdded;
                _subscriptionManager.RecordUpdated -= HandleRecordUpdated;
                _subscriptionManager.RecordDeleted -= HandleRecordDeleted;
            }
        }

        protected abstract ISubscriptionManager<TPubSubRecord> GetSubscriptionManager(IDtsService dtsService);

        public event EventHandler<DataGridRowAddedEventArgs<TRowModel>> RowAdded;
        public void RaiseRowAdded(DataGridRowAddedEventArgs<TRowModel> e)
        {
            if (RowAdded != null)
            {
                RowAdded(this, e);
            }
        }

        public event EventHandler<DataGridRowUpdateEventArgs<TRowModel>> RowUpdated;
        public void RaiseRowUpdated(DataGridRowUpdateEventArgs<TRowModel> e)
        {
            if (RowUpdated != null)
            {
                RowUpdated(this, e);
            }
        }

        public event EventHandler<DataGridRowDeleteEventArgs> RowDeleted;

        public void RaiseRowDeleted(DataGridRowDeleteEventArgs e)
        {
            if (RowDeleted != null)
            {
                RowDeleted(this, e);
            }
        }

        protected override void DisposeInternal()
        {
            _subscriptionManager.Unsubscribe();

            DettachSubscriptionManagerHandlers();
            
            base.DisposeInternal();
        }

    }
}
using System;
using System.ComponentModel.Composition;
using dts.gui.Commons;
using dts.gui.Services;
using System.Linq;

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
        
        private void HandleRecordsDeleted(object sender, RecordDeletedEventArgs e)
        {
            RaiseRowDeleted(new DataGridRowsDeleteEventArgs(e.RecordIds));
        }

        private void HandleRecordsUpdated(object sender, RecordUpdatedEventArgs<TPubSubRecord> e)
        {
            RaiseRowUpdated(new DataGridRowsUpdateEventArgs<TRowModel>(e.Records.Select(x => CreateRow(x))));
        }

        protected abstract TRowModel CreateRow(TPubSubRecord record);

        private void HandleRecordsAdded(object sender, RecordAddedEventArgs<TPubSubRecord> e)
        {
            RaiseRowAdded(new DataGridRowsAddedEventArgs<TRowModel>(e.Records.Select(x => CreateRow(x))));
        }
        
        public void Init()
        {
            _subscriptionManager = GetSubscriptionManager(_dtsService);
            AttachSubscriptionManagerHandlers();

            _subscriptionManager.Subscribe();
        }

        private void AttachSubscriptionManagerHandlers()
        {
            _subscriptionManager.RecordsAdded += HandleRecordsAdded;
            _subscriptionManager.RecordsUpdated += HandleRecordsUpdated;
            _subscriptionManager.RecordsDeleted += HandleRecordsDeleted;
        }

        private void DettachSubscriptionManagerHandlers()
        {
            if (_subscriptionManager != null)
            {
                _subscriptionManager.RecordsAdded -= HandleRecordsAdded;
                _subscriptionManager.RecordsUpdated -= HandleRecordsUpdated;
                _subscriptionManager.RecordsDeleted -= HandleRecordsDeleted;
            }
        }

        protected abstract ISubscriptionManager<TPubSubRecord> GetSubscriptionManager(IDtsService dtsService);

        public event EventHandler<DataGridRowsAddedEventArgs<TRowModel>> RowsAdded;
        public void RaiseRowAdded(DataGridRowsAddedEventArgs<TRowModel> e)
        {
            if (RowsAdded != null)
            {
                RowsAdded(this, e);
            }
        }

        public event EventHandler<DataGridRowsUpdateEventArgs<TRowModel>> RowsUpdated;
        public void RaiseRowUpdated(DataGridRowsUpdateEventArgs<TRowModel> e)
        {
            if (RowsUpdated != null)
            {
                RowsUpdated(this, e);
            }
        }

        public event EventHandler<DataGridRowsDeleteEventArgs> RowsDeleted;

        public void RaiseRowDeleted(DataGridRowsDeleteEventArgs e)
        {
            if (RowsDeleted != null)
            {
                RowsDeleted(this, e);
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
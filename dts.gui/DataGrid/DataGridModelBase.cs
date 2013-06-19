using System;
using dts.gui.Models;

namespace dts.gui.DataGrid
{
    public abstract class DataGridModelBase<TRowModel, TPubSubRecord> : DisposeableObject, IDataGridModel<TRowModel> where TPubSubRecord : IPubSubRecord where TRowModel : IDataGridRowModel
    {
        private readonly IPubSubService<TPubSubRecord> _dataService;

        protected DataGridModelBase(IPubSubService<TPubSubRecord> dataService)
        {
            _dataService = dataService;
            _dataService.RecordAdded += HandleRecordAdded;
            _dataService.RecordUpdated += HandleRecordUpdated;
            _dataService.RecordDeleted += HandleRecordDeleted;
        }

        private void HandleRecordDeleted(object sender, RecordDeleteEventArgs e)
        {
            RaiseRowDeleted(new DataGridRowDeleteEventArgs(e.RecordId));
        }

        private void HandleRecordUpdated(object sender, RecordUpdateEventArgs<TPubSubRecord> e)
        {
            RaiseRowUpdated(new DataGridRowUpdateEventArgs<TRowModel>(CreateRow(e.Record)));
        }

        protected abstract TRowModel CreateRow(TPubSubRecord record);

        private void HandleRecordAdded(object sender, RecordAddEventArgs<TPubSubRecord> e)
        {
            RaiseRowAdded(new DataGridRowAddedEventArgs<TRowModel>(CreateRow(e.Record)));
        }
        
        public void Init()
        {
            _dataService.Start(); 
        }

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
            _dataService.RecordAdded -= HandleRecordAdded;
            _dataService.RecordUpdated -= HandleRecordUpdated;
            _dataService.RecordDeleted -= HandleRecordDeleted;

            _dataService.Stop();

            base.DisposeInternal();
        }

    }
}
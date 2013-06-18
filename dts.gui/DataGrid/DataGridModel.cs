using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using dts.gui.Models;
using dts.gui.DataGrid;

namespace dts.gui.DataGrid
{
    public interface IDataGridViewModel : IInitializable
    {
        IEnumerable<IDataGridColumnDescriptor> ColumnDescriptors { get; }
    }

    public interface IDataGridModel<T> : IDisposable, IInitializable where T : IDataGridRowModel
    {
        IList<T> Items { get; }
    }

    public abstract class DataGridModelBase<TRowModel, TPubSubRecord> : DisposeableObject, IDataGridModel<TRowModel> where TPubSubRecord : IPubSubRecord where TRowModel : IDataGridRowModel
    {
        private IPubSubService<TPubSubRecord> _dataService;

        protected DataGridModelBase(IPubSubService<TPubSubRecord> dataService)
        {
            Items = new ObservableCollection<TRowModel>();
            _dataService = dataService;
            _dataService.RecordAdded += HandleRecordAdded;
            _dataService.RecordUpdated += HandleRecordUpdated;
            _dataService.RecordDeleted += HandleRecordDeleted;
        }

        private void HandleRecordDeleted(object sender, RecordDeleteEventArgs e)
        {
            Items.Remove(Items.Where(x => x.Id == e.RecordId).Single());
        }

        private void HandleRecordUpdated(object sender, RecordUpdateEventArgs<TPubSubRecord> e)
        {
            int index = Items.IndexOf(Items.Where(x => x.Id == e.Record.Id).Single());

            Items[index] = CreateRow(e.Record);
        }

        protected abstract TRowModel CreateRow(TPubSubRecord record);

        private void HandleRecordAdded(object sender, RecordAddEventArgs<TPubSubRecord> e)
        {
            Items.Add(CreateRow(e.Record));
        }

        public IList<TRowModel> Items { get; private set; }

        public void Init()
        {
           _dataService.Start(); 
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

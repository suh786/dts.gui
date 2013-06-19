using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using dts.gui.Models;

namespace dts.gui.DataGrid
{
    public abstract class DataGridViewModelBase<T> : NotifyingObject, IDataGridViewModel<T> where T : IDataGridRowModel
    {
        private readonly IDataGridModel<T> _dataGridModel;

        protected DataGridViewModelBase(IDataGridModel<T> dataGridModel)
        {
            _dataGridModel = dataGridModel;
            ColumnDescriptors = new List<IDataGridColumnDescriptor>();
            Items = new ObservableCollection<T>();
            _dataGridModel.RowAdded += DataGridModelOnRowAdded;
            _dataGridModel.RowUpdated += DataGridModelOnRowUpdated;
            _dataGridModel.RowDeleted += DataGridModelOnRowDeleted;
        }

        private void DataGridModelOnRowDeleted(object sender, DataGridRowDeleteEventArgs e)
        {
            int index = Items.IndexOf((T) Items.Select(x => x.Id == e.RowId));
            Items.RemoveAt(index);
        }

        private void DataGridModelOnRowUpdated(object sender, DataGridRowUpdateEventArgs<T> e)
        {
            int index = Items.IndexOf((T)Items.Select(x => x.Id == e.Row.Id));
            Items[index] = e.Row;
        }

        private void DataGridModelOnRowAdded(object sender, DataGridRowAddedEventArgs<T> e)
        {
            Items.Add(e.Row);
        }

        public List<IDataGridColumnDescriptor> ColumnDescriptors { get; private set; }

        public IList<T> Items { get; private set; }

        public void Init()
        {
            ColumnDescriptors.AddRange(GetColumnDescriptors());

            _dataGridModel.Init();
        }

        protected abstract IEnumerable<IDataGridColumnDescriptor> GetColumnDescriptors();

        protected override void DisposeInternal()
        {
            _dataGridModel.RowAdded -= DataGridModelOnRowAdded;
            _dataGridModel.RowUpdated -= DataGridModelOnRowUpdated;
            _dataGridModel.RowDeleted -= DataGridModelOnRowDeleted;
            _dataGridModel.Dispose();

            base.DisposeInternal();
        }
    }

}
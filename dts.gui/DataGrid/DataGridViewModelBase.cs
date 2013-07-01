using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using dts.gui.Commons;

namespace dts.gui.DataGrid
{
    public abstract class DataGridViewModelBase<T> : NotifyingObject, IDataGridViewModel<T> where T : IDataGridRowModel
    {
        private readonly IDataGridModel<T> _dataGridModel;

        protected DataGridViewModelBase(IDataGridModel<T> dataGridModel)
        {
            _dataGridModel = dataGridModel;
            ColumnDescriptors = new List<IDataGridColumnDescriptor>();
            Items = new AsyncObservableCollection<T>();
            _dataGridModel.RowsAdded += DataGridModelOnRowsAdded;
            _dataGridModel.RowsUpdated += DataGridModelOnRowsUpdated;
            _dataGridModel.RowsDeleted += DataGridModelOnRowsDeleted;
        }

        private void DataGridModelOnRowsDeleted(object sender, DataGridRowsDeleteEventArgs e)
        {
            /*int index = Items.IndexOf((T) Items.Select(x => x.Id == e.RowId));
            Items.RemoveAt(index);*/
        }

        private void DataGridModelOnRowsUpdated(object sender, DataGridRowsUpdateEventArgs<T> e)
        {
            /*int index = Items.IndexOf((T)Items.Select(x => x.Id == e.Rows.Id));
            Items[index] = e.Rows;*/
        }

        private void DataGridModelOnRowsAdded(object sender, DataGridRowsAddedEventArgs<T> e)
        {
            foreach (var row in e.Rows)
            {
                Items.Add(row);
            }
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
            _dataGridModel.RowsAdded -= DataGridModelOnRowsAdded;
            _dataGridModel.RowsUpdated -= DataGridModelOnRowsUpdated;
            _dataGridModel.RowsDeleted -= DataGridModelOnRowsDeleted;
            _dataGridModel.Dispose();

            base.DisposeInternal();
        }
    }

}
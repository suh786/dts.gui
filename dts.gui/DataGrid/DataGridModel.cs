using System;
using System.Text;
using dts.gui.Models;
using dts.gui.DataGrid;

namespace dts.gui.DataGrid
{
    public interface IDataGridModel<TRowModel> : IDisposable, IInitializable
        where TRowModel : IDataGridRowModel
    {
        event EventHandler<DataGridRowAddedEventArgs<TRowModel>> RowAdded;
        event EventHandler<DataGridRowUpdateEventArgs<TRowModel>> RowUpdated;
        event EventHandler<DataGridRowDeleteEventArgs> RowDeleted;
    }

    public class DataGridRowDeleteEventArgs : EventArgs
    {
        public DataGridRowDeleteEventArgs(string rowId)
        {
            RowId = rowId;
        }

        public string RowId { get; private set; }
    }

    public class DataGridRowUpdateEventArgs<T> : EventArgs
    {
        public DataGridRowUpdateEventArgs(T row)
        {
            Row = row;
        }

        public T Row { get; private set; }
    }

    public class DataGridRowAddedEventArgs<T> : EventArgs where T : IDataGridRowModel
    {
        public DataGridRowAddedEventArgs(T row)
        {
            Row = row;
        }

        public T Row { get; private set; }
    }
}

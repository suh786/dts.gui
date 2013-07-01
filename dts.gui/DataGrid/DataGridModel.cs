using System;
using System.Collections.Generic;
using System.Text;
using dts.gui.Commons;
using dts.gui.DataGrid;

namespace dts.gui.DataGrid
{
    public interface IDataGridModel<TRowModel> : IDisposable, IInitializable
        where TRowModel : IDataGridRowModel
    {
        event EventHandler<DataGridRowsAddedEventArgs<TRowModel>> RowsAdded;
        event EventHandler<DataGridRowsUpdateEventArgs<TRowModel>> RowsUpdated;
        event EventHandler<DataGridRowsDeleteEventArgs> RowsDeleted;
    }

    public class DataGridRowsDeleteEventArgs : EventArgs
    {
        public DataGridRowsDeleteEventArgs(IEnumerable<string> rowIds)
        {
            RowIds = rowIds;
        }

        public IEnumerable<string> RowIds { get; private set; }
    }

    public class DataGridRowsUpdateEventArgs<T> : EventArgs
    {
        public DataGridRowsUpdateEventArgs(IEnumerable<T> rows)
        {
            Rows = rows;
        }

        public IEnumerable<T> Rows { get; private set; }
    }

    public class DataGridRowsAddedEventArgs<T> : EventArgs where T : IDataGridRowModel
    {
        public DataGridRowsAddedEventArgs(IEnumerable<T> rows)
        {
            Rows = rows;
        }

        public IEnumerable<T> Rows { get; private set; }
    }
}

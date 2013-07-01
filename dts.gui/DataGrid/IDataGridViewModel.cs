using System.Collections.Generic;
using dts.gui.Commons;

namespace dts.gui.DataGrid
{
    public interface IDataGridViewModel : IInitializable
    {
        List<IDataGridColumnDescriptor> ColumnDescriptors { get; }
    }

    public interface IDataGridViewModel<T> : IDataGridViewModel where T : IDataGridRowModel
    {
        IList<T> Items { get; }
    }
}
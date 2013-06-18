using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dts.gui.DataGrid
{
    public interface IDataGridColumnDescriptor
    {
        string Name { get; }
        string PropertyName { get; }
        string Header { get; }
        bool IsReadOnly { get; }
    }

    public abstract class DataGridColumnDescriptorBase : IDataGridColumnDescriptor
    {
        protected DataGridColumnDescriptorBase(string name, string propertyName, string header, bool isReadOnly = false)
        {
            Name = name;
            PropertyName = propertyName;
            Header = header;
            IsReadOnly = isReadOnly;
        }

        #region IDataGridColumnDescriptor Members

        public string Name { get; private set; }
        public string PropertyName { get; private set; }
        public string Header { get; private set; }
        public bool IsReadOnly { get; private set; }
        #endregion
    }
}

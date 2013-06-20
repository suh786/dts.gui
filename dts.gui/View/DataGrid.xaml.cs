using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dts.gui.DataGrid;

namespace dts.gui.View
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : ViewBase
    {
        public DataGrid()
        {
            InitializeComponent();
        }

        public IDataGridViewModel DataGridViewModel { get { return (IDataGridViewModel) DataContext; } }

        public override void Init()
        {
            base.Init();
            
           // GenerateColumns();
        }

        private void GenerateColumns()
        {
            foreach (var descriptor in DataGridViewModel.ColumnDescriptors)
            {
                var column = CreateDataGridColumn(descriptor);

                dataGrid.Columns.Add(column);
            }
        }

        private DataGridBoundColumn CreateDataGridColumn(IDataGridColumnDescriptor descriptor)
        {
            var dataGridBoundColumn = CreateDataGridBoundColumn(descriptor);

            dataGridBoundColumn.Width = double.IsNaN(descriptor.Width)
                                            ? DataGridLength.SizeToHeader
                                            : new DataGridLength(descriptor.Width);
            dataGridBoundColumn.IsReadOnly = descriptor.IsReadOnly;

            dataGridBoundColumn.Header = descriptor.Header;

            var binding = new Binding(descriptor.PropertyName);

            dataGridBoundColumn.Binding = binding;

            return dataGridBoundColumn;
        }

        private DataGridBoundColumn CreateDataGridBoundColumn(IDataGridColumnDescriptor descriptor)
        {
            DataGridBoundColumn column = null;
            
            if(descriptor is DataGridDisplayOnlyColumnDescriptor)
            {
                column = new DataGridTextColumn();
            }

            return column;
        }
    }

}

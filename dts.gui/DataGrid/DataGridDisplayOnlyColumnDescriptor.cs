namespace dts.gui.DataGrid
{
    public class DataGridDisplayOnlyColumnDescriptor : DataGridColumnDescriptorBase
    {
        public DataGridDisplayOnlyColumnDescriptor(string name, string propertyName, string header, double width = double.NaN) : base(name, propertyName, header, width, true)
        {
        }
    }
}
using dts.gui.DataGrid;
using dts.gui.Models;

namespace dts.gui.Person
{
    public class PersonDataGridModel : DataGridModelBase<IPersonRowModel, IPersonRecord>
    {
        public PersonDataGridModel() : base(new FakePubSubService())
        {
        }

        protected override IPersonRowModel CreateRow(IPersonRecord record)
        {
            return new PersonRowModel(record);
        }
    }
}

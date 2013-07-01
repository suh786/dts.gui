using dts.gui.DataGrid;
using dts.gui.Services;

namespace dts.gui.Person
{
    public class PersonDataGridModel : DataGridModelBase<IPersonRowModel, IPersonRecord>
    {
        protected override IPersonRowModel CreateRow(IPersonRecord record)
        {
            return new PersonRowModel(record);
        }

        protected override ISubscriptionManager<IPersonRecord> GetSubscriptionManager(IDtsService dtsService)
        {
            return dtsService.PersonSubscriptionManager;
        }
    }
}

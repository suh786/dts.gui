
using System.Collections.Generic;
using dts.gui.DataGrid;

namespace dts.gui.Person
{

    public class PersonDataGridViewModel : DataGridViewModelBase<IPersonRowModel> 
    {
        public PersonDataGridViewModel() : base(new PersonDataGridModel())
        {
        }

        protected override IEnumerable<IDataGridColumnDescriptor> GetColumnDescriptors()
        {
            return new IDataGridColumnDescriptor[]
                       {
                           new DataGridDisplayOnlyColumnDescriptor("Id", "Id", "Id", 20), 
                           new DataGridDisplayOnlyColumnDescriptor("FirstName", "FirstName", "First Name", 100), 
                           new DataGridDisplayOnlyColumnDescriptor("MiddleName", "MiddleName", "Middle Name", 100),
                           new DataGridDisplayOnlyColumnDescriptor("LastName", "LastName", "Last Name", 100), 
                           new DataGridDisplayOnlyColumnDescriptor("Address", "Address", "Address", 150), 
                           new DataGridDisplayOnlyColumnDescriptor("Age", "Age", "Age", 40),
                           new DataGridDisplayOnlyColumnDescriptor("FatherName", "FatherName", "Father's Name", 150),
                           new DataGridDisplayOnlyColumnDescriptor("MotherName", "MotherName", "Mother's Name", 150),
                           new DataGridDisplayOnlyColumnDescriptor("OfficeName", "OfficeName", "Office", 100),
                           new DataGridDisplayOnlyColumnDescriptor("OfficeAddress", "OfficeAddress", "Office Address", 100)
                       };
        }
    }
}

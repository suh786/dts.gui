
using System.ComponentModel;
using dts.gui.DataGrid;

namespace dts.gui.Person
{
    public interface IPersonRowModel : IDataGridRowModel, IPerson
    {
    }

    public class PersonRowModel : DataGridRowModelBase, IPersonRowModel
    {
        public PersonRowModel(IPersonRecord personRecord) : base(personRecord)
        {
            FirstName = personRecord.FirstName;
            MiddleName = personRecord.MiddleName;
            LastName = personRecord.LastName;
            Address = personRecord.Address;
            Age = personRecord.Age;
            FatherName = personRecord.FatherName;
            MotherName = personRecord.MotherName;
            OfficeName = personRecord.OfficeName;
            OfficeAddress = personRecord.OfficeAddress;
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if(Equals(_firstName, value)) return;

                _firstName = value;

                NotifyPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (Equals(_lastName, value)) return;

                _lastName = value;

                NotifyPropertyChanged("LastName");
            }
        }

        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (Equals(_middleName, value)) return;

                _middleName = value;

                NotifyPropertyChanged("MiddleName");
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (Equals(_address, value)) return;

                _address = value;

                NotifyPropertyChanged("Address");
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (Equals(_age, value)) return;

                _age = value;

                NotifyPropertyChanged("Age");
            }
        }

        private string _fatherName;
        public string FatherName
        {
            get { return _fatherName; }
            set
            {
                if (Equals(_fatherName, value)) return;

                _fatherName = value;

                NotifyPropertyChanged("FatherName");
            }
        }

        private string _motherName;
        public string MotherName
        {
            get { return _motherName; }
            set
            {
                if (Equals(_motherName, value)) return;

                _motherName = value;

                NotifyPropertyChanged("MotherName");
            }
        }

        private string _officeName;
        public string OfficeName
        {
            get { return _officeName; }
            set
            {
                if (Equals(_officeName, value)) return;

                _officeName = value;

                NotifyPropertyChanged("OfficeName");
            }
        }

        private string _officeAddress;
        public string OfficeAddress
        {
            get { return _officeAddress; }
            set
            {
                if (Equals(_officeAddress, value)) return;

                _officeAddress = value;

                NotifyPropertyChanged("OfficeAddress");
            }
        }
    }
}

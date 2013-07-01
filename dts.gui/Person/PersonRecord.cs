using dts.gui.Commons;

namespace dts.gui.Person
{
    public interface IPersonRecord : IPubSubRecord, IPerson
    {
    }

    public class PersonRecord : IPersonRecord
    {
        public PersonRecord()
        {
            
        }

        public PersonRecord(PersonSubscriptionService.Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            MiddleName = person.MiddleName;
            LastName = person.LastName;
            Address = person.Address;
            Age = person.Age;
            FatherName = person.FatherName;
            MotherName = person.MotherName;
            OfficeName = person.OfficeName;
            OfficeAddress = person.OfficeAddress;
        }

        public string Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string OfficeName { get; set; }
        public string OfficeAddress { get; set; }
    }
}

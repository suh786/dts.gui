
using dts.gui.Models;

namespace dts.gui.Person
{
    public interface IPerson : IIdentifiable
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        string Address { get; set; }
        int Age { get; set; }
        string FatherName { get; set; }
        string MotherName { get; set; }
        string OfficeName { get; set; }
        string OfficeAddress { get; set; }
    }
}

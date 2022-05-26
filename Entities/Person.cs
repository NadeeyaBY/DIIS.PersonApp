using System.ComponentModel.DataAnnotations;

namespace DIIS.PersonApp.Entities
{
    public class Person
    {
        [Required (ErrorMessage ="กรุณาระบุ")]
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

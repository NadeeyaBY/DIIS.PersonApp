using System;
using System.Collections.Generic;

#nullable disable

namespace DIIS.PersonApp.Entities
{
    public partial class DevSample
    {
        public decimal Id { get; set; }
        public string CustFirstName { get; set; }
        public string CustLastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

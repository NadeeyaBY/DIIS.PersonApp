using System;
using System.Collections.Generic;

#nullable disable

namespace DIIS.PersonApp.Entities
{
    public partial class DevLoanType
    {
        public byte? LoanParentId { get; set; }
        public string LoanParentName { get; set; }
        public byte LoanTypeId { get; set; }
        public string LoanTypeName { get; set; }
        public decimal? LoanMaxAmount { get; set; }
        public decimal? LoanInterate { get; set; }
        public byte? LoanPeriod { get; set; }
        public bool? Active { get; set; }
        public string Remark { get; set; }
    }
}

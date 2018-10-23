using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoStaff.Models.Contract
{
    public class ContractEdit
    {
        public int ContractId { get; set; }
        public int DeveloperId { get; set; }
        public int TeamId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

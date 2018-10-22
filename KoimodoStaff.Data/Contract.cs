using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoimodoStaff.Data
{
   
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        public int DeveloperId{ get; set; }
        public int TeamId { get; }
        public DateTime StartDate { get; set; }
        public DateTime dateTime { get; set; }
    }
}

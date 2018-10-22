using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoimodoStaff.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
    }
}

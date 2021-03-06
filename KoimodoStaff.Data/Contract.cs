﻿using System;
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
        public int TeamId { get; set; }
        public virtual Developer Developer { get; set;}
        public virtual Team Team { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

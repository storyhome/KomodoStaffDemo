﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KomodoStaff.Models
{
   public class TeamCreate
    {
        [Required]
        public int TeamId { get; set; }
        public string Name { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
    public class GeographicZone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public String Name { get; set; }
        public Guid Father { get; set; }
        public List<Contract> Contracts { get; set; }

        public override string ToString()
        {
            string s = Name+" "+Father;
            return s;
            
        }
    }
}

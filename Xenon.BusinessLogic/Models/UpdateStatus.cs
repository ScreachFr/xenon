﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.BusinessLogic.Models
{
    public class UpdateStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public int State { get; set; }
        public string Path { get; set; }
        public DateTime SubmitTimeStamp { get; set; }
        public DateTime AnswerTimeStamp { get; set; }
    }
}

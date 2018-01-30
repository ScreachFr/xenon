using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Xenon.BusinessLogic.Models
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }
        [Range(0.01, 100.00, ErrorMessage = "Cover must be between 0.01 and 100.00")]
        public double Cover { get; set; }
        public bool Negociable { get; set; } = false;
        public int Prime { get; set; } = 0;
        public bool Rompu { get; set; } = false;
        public string Company { get; set; }
        public Guid Wallet { get; set; }
        public int Value { get; set; }
        public int Position { get; set; }


        public void Update(Contract newValue)
        {
            this.Start = newValue.Start;
            this.End = newValue.End;
            this.Cover = newValue.Cover;
            this.Negociable = newValue.Negociable;
            this.Prime = newValue.Prime;
            this.Rompu = newValue.Rompu;
            this.Company = newValue.Company;
            this.Wallet = newValue.Wallet;
            this.Value = newValue.Value;
            this.Position = newValue.Position;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
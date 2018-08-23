using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Models
{
    public class YarnCreate
    {
        [Required]
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public int TotalYardage { get; set; }
        public int TotalWeight { get; set; }
        public string Fiber { get; set; }
        public string WherePurchased { get; set; }



        public override string ToString() => Color;

    }
}

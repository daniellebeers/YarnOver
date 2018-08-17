using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Data
{
    public class Yarn
    {
        [Key]
        public int YarnId { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public int TotalYardage { get; set; }

        [Required]
        public int TotalWeight { get; set; }

        [Required]
        public string Fiber { get; set; }
        
        [Required]
        public string WherePurchased { get; set; }

        public string YarnType { get; set; }
    }
}

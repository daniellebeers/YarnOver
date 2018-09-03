using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Models
{
    public class YarnDetail
    {
        public int YarnId { get; set; }
        public string Color { get; set; }
        public Guid UserId { get; set; }
        public string Manufacturer { get; set; }
        public int TotalYardage { get; set; }
        public int TotalWeight { get; set; }
        public string Fiber { get; set; }
        public string WherePurchased { get; set; }

        public override string ToString() => $"[{YarnId}] {Color}";
    }
}

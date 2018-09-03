using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Models
{
    public class HookListItem
    {
        public int HookId { get; set; }
        public int NumberSize { get; set; }
        public string LetterSize { get; set; }
        public string Material { get; set; }

        [Display(Name = "Created")]

        public override string ToString() => $"[{HookId}] {NumberSize}";
    }
}

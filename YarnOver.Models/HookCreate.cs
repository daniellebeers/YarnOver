using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Models
{
    public class HookCreate
    {
        [Required]
        public int HookId { get; set; }
        public int NumberSize { get; set; }
        public string LetterSize { get; set; }
        public string Material { get; set; }

        [MaxLength(8000)]
        public string Content { get; set; }

        public override string ToString() => LetterSize;

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Data
{
    public class Hook
    {
        [Key]
        public int HookId { get; set; }

        public int NumberSize { get; set; }

        public string LetterSize { get; set; }

        [Required]
        public string Material { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Models
{
    public class HookEdit
    {
        public int HookId { get; set; }
        public Guid UserId { get; set; }
        public int NumberSize { get; set; }
        public string LetterSize { get; set; }
        public string Material { get; set; }
    }
}

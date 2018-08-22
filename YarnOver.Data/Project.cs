using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string PatternLocation { get; set; }

        [Required]
        public string ProjectYarn { get; set; }
        
    }
}

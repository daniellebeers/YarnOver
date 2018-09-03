using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnOver.Models
{
    public class ProjectCreate
    {
      //  public int ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string ProjectName { get; set; }
        public string PatternLocation { get; set; }
        public string ProjectYarn { get; set; }

        public override string ToString() => ProjectName;
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YarnOver.Models;

namespace YarnOver.Contracts
{
    public interface IYarnService
    {
        bool CreateYarn(YarnCreate model);

        IEnumerable<YarnListItem> GetYarns();

        YarnDetail GetYarnById(int yarnId);

        bool UpdateYarn(YarnEdit model);

         bool DeleteYarn(int yarnId);
    }
}

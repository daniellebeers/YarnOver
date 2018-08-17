using YarnOver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YarnOver.Data;
using YarnOver.Models;

namespace YarnOver.Services
{
    public class HookService
    {
        private readonly Guid _userId;

        public HookService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHook(HookCreate model)
        {
            var entity =
                new Hook()
                {
                    HookId = model.HookId,
                    NumberSize = model.NumberSize,
                    LetterSize = model.LetterSize,
                    Material = model.Material
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Hooks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

            public IEnumerable<HookListItem> GetHooks()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Hooks
                            .Where(e => e.UserId == _userId)
                            .Select(
                                e =>
                                    new HookListItem
                                    {
                                        HookId = e.HookId,
                                        NumberSize = e.NumberSize,
                                        LetterSize = e.LetterSize,
                                        Material = e.Material
                                    }
                            );

                    return query.ToArray();
                }
            }
        

    }
}
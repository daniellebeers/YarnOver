using YarnOver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    //HookId = model.HookId,
                    NumberSize = model.NumberSize,
                    LetterSize = model.LetterSize,
                    Material = model.Material,
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


        public HookDetail GetHookById(int hookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Hooks
                        .Single(e => e.HookId == hookId && e.UserId == _userId);
                return
                    new HookDetail
                    {
                        //HookId = entity.HookId,
                        NumberSize = entity.NumberSize,
                        LetterSize = entity.LetterSize,
                        Material = entity.Material,

                    };
            }
        }
        public bool UpdateHook(HookEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Hooks
                        .Single(e => e.HookId == model.HookId && e.UserId == _userId);

                entity.HookId = model.HookId;
                entity.NumberSize = model.NumberSize;
                entity.LetterSize = model.LetterSize;
                entity.Material = model.Material;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHook(int hookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Hooks
                        .Single(e => e.HookId == hookId && e.UserId == _userId);

                ctx.Hooks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}


    
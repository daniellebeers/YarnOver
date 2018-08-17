using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YarnOver.Data;
using YarnOver.Models;

namespace YarnOver.Services
{
    public class YarnService
    {
        private readonly Guid _userId;

        public YarnService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateYarn(YarnCreate model)
        {
            var entity =
                new Yarn()
                {
                    UserId = _userId,
                    Color = model.Color,
                    Manufacturer = model.Manufacturer,
                    TotalYardage = model.TotalYardage,
                    TotalWeight = model.TotalWeight,
                    WherePurchased = model.WherePurchased,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Yarns.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<YarnListItem> GetYarns()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Yarns
                        .Where(e => e.UserId == _userId)
                        .Select(
                         e =>
                             new YarnListItem
                             {
                                 YarnId = e.YarnId,
                                 Color = e.Color,
                                 Manufacturer = e.Manufacturer,
                                 TotalYardage = e.TotalYardage,
                                 TotalWeight = e.TotalWeight,
                                 Fiber = e.Fiber,
                                 WherePurchased = e.WherePurchased
                             }
                         );

                return query.ToArray();
            }
        }

        public YarnDetail GetYarnById(int yarnId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Yarns
                        .Single(e => e.YarnId == yarnId && e.UserId == _userId);
                return
                    new YarnDetail
                    {
                        UserId = _userId,
                        YarnId = entity.YarnId,
                        Color = entity.Color,
                        TotalYardage = entity.TotalYardage,
                        TotalWeight = entity.TotalWeight,
                        Fiber = entity.Fiber,
                        WherePurchased = entity.WherePurchased
                    };
            }
        }

        public bool UpdateYarn(YarnEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
            var entity =
                        ctx
                            .Yarns
                            .Single(e => e.YarnId == model.YarnId && e.UserId == _userId);

            entity.UserId = model.UserId;
            entity.YarnId = model.YarnId;
            entity.Color = model.Color;
            entity.TotalYardage = model.TotalYardage;
            entity.TotalWeight = model.TotalWeight;
            entity.WherePurchased = model.WherePurchased;

            return ctx.SaveChanges() == 1;
            }
        }

            public bool DeleteYarn(int yarnId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Yarns
                            .Single(e => e.YarnId == yarnId && e.UserId == _userId);

                    ctx.Yarns.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }


            }
        }

    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YarnOver.Data;
using YarnOver.Models;

namespace YarnOver.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }


        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    UserId = _userId,
                    ProjectId = model.ProjectId,
                    ProjectName = model.ProjectName,
                    PatternLocation = model.PatternLocation,
                    ProjectYarn = model.ProjectYarn,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Projects
                        .Where(e => e.UserId == _userId)
                        .Select(
                         e =>
                             new ProjectListItem
                             {
                                ProjectId = e.ProjectId,
                                 ProjectName = e.ProjectName,
                                 PatternLocation = e.PatternLocation,
                                 ProjectYarn = e.ProjectYarn,
                             }
                         );

                return query.ToArray();
            }
        }

        public ProjectDetail GetProjectById(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == projectId && e.UserId == _userId);
                return
                    new ProjectDetail
                    {
                        UserId = _userId,
                        ProjectId = entity.ProjectId,
                        ProjectName = entity.ProjectName,
                        PatternLocation = entity.PatternLocation,
                        ProjectYarn = entity.ProjectYarn,
                    };
            }
        }

 

        public bool UpdateProject(ProjectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == model.ProjectId && e.UserId == _userId);

                        entity.UserId = _userId;
                        entity.ProjectId = model.ProjectId;
                        entity.ProjectName = model.ProjectName;
                        entity.PatternLocation = model.PatternLocation;
                        entity.ProjectYarn = model.ProjectYarn;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProject(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == noteId && e.UserId == _userId);

                ctx.Projects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }

}
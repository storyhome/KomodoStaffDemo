using KoimodoStaff.Data;
using KomodoStaff.Data;
using KomodoStaff.Models;
using KomodoStaff.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoStaff.Services
{
    public class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userID)
        {
            _userId = userID;
        }

        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                 new Team()
                 {
                     Name = model.Name
                 };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                      .Teams
                      .Select(
                        e =>
                            new TeamListItem
                            {
                                TeamId = e.TeamId,
                                Name = e.Name
                            }
                       );
                return query.ToArray();
            }
        }

        public TeamDetail GetTeamById(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .Teams
                      .Single(e => e.TeamId == teamId);
                return
                   new TeamDetail
                   {
                       TeamId = entity.TeamId,
                       Name = entity.Name
                   };
            }
        }

        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx
                      .Teams
                      .Single(e => e.TeamId == model.TeamId);
                entity.Name = model.Name;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .Teams
                      .Single(e => e.TeamId == teamId);
                ctx.Teams.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

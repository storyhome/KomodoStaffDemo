using KoimodoStaff.Data;
using KomodoStaff.Data;
using KomodoStaff.Models;
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

    }
}

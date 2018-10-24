using KomodoStaff.Contracts;
using KomodoStaff.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoStaff.Services.MockServices
{
   public class MockTeamService : ITeamService
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateTeam(TeamCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

        public bool DeleteTeam(int teamId)
        {
            CallCount++;
            return ReturnValue;
        }

        public TeamDetail GetTeamById(int teamId)
        {
            CallCount++;
            return new TeamDetail { TeamId = teamId };
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            CallCount++;
            var @return = new List<TeamListItem>
            {
                new TeamListItem {TeamId = 1}
            };

            return @return;
        }

        public bool UpdateTeam(TeamEdit model)
        {
            return ReturnValue;
        }
    }
}

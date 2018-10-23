using System.Collections.Generic;
using KomodoStaff.Models.Team;

namespace KomodoStaff.Contracts
{
    public interface ITeamService
    {
        bool CreateTeam(TeamCreate model);
        bool DeleteTeam(int teamId);
        TeamDetail GetTeamById(int teamId);
        IEnumerable<TeamListItem> GetTeams();
        bool UpdateTeam(TeamEdit model);
    }
}
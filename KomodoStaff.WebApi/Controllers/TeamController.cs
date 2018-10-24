using KomodoStaff.Models;
using KomodoStaff.Models.Team;
using KomodoStaff.Contracts;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KomodoStaff.WebApi.Controllers
{
    public class TeamController : ApiController
    {
        private ITeamService _teamService;

        public TeamController() { }
        public TeamController(ITeamService mockService)
        {
            _teamService = mockService;
        }

        public IHttpActionResult GetAll()
        {
            var teams = _teamService.GetTeams();
            return Ok(teams);
        }

        public IHttpActionResult Get(int id)
        {
            PopulateTeamService();

            var team = _teamService.GetTeamById(id);
            return Ok(team);
        }

        public IHttpActionResult Post(TeamCreate team)
        {
            PopulateTeamService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teamService.CreateTeam(team))
                return InternalServerError();
            return Ok();

        }

        public IHttpActionResult Put(TeamEdit team)
        { 
            PopulateTeamService();
       
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           

            if (!_teamService.UpdateTeam(team))
                return InternalServerError();

            return Ok();
        }


        public IHttpActionResult Delete(int id)
        {
            PopulateTeamService();
                        
            if (!_teamService.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }
        private void PopulateTeamService()
        {
            if (_teamService == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                _teamService = new TeamService(userId);
            }
        }
    }
}

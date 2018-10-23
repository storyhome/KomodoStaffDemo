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
        public IHttpActionResult GetAll()
        {
            TeamService teamService = CreateTeamService();
            var teams = teamService.GetTeams();
            return Ok(teams);
        }
        
        public IHttpActionResult Get(int id)
        {
            TeamService teamservice = CreateTeamService();
            var team = teamservice.GetTeamById(id);
            return Ok(team);
        }
                 

         public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.CreateTeam(team))
                return InternalServerError();
            return Ok();

        }

        public IHttpActionResult Put(TeamEdit team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTeamService();

            if (!service.UpdateTeam(team))
               return InternalServerError();

            return Ok();
        }


        public IHttpActionResult Delete(int id)
        {
            var service = CreateTeamService();

            if (!service.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }
        private TeamService CreateTeamService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teamService = new TeamService(userId);
            return teamService;
        }
        }
    }

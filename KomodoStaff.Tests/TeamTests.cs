using KomodoStaff.Models.Team;
using KomodoStaff.Services.MockServices;
using KomodoStaff.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace KomodoStaff.Tests
{
    [TestClass]
    public class TeamTests
    {
        private TeamController _controller;
        private MockTeamService _mockService;


        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockTeamService { ReturnValue = true };
            _controller = new TeamController(_mockService);

        }

        [TestMethod]
        public void TeamController_PostTeam_ShouldReturnOk()
        {
            var team = new TeamCreate { };
            var result = _controller.Post(team);
            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void TeamController_DeleteTeam_ShouldReturnCorrectInt()
        {
            _mockService.CallCount = 1;
            var result = _controller.Delete(1);

            Assert.AreEqual(2, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void TeamController_GetAll_CountShouldBeCorrectInt()
        {
            var result = _controller.GetAll();
            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<TeamListItem>>));
        }

        [TestMethod]
        public void TesttController_GetByID_CountShouldBeCorrectInt()
        {
            var result = _controller.Get(1);
            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<TeamDetail>));
        }
    }
}

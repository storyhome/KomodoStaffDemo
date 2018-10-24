using KomodoStaff.Models.Contract;
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
    public class ContractController : ApiController
    {
        private IContractService _contractService;

        public ContractController() { }
      
        public ContractController(IContractService mockService)
        {
            _contractService = mockService;
        }
        public IHttpActionResult GetAll()
        {
            
            var contracts = _contractService.GetContracts();
            return Ok(contracts);
        }

        public IHttpActionResult Get(int id)
        {
            PopulateContractService();
           
            var contract = _contractService.GetContractById(id);
            return Ok(contract);
        }


        public IHttpActionResult Post(ContractCreate contract)
        {
            PopulateContractService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_contractService.CreateContract(contract))
                return InternalServerError();
            return Ok();

        }

        public IHttpActionResult Put(ContractEdit contract)
        {
            PopulateContractService();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_contractService.UpdateContract(contract))
                return InternalServerError();

            return Ok();
        }


        public IHttpActionResult Delete(int id)
        {
            PopulateContractService();
           
            if (!_contractService.DeleteContract(id))
                return InternalServerError();

            return Ok();
        }

        private void PopulateContractService()
        {
            if (_contractService == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                _contractService = new ContractService(userId);
            }
        }
    }
}

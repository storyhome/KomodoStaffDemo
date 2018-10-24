﻿
using KomodoStaff.Contracts;
using KomodoStaff.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoStaff.Services.MockServices
{
    public class MockContractService : IContractService
    {
        public bool ReturnValue { get; set; }
        public int CallCount { get; set; }

        public bool CreateContract(ContractCreate model)
        {
            CallCount++;
            return ReturnValue;
        }

       
        public bool DeleteContract(int id)
        {
            CallCount--;
            return ReturnValue;
        }

        public ContractDetail GetContractById(int id)
        {
            CallCount++;
            return new ContractDetail { ContractId = id };
        }

        public IEnumerable<ContractListItem> GetContracts()
        {
            CallCount++;
            var @return = new List<ContractListItem>
            {
                new ContractListItem {ContractId = 1}
            };
            return @return;

        }

        public bool UpdateContract(ContractEdit model)
        {
            return ReturnValue;
        }
    }
}

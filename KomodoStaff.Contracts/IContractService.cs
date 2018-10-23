using System.Collections.Generic;
using KomodoStaff.Models.Contract;

namespace KomodoStaff.Contracts
{
    public interface IContractService
    {
        bool CreateContract(ContractCreate model);
        bool DeleteContract(int contractId);
        ContractDetail GetContractById(int contractId);
        IEnumerable<ContractListItem> GetContracts();
        bool UpdateContract(ContractEdit model);
    }
}
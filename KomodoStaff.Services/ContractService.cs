using KoimodoStaff.Data;
using KomodoStaff.Data;
using KomodoStaff.Models.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoStaff.Services
{
    public class ContractService
    {
        private Guid userId;

        public ContractService(Guid userId)
        {
            this.userId = userId;
        }

        public IEnumerable<ContractListItem> GetContracts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                      .Contracts
                      .Select(
                        e =>
                            new ContractListItem
                            {
                                ContractId = e.ContractId,
                                DeveloperId = e.DeveloperId,
                                TeamId = e.TeamId,
                                StartDate = e.StartDate,
                                EndDate = e.EndDate,
                            }
                       );
                return query.ToArray();
            }
        }

        public ContractDetail GetContractById(int contractId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .Contracts
                      .Single(e => e.ContractId == contractId);
                return
                   new ContractDetail()
                   {

                       ContractId = entity.ContractId,
                       DeveloperId = entity.DeveloperId,
                       TeamId = entity.TeamId,
                       EndDate = entity.EndDate,
                       StartDate = entity.StartDate,
                       Name = entity.Team.Name,
                       FirstName = entity.Developer.FirstName,
                       LastName = entity.Developer.LastName
                   };
            }


        }

        public bool UpdateContract(ContractEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx
                      .Contracts
                      .Single(e => e.ContractId == model.ContractId);

                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.DeveloperId = model.DeveloperId;
                entity.TeamId = model.TeamId;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateContract(ContractCreate model)
        {
            var entity =
                    new Contract()
                    {
                        
                        DeveloperId = model.DeveloperId,
                        TeamId = model.TeamId,
                        EndDate = model.EndDate,
                        StartDate = model.StartDate
                    };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contracts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteContract(int contractId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .Contracts
                      .Single(e => e.ContractId == contractId);
                ctx.Contracts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
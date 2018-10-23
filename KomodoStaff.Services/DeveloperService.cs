using KoimodoStaff.Data;
using KomodoStaff.Data;
using KomodoStaff.Models.Developer;
using KomodoStaff.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoStaff.Services
{
   public class DeveloperService
    {
        private readonly Guid _userId;

        public DeveloperService(Guid userID)
        {
            _userId = userID;
        }

        public bool CreateDeveloper(DeveloperCreate model)
        {
            var entity =
                 new Developer()
                 {
                     FirstName = model.FirstName,
                     MI = model.MI,
                     LastName = model.LastName,
                     Address = model.Address,
                     City = model.City,
                     State = model.State,
                     Zip = model.Zip,
                     Cell = model.Cell,
                     SocialMedia = model.SocialMedia
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Developers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DeveloperListItem> GetDevelopers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                      .Developers
                      .Select(
                        e =>
                            new DeveloperListItem
                            {
                                DeveloperId = e.DeveloperId,
                                FirstName = e.FirstName,
                                MI = e.MI,
                                LastName = e.LastName,
                                Address = e.Address,
                                City = e.City,
                                State = e.State,
                                Zip = e.Zip,
                                Cell = e.Cell,
                                SocialMedia = e.SocialMedia
                            }
                       );
                return query.ToArray();
            }
        }

        public DeveloperDetail GetDeveloperById(int developerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .Developers
                      .Single(e => e.DeveloperId == developerId);
                return
                   new DeveloperDetail
                   {
                       DeveloperId = entity.DeveloperId,
                       FirstName = entity.FirstName,
                       LastName = entity.LastName,
                       MI = entity.MI,
                       Address = entity.Address,
                       Cell= entity.Cell,
                       State = entity.State,
                       City = entity.City,
                       Zip = entity.Zip,
                       SocialMedia = entity.SocialMedia
                    };
            }
        }

        
        public bool UpdateDeveloper(DeveloperEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx
                      .Developers
                      .Single(e => e.DeveloperId == model.DeveloperId);

                {   entity.FirstName = model.FirstName;
                    entity.MI = model.MI;
                    entity.LastName = model.LastName;
                    entity.Address = model.Address;
                    entity.City = model.City;
                    entity.State = model.State;
                    entity.Zip = model.Zip;
                    entity.Cell = model.Cell;
                    entity.SocialMedia = model.SocialMedia;
                };

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDeveloper(int developerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                      .Developers
                      .Single(e => e.DeveloperId == developerId);
                ctx.Developers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}


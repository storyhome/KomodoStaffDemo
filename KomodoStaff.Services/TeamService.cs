using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoStaff.Services
{
    public class TeamService
    {
        private readonly Guid _userId;

        public TeamService(Guid userID)
        {
            _userId = userID;
        }
    }
}

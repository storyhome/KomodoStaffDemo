using System.Collections.Generic;
using KomodoStaff.Models.Developer;

namespace KomodoStaff.Contracts
{
    public interface IDeveloperService
    {
        bool CreateDeveloper(DeveloperCreate model);
        bool DeleteDeveloper(int developerId);
        DeveloperDetail GetDeveloperById(int developerId);
        IEnumerable<DeveloperListItem> GetDevelopers();
        bool UpdateDeveloper(DeveloperEdit model);
    }
}
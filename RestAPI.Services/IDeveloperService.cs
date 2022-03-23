using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Services
{
    public interface IDeveloperService
    {
        Task<IEnumerable<Developer>> GetAllDevelopers();
        Task<Developer> GetDeveloperById(int Id);
        Task<Developer> GetDeveloperByEmail(string DeveloperEmail);
        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int Id);
    }
}

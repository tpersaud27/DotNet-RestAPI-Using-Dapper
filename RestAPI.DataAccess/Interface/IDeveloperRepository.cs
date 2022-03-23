using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.DataAccess.Interface
{
    public interface IDeveloperRepository
    {
        // This will be for getting all of the developers
        // This is a enumerable of type Developer (from the developer model in the RestAPI.Domain)
        Task<IEnumerable<Developer>> GetAllDevelopersAsync();
        // This will be for getting the developer by id
        Task<Developer> GetDeveloperByIdAsync(int Id);
        // This will be for getting the developer by email
        Task<Developer> GetDeveloperByEmailAsync(string DeveloperEmail);
        // This will be for adding a developer
        // Note we will pass a developer object 
        void AddDeveloper(Developer developer);
        // This is for updating a developer
        void UpdateDeveloper(Developer developer);
        // This is for deleting a developer using id
        void DeleteDeveloper(int Id);

    }
}

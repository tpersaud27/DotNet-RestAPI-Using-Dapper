using RestAPI.DataAccess.Interface;
using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Services
{
    public class DeveloperService : IDeveloperService
    {

        // Using dependency injection to get access to the data access layer
        protected readonly IDeveloperRepository _developerRepository;

        // inject the dependency into the constructor
        // now we will have access to all the methods in the data access layer through loose coupling
        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }


        public void AddDeveloper(Developer developer)
        {
            _developerRepository.AddDeveloper(developer);
        }

        public void DeleteDeveloper(int Id)
        {
            _developerRepository.DeleteDeveloper(Id);
        }

        public Task<IEnumerable<Developer>> GetAllDevelopers()
        {
            return _developerRepository.GetAllDevelopersAsync();
        }

        public Task<Developer> GetDeveloperByEmail(string DeveloperEmail)
        {
            return _developerRepository.GetDeveloperByEmailAsync(DeveloperEmail);
        }

        public Task<Developer> GetDeveloperById(int Id)
        {
            return _developerRepository.GetDeveloperByIdAsync(Id);
        }

        public void UpdateDeveloper(Developer developer)
        {
            _developerRepository.UpdateDeveloper(developer);
        }
    }
}

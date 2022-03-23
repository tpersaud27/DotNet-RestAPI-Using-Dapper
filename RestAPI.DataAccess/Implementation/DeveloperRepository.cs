using Dapper;
using Microsoft.Extensions.Configuration;
using RestAPI.DataAccess.Interface;
using RestAPI.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.DataAccess.Implementation
{
    //Here we implement the interface
    public class DeveloperRepository : IDeveloperRepository
    {

        protected readonly IConfiguration _config;

        public DeveloperRepository(IConfiguration config)
        {
            _config = config;
        }

        // Now we create a IDb connection object called connection to init the database connection
        public IDbConnection Connection
        {
            get
            {
                // Now we dont need to hard code in the connection string
                return new SqlConnection(_config.GetConnectionString("DevelopersDBConnection"));
            }
        }

        public void AddDeveloper(Developer developer)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    //open the connection
                    dbConnection.Open();
                    // This query is for adding something to the database
                    string query = @"INSERT INTO Developers (DeveloperName, DeveloperEmail, Department) VALUES (@DeveloperName, @DeveloperEmail, @Department)";
                    // Pass the query and the object parameter
                    dbConnection.Execute(query, developer);
                }
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDeveloper(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    //open the connection
                    dbConnection.Open();
                    // This query is for deleting based on id
                    string query = @"DELETE FROM Developers WHERE Id = @Id";
                    dbConnection.Execute(query, new { Id = Id});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    //open the connection
                    dbConnection.Open();
                    // This query is for selecting all developers
                    string query = @"SELECT * FROM Developers";
                    return await dbConnection.QueryAsync<Developer>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Developer> GetDeveloperByEmailAsync(string DeveloperEmail)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    //open the connection
                    dbConnection.Open();
                    // This query is for selecting developer by email
                    string query = @"SELECT FROM Developers WHERE DeveloperEmail = @DeveloperEmail";
                    // This will return the first result found
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new {DeveloperEmail = DeveloperEmail});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Developer> GetDeveloperByIdAsync(int Id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    //open the connection
                    dbConnection.Open();
                    // This query is for selecting developer by id
                    string query = @"SELECT FROM Developers WHERE Id = @Id";
                    // This will return the first result found
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new { Id = Id });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateDeveloper(Developer developer)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    //open the connection
                    dbConnection.Open();
                    // This query is for updating developer information
                    string query = @"Update Developers SET DeveloperName = @DeveloperName, DevelopEmail = @DeveloperEmail, Department = @Department";
                    dbConnection.Execute(query, developer);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

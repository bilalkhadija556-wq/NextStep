using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NextStepMVC.Models;
using NextStepMVC.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NextStepMVC.Repositories
{
    public class OpportunityRepository : IOpportunityRepository
    {
        private readonly string _connectionString;

        public OpportunityRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Opportunity> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Opportunities";

                return connection.Query<Opportunity>(query).ToList();
            }
        }

        public Opportunity GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Opportunities WHERE Id = @Id";

                return connection.QueryFirstOrDefault<Opportunity>(
                    query, new { Id = id });
            }
        }

        public List<Opportunity> Search(string search)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM Opportunities
                                 WHERE Title LIKE @Search
                                 OR Organization LIKE @Search";

                return connection.Query<Opportunity>(
                    query, new { Search = "%" + search + "%" }).ToList();
            }
        }

        public void Add(Opportunity opportunity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Opportunities
                                (Title, Organization, Type, Description,
                                 Location, Deadline, ApplicationLink)
                                VALUES
                                (@Title, @Organization, @Type, @Description,
                                 @Location, @Deadline, @ApplicationLink)";

                connection.Execute(query, opportunity);
            }
        }

        public void Update(Opportunity opportunity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Opportunities
                                SET Title = @Title,
                                    Organization = @Organization,
                                    Type = @Type,
                                    Description = @Description,
                                    Location = @Location,
                                    Deadline = @Deadline,
                                    ApplicationLink = @ApplicationLink
                                WHERE Id = @Id";

                connection.Execute(query, opportunity);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Opportunities WHERE Id = @Id";

                connection.Execute(query, new { Id = id });
            }
        }
    }
}

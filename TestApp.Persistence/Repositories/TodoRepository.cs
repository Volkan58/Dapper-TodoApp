using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Interfaces;
using TestApp.Domain.Common;
using TestApp.Domain.Entiti;

namespace TestApp.Persistence.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext dbcontext;

        public TodoRepository(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<bool> AddAsync(Todo t)
        {
            using (var Connection = dbcontext.CreateConnection())
            {

                Connection.Open();

                var query = $"INSERT INTO Todos VALUES('{t.Title}', '{t.Description}', GETDATE(), { (int)t.Status})";
                return await Connection.ExecuteAsync(query) > 0;

            }

        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            using (var Connection = dbcontext.CreateConnection())
            {
                Connection.Open();

                //Procedure Kullanım
                return await Connection.QueryAsync<Todo>("sp_Get",commandType :System.Data.CommandType.StoredProcedure);

            }
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            using (var Connection = dbcontext.CreateConnection())
            {
                Connection.Open();

                return await Connection.QueryFirstOrDefaultAsync<Todo>($"Select * From Todos Where ID='{id}'");


            }


        }

        public async Task<bool> RemoveAsync(int id)
        {
            using (var Connection=dbcontext.CreateConnection())
            {
                Connection.Open();
                return await Connection.ExecuteAsync($"Delete From Todos Where ID= '{id}'")>0;

                
            }
        }

        public async Task<bool> UpdateAsync(Todo t)
        {
            using (var connection = dbcontext.CreateConnection())
            {
                connection.Open();

                return await connection.ExecuteAsync($"UPDATE Todos SET " +
                    $"{nameof(t.Title)} = '{t.Title}', " +
                    $"{nameof(t.Description)} = '{t.Description}'," +
                    $" {nameof(t.Status)} = {(int)t.Status} " +
                    $"WHERE Id = '{t.ID}'") > 0;
            }
        }
    }
}

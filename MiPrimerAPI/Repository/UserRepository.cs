using System.Data;
using System.Data.SqlClient;
using Dapper;
using MiPrimerAPI.Entities;

namespace MiPrimerAPI.Repositories
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<User>("SELECT * FROM Users");
            }
        }

        public async Task<User> GetUserById(int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE UserId = @UserId", new { UserId = userId });
            }
        }

        public async Task<int> AddUser(User user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return await dbConnection.ExecuteAsync("INSERT INTO Users (Name, LastName, Age, Gender) VALUES (@Name, @LastName, @Age, @Gender)", user);
            }
        }

        // Agrega otros métodos según tus necesidades (actualización, eliminación, etc.)
    }
}

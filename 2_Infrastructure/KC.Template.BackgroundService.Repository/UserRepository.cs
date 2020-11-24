using Dapper;
using KC.Template.BackgroundService.Domain;
using KC.Template.BackgroundService.Domain.Entities;
using KC.Template.BackgroundService.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace KC.Template.BackgroundService.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        private readonly ThisDBContext _dbContext;
        public UserRepository(ThisDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetAll()
        {
            var sql = $"SELECT * FROM User";
            return _dbContext.DbConnection.Query<User>(sql, null, _dbContext.DbTransaction).ToList();
        }
    }
}

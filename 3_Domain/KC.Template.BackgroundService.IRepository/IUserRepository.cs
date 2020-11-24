using KC.Template.BackgroundService.Domain.Entities;
using System.Collections.Generic;

namespace KC.Template.BackgroundService.IRepository
{
    public interface IUserRepository : IBaseRepository
    {
        List<User> GetAll();
    }
}

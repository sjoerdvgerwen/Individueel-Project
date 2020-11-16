using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Application.Entity;

namespace Warehouse.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);

    }
}

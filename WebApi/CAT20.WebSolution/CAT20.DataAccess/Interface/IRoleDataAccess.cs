using System.Collections.Generic;
using System;
using CAT20.DataAccess.Models;

namespace CAT20.DataAccess.Interface
{
    public interface IRoleDataAccess
    {
        int Add(Role roleData);
        IEnumerable<Role> Roles();
        Role SearchByRoleId(Guid roleId);
        int Delete(Role role);
        Role SearchByRoleName(string name);
    }
}
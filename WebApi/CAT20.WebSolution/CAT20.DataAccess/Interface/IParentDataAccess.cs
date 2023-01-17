using CAT20.DataAccess.Models;
using System.Collections.Generic;

namespace CAT20.DataAccess.Interface
{
    public interface IParentDataAccess
    {
        int Register(List<Parent> parents);
    }
}
using System.Collections.Generic;
using CAT20.Model;

namespace CAT20.DataAccess.Interface
{
    public interface IMasterDataAccess
    {
        List<CAT20.Model.BloodGroup> Bloodgroup();
        List<CAT20.Model.Category> Category();
        List<CAT20.Model.Gender> Gender();
        List<CAT20.Model.Religion> Religion();
        List<CAT20.Model.ParentType> Parenttype();
        List<CAT20.Model.Status> Status();
    }
}
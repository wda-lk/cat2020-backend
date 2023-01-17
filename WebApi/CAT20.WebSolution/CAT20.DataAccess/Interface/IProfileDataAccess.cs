using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = CAT20.Model;

namespace CAT20.DataAccess.Interface
{
    public interface IProfileDataAccess
    {
        bool AddProfile(Model.Profile profile);
        bool DeleteProfile(Guid profileId);
        bool UpdateProfile(Model.Profile profile);
        Model.Profile FetchProfileById(Guid profileId);
        IEnumerable<Model.Profile> FetchAllProfile();
    }
}

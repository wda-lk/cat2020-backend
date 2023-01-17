using CAT20.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using CAT20.DataAccess.Models;

namespace CAT20.DataAccess
{
    public class MasterDataAccess : IMasterDataAccess
    {
        private SchoolEntities _dbContext;

        public MasterDataAccess(SchoolEntities schoolEntites)
        {
            _dbContext = schoolEntites;
        }

        public List<CAT20.Model.BloodGroup> Bloodgroup()
        {
            var returnValue = new List<CAT20.Model.BloodGroup>();
            try
            {
                returnValue = _dbContext.BloodGroup.Select(x => new CAT20.Model.BloodGroup
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public List<CAT20.Model.Category> Category()
        {
            var returnValue = new List<CAT20.Model.Category>();
            try
            {
                returnValue = _dbContext.Category.Select(x => new CAT20.Model.Category
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public List<CAT20.Model.Gender> Gender()
        {
            var returnValue = new List<CAT20.Model.Gender>();
            try
            {
                returnValue = _dbContext.Gender.Select(x => new CAT20.Model.Gender
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public List<CAT20.Model.ParentType> Parenttype()
        {
            var returnValue = new List<CAT20.Model.ParentType>();
            try
            {
                returnValue = _dbContext.ParentType.Select(x => new CAT20.Model.ParentType
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public List<CAT20.Model.Religion> Religion()
        {
            try
            {
                var returnValue = _dbContext.Religion.Select(x => new CAT20.Model.Religion
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CAT20.Model.Status> Status()
        {
            try
            {
                var returnValue = _dbContext.Status.Select(x => new CAT20.Model.Status
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();
                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

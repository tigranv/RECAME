using BisolCRM.DAL.Interfaces.Repository;
using BisolCRM.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Repository
{
    class TAWDBCITYDal : CoreDal, ITAWDBCITYDal
    {
        public TAWDBCITYDal(BaseDal dal)
            : base(dal)
        {
        }

        public TAWDBCITY GetTAWDBCITYById(int id)
        {
            return db.TAWDBCITies.FirstOrDefault(x => x.ID == id);
        }

        public List<TAWDBCITY> GetTAWDBCITYs()
        {
            var query = db.TAWDBCITies.AsQueryable();
            return query.ToList();
        }
    }
}

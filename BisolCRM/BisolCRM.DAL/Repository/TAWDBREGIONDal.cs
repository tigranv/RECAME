using BisolCRM.DAL.Interfaces.Repository;
using BisolCRM.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Repository
{
    public class TAWDBREGIONDal : CoreDal, ITAWDBREGIONDal
    {
        public TAWDBREGIONDal(BaseDal dal)
            : base(dal)
        {
        }

        public TAWDBREGION GetTAWDBREGIONById(int id)
        {
            return db.TAWDBREGIONs.FirstOrDefault(x => x.ID == id);
        }

        public List<TAWDBREGION> GetTAWDBREGIONs()
        {
            var query = db.TAWDBREGIONs.AsQueryable();
            return query.ToList();
        }
    }
}

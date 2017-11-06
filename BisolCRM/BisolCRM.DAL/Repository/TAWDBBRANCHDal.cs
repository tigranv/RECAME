using BisolCRM.DAL.Interfaces.Repository;
using BisolCRM.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Repository
{
    public class TAWDBBRANCHDal : CoreDal, ITAWDBBRANCHDal
    {
        public TAWDBBRANCHDal(BaseDal dal)
            : base(dal)
        {
        }

        public TAWDBBRANCH GetTAWDBBRANCHById(int id)
        {
            return db.TAWDBBRANCHes.FirstOrDefault(x => x.ID == id);
        }

        public List<TAWDBBRANCH> GetTAWDBBRANCHs()
        {
            var query = db.TAWDBBRANCHes.AsQueryable();
            return query.ToList();
        }
    }
}

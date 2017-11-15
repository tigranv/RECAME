using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces.Repository
{
    public interface ITAWDBCITYDal
    {
        List<TAWDBCITY> GetTAWDBCITYs();

        TAWDBCITY GetTAWDBCITYById(int id);
    }
}

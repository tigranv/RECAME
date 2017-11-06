using BisolCRM.DAL.DataContracts;
using BisolCRM.DAL.DataContracts.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.DAL.Interfaces.Repository
{
    public interface IQueryBuilder
    {
        IQueryable<TEntity> PrepareQuery<TEntity>(FilterBase filter) where TEntity : ModelBase;

    }
}

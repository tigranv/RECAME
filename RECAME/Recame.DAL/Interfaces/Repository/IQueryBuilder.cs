using Recame.DAL.DataContracts;
using Recame.DAL.DataContracts.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.Interfaces.Repository
{
    interface IQueryBuilder
    {
        IQueryable<TEntity> PrepareQuery<TEntity>(FilterBase filter) where TEntity : ModelBase;
    }
}

using Recame.DAL.DataContracts.Filters;
using Recame.DAL.Interfaces.Repository;
using Recame.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.Repository
{
    public class FoodShopDal : CoreDal, IFoodShopDal
    {
        public FoodShopDal(BaseDal dal)
            : base(dal)
        {
        }

        public FoodShop GetFoodShopById(int id)
        {
            throw new NotImplementedException();
        }

        public List<fnFoodShop> GetFoodShops(FilterFoodShop filter)
        {
            throw new NotImplementedException();
        }
    }
}

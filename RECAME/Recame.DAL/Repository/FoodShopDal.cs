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

        public FoodShopDal()
        {

        }

        public FoodShop GetFoodShopById(int id)
        {
            return db.FoodShops.FirstOrDefault(x => x.Id == id);
        }

        public List<fnFoodShop> GetFoodShops(FilterFoodShop filter)
        {
            var query = db.fn_FoodShop(filter.LangId).AsQueryable();
            return filter.FilterObjects(query).ToList();
        }
    }
}

using Recame.DAL.DataContracts.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recame.DAL.Interfaces.Repository
{
    public interface IFoodShopDal
    {
        List<fnFoodShop> GetFoodShops(FilterFoodShop filter);

        FoodShop GetFoodShopById(int id);
    }
}

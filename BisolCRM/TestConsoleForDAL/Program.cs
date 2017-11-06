using BisolCRM.DAL.DataContracts.Filters;
using BisolCRM.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleForDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            var BDal = new BaseDal();
            var filter = new FilterRESIDENTCONTRACT();
            filter.MaxRows = 10;
            var data = BDal.RESIDENTCONTRACTDal.GetRESIDENTCONTRACTs(filter);

            foreach (var item in data)
            {
                Console.WriteLine($"{item.ID}, {item.BRANCH}, {item.NAME}");
            }

            Console.ReadKey();
        }
    }
}

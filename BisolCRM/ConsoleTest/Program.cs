using BisolCRM.DAL.DataContracts.Filters;
using BisolCRM.DAL.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FilterRESIDENTCONTRACT filter = new FilterRESIDENTCONTRACT();

            using (var BDal = new BaseDal())
            {
                filter.MaxRows = 1000;
                //ResidentsList = new ObservableCollection<fnRESIDENTCONTRACT>(BDal.RESIDENTCONTRACTDal.GetRESIDENTCONTRACTs(filter));
                var invoices = BDal.RESIDENTCONTRACTDal.GetRESIDENTCONTRACTs(filter);
                foreach (var item in invoices)
                {
                    Console.WriteLine($"{item.ID},");
                }
                Console.ReadKey();
            }
        }
    }
}

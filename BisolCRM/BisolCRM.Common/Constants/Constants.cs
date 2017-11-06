using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisolCRM.Common.Constants
{
    public static class Constants
    {
        public static class Errors
        {
           
           public const string WrongHash = "WrongFood";
           public const string Error = "WrongFood";

        }

        public class Filter
        {
            public const int MaxRows = 10000;
        }

        public static class Others
        {
            public const int StartDayNumbers = -1;
            public const int EndDayNumbers = 1;
            public const string ReadOnlyDbConnectionName = "ReadOnly";

        }
    }
}

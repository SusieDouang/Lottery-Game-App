using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Susie.Common.Extensions
{
    public static class Extensions
    {
        /// <summary> This method will attempt to convert the string value to the vaild DateTime -- 
        /// if it fails, then the method will return a DateTime.MinValue since DateTime types can't be null, you check DateTime types for invaild value
        /// </summary>
        
        public static DateTime ToDate(this string s)
        {
            DateTime dateTime;
            if (DateTime.TryParse(s, out dateTime))
                return dateTime;
            else
                return DateTime.MinValue;
        }
        public static int ToInt(this string s)
        {
            int intValue = 0;
            if (int.TryParse(s, out intValue))
                return intValue;
            else
                return 0;
        }

        public static String aString()
        {
            string aString = "Hey";
            return aString;

        }
    }
}

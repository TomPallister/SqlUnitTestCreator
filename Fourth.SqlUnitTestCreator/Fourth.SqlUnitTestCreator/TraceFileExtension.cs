using System;
using System.Globalization;
using Microsoft.SqlServer.Management.Trace;

namespace Fourth.SqlUnitTestCreator
{
    public static class TraceFileExtension
    {

        public static bool SafeValue(this TraceFile dr, string columnName, bool defaultValue)
        {
            return dr.SafeBool(columnName, defaultValue);
        }

     
        public static int SafeValue(this TraceFile dr, string columnName, int defaultValue)
        {
            return dr.SafeInt(columnName, defaultValue);
        }

      
        public static string SafeValue(this TraceFile dr, string columnName, string defaultValue)
        {
            return dr.SafeString(columnName, defaultValue);
        }
      
        public static char SafeValue(this TraceFile dr, string columnName, char defaultValue)
        {
            return dr.SafeChar(columnName, defaultValue);
        }

     
        public static decimal SafeValue(this TraceFile dr, string columnName, decimal defaultValue)
        {
            return dr.SafeDecimal(columnName, defaultValue);
        }

      
        public static double SafeValue(this TraceFile dr, string columnName, double defaultValue)
        {
            return dr.SafeDouble(columnName, defaultValue);
        }

     
        public static DateTime SafeValue(this TraceFile dr, string columnName, DateTime defaultValue)
        {
            return dr.SafeDateTime(columnName, defaultValue);
        }

      
        public static bool SafeBool(this TraceFile dr, string columnName, bool defaultValue)
        {
            var dbValue = dr[columnName];

            if (dbValue == DBNull.Value || dbValue == null)
                return defaultValue;

            bool bValue;

            if (dbValue is bool)
            {
                bValue = (bool)dbValue;
            }
            else
            {
                switch ((int)dbValue)
                {
                    case 1:
                        bValue = true;
                        break;
                    case 0:
                        bValue = false;
                        break;
                    default:
                        bValue = defaultValue;
                        break;
                }
            }
            return bValue;
        }

       
        public static int SafeInt(this TraceFile dr, string columnName, int defaultValue)
        {
            var dbValue = dr[columnName];

            return dbValue == DBNull.Value ? defaultValue : Int32.Parse(dbValue.ToString(), CultureInfo.InvariantCulture);
        }

        
        public static string SafeString(this TraceFile dr, string columnName, string defaultValue)
        {
            var dbValue = dr[columnName];
            return dbValue != null ? dbValue.ToString().Trim() : defaultValue;
        }

       
        public static char SafeChar(this TraceFile dr, string columnName, char defaultValue)
        {
            var dbValue = dr[columnName];

            return dbValue == DBNull.Value ? defaultValue : char.Parse(dbValue.ToString());
        }

      
        public static decimal SafeDecimal(this TraceFile dr, string columnName, decimal defaultValue)
        {
            var dbValue = dr[columnName];

            return dbValue == DBNull.Value ? defaultValue : decimal.Parse(dbValue.ToString(), CultureInfo.InvariantCulture);
        }

      
        public static double SafeDouble(this TraceFile dr, string columnName, double defaultValue)
        {
            var dbValue = dr[columnName];

            return dbValue == DBNull.Value ? defaultValue : double.Parse(dbValue.ToString(), CultureInfo.InvariantCulture);
        }


    
        public static DateTime SafeDateTime(this TraceFile dr, string columnName, DateTime defaultValue)
        {
            var dbValue = dr[columnName];

            return dbValue != DBNull.Value && dbValue is DateTime ? (DateTime)dbValue : defaultValue;
        }
    }
}

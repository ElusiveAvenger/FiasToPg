using System;
using System.Data;

namespace FiasToPg.Parse
{
    public static class Extension
    {
        public static T Parse<T>(this DataRow row, DataColumn column)
        {
            return row[column] == DBNull.Value ? default : (T)row[column];
        }
    }
}

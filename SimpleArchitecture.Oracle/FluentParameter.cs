using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace SimpleArchitecture.Oracle
{
    public static class FluentParameter
    {
        public static OracleParameter In(string name, OracleDbType dbType)
        {
            var parameter = new OracleParameter
            {
                ParameterName = name.StartsWith(":") ? name : ":" + name,
                OracleDbType = dbType,
                Direction = ParameterDirection.Input
            };

            return parameter;
        }

        public static OracleParameter SetValue(this OracleParameter parameter, object value)
        {
            parameter.Value = (value ?? DBNull.Value);
            return parameter;
        }

        public static OracleParameter SetSize(this OracleParameter parameter, int size)
        {
            if (size > 0)
            {
                parameter.Size = size;
            }

            return parameter;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using GSoft.AbpZeroTemplate.Helpers.Dto;
using System.Linq;

namespace GSoft.AbpZeroTemplate.Helpers
{
    public interface IProcedureHelper
    {
        ListT GetDataT(string procedureName, object parameter);
    }

    public class ProcedureHelper  IProcedureHelper
    {
        private readonly string connectionString;
    public ProcedureHelper()
    {
        connectionString = Data Source = HOANGIT7; Initial Catalog = DbPratice; Integrated Security = True;
    }

    private ListProcedureParamInfo GetParamInfos(IDbConnection conn, string procedureName)
    {
        var rr = conn.QueryProcedureParamInfo($select PARAMETER_NAME, PARAMETER_MODE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH from information_schema.parameters where specific_name = '{procedureName}');
        return rr.ToList();
    }

    public ListT GetDataT(string procedureName, object parameter)
    {
        ListT result;

        using (IDbConnection con = new SqlConnection(connectionString))
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            var paramsInfo = GetParamInfos(con, procedureName);

            DynamicParameters parameters = new DynamicParameters();

            var properties = parameter.GetType().GetProperties();

            foreach (var param in paramsInfo)
            {
                var property = properties
                                .Where(x = x.Name.ToLower() == param.PARAMETER_NAME.Replace(@,).ToLower())
                                .FirstOrDefault();
                if (property == null)
                {
                    continue;
                }
                parameters.Add(param.PARAMETER_NAME, property.GetValue(parameter));
            }

            result = con.QueryT(procedureName, parameters, null, true, null, System.Data.CommandType.StoredProcedure).ToList();
        }

        return result;
    }
}
}

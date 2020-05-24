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
        List<T> GetData<T>(string procedureName, object parameter);
    }

    public class ProcedureHelper : IProcedureHelper
    {
        private readonly string connectionString;
        public ProcedureHelper()
        {
            connectionString = "Server=DESKTOP-I4RR9G6; Database=DbPratice; Trusted_Connection=True;";
        }

        private List<ProcedureParamInfo> GetParamInfos(IDbConnection conn, string procedureName)
        {
            var rr = conn.Query<ProcedureParamInfo>($"select PARAMETER_NAME, PARAMETER_MODE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH from information_schema.parameters where specific_name = '{procedureName}'");
            return rr.ToList();
        }

        public List<T> GetData<T>(string procedureName, object parameter)
        {
            List<T> result;

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
                                    .Where(x => x.Name.ToLower() == param.PARAMETER_NAME.Replace("@", "").ToLower())
                                    .FirstOrDefault();
                    if (property == null)
                    {
                        continue;
                    }
                    parameters.Add(param.PARAMETER_NAME, property.GetValue(parameter));
                }

                result = con.Query<T>(procedureName, parameters, null, true, null, System.Data.CommandType.StoredProcedure).ToList();
            }

            return result;
        }
    }
}

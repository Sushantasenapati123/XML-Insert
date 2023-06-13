using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TIMETABLE_MANAGEMENT_SYSTEM.Models;

namespace TIMETABLE_MANAGEMENT_SYSTEM.Repository
{
    public class TIMETABLE_REPOSITORY:BASE_REPOSITORY, ITIMETABLE_REPOSITORY
    {
        public TIMETABLE_REPOSITORY(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<TimeTableModel>> Bind_Department(int DEPT_ID)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "BD");
                param.Add("@DEPT_ID", DEPT_ID);
                param.Add("@PMSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var lstDept = cn.Query<TimeTableModel>("SP_TIMEMANAGEMENT", param, commandType: CommandType.StoredProcedure).ToList();
                return lstDept;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TimeTableModel>> Bind_Branch(int DEPT_ID)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "BB");
                param.Add("@DEPT_ID", DEPT_ID);
                param.Add("@PMSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var lstDept = cn.Query<TimeTableModel>("SP_TIMEMANAGEMENT", param, commandType: CommandType.StoredProcedure).ToList();
                return lstDept;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<TimeTableModel>> Bind_Semister(int NO_OF_YEAR)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "BS");
                param.Add("@NO_OF_YEAR",NO_OF_YEAR);
                param.Add("@PMSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                var lstDept = cn.Query<TimeTableModel>("SP_TIMEMANAGEMENT", param, commandType: CommandType.StoredProcedure).ToList();
                return lstDept;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<int> Insert(TimeTableModel obj)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "TI");
                param.Add("@BRANCH_ID", obj.BRANCH_ID);
                param.Add("@DEPT_ID", obj.DEPT_ID);
                param.Add("@SEMISTER_ID", obj.SEMISTER_ID);
                param.Add("@SEMISTER_NAME", obj.SEMISTER_NAME);
                param.Add("@DAY", obj.DAY);
                param.Add("@YEAR_OF_EDUCATION", obj.YEAR_OF_EDUCATION);
                param.Add("@xmlValue", obj.XMLNODE);

                param.Add("@PMSG_OUT", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 5215585);
                cn.Execute("SP_TIMEMANAGEMENT", param, commandType: CommandType.StoredProcedure);
                int x = param.Get<int>("@PMSG_OUT");
                cn.Close();
                return x;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMETABLE_MANAGEMENT_SYSTEM.Models;

namespace TIMETABLE_MANAGEMENT_SYSTEM.Services
{
    public interface ITIMETABLE_SERVICE
    {
        Task<List<TimeTableModel>> Bind_DepartmentService(int DEPT_ID);
        Task<List<TimeTableModel>> Bind_BranchService(int DEPT_ID);
        Task<List<TimeTableModel>> Bind_SemisterService(int NO_OF_YEAR);
        Task<int> InsertService (TimeTableModel obj);
    }
}

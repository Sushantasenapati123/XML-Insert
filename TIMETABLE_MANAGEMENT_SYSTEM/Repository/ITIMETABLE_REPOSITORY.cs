using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMETABLE_MANAGEMENT_SYSTEM.Models;

namespace TIMETABLE_MANAGEMENT_SYSTEM.Repository
{
    public interface ITIMETABLE_REPOSITORY
    {
        Task<List<TimeTableModel>> Bind_Department(int DEPT_ID);
        Task<List<TimeTableModel>> Bind_Branch(int DEPT_ID);
        Task<List<TimeTableModel>> Bind_Semister(int NO_OF_YEAR);
        Task<int> Insert(TimeTableModel obj);
    }
}

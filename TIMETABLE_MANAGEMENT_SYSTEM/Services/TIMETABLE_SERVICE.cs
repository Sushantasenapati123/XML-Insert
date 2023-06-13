using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIMETABLE_MANAGEMENT_SYSTEM.Models;
using TIMETABLE_MANAGEMENT_SYSTEM.Repository;

namespace TIMETABLE_MANAGEMENT_SYSTEM.Services
{
    public class TIMETABLE_SERVICE : ITIMETABLE_SERVICE
    {
        private readonly ITIMETABLE_REPOSITORY _itimetable;
        public TIMETABLE_SERVICE(ITIMETABLE_REPOSITORY itimetable)
        {
            _itimetable = itimetable;
        }
        public async Task<List<TimeTableModel>> Bind_BranchService(int DEPT_ID)
        {
            return await _itimetable.Bind_Branch(DEPT_ID);
        }

        public async Task<List<TimeTableModel>> Bind_DepartmentService(int DEPT_ID)
        {
            return await _itimetable.Bind_Department(DEPT_ID);
        }

        public async Task<List<TimeTableModel>> Bind_SemisterService(int NO_OF_YEAR)
        {
            return await _itimetable.Bind_Semister(NO_OF_YEAR);
        }

        public async Task<int> InsertService(TimeTableModel obj)
        {
            return await _itimetable.Insert(obj);
        }
    }
}

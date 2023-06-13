using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIMETABLE_MANAGEMENT_SYSTEM.Models
{
    public class TimeTableModel
    {
        public int ID { get; set; } = 0;
        public int BRANCH_ID { get; set; } = 0;
        public int DEPT_ID { get; set; } = 0;
        public int SEMISTER_ID { get; set; } = 0;
        public string SEMISTER_NAME { get; set; } = null;
        public string DAY { get; set; } = null;
        public int YEAR_OF_EDUCATION { get; set; } = 0;
        public string TEACHER_NAME { get; set; } = null;
        public string SUBJECT_NAME { get; set; } = null;
        public string FROMTIME { get; set; } = null;
        public string TOTIME { get; set; } = null;
        public string TOTALTIME { get; set; } = null;
        public List<Time> listPeriod { get; set; }
        public string XMLNODE { get; set; } = null;
        public int NO_OF_YEAR { get; set; } = 0;
        public int PMSG_OUT { get; set; } = 0;
        public string DEPT_NAME { get; set; } = null;
        public string BRANCH_NAME { get; set; } = null;
    }
    public class Time
    {
        public string PERIODS { get; set; } = null;
        public string TEACHER_NAME { get; set; } = null;
        public string SUBJECT_NAME { get; set; } = null;
        public string FROMTIME { get; set; } = null;
        public string TOTIME { get; set; } = null;
        public string TOTALTIME { get; set; } = null;
    }
}

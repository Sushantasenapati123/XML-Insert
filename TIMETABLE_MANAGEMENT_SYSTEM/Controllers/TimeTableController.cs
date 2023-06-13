using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TIMETABLE_MANAGEMENT_SYSTEM.Models;
using TIMETABLE_MANAGEMENT_SYSTEM.Services;

namespace TIMETABLE_MANAGEMENT_SYSTEM.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly ITIMETABLE_SERVICE _timetable;
        public TimeTableController(ITIMETABLE_SERVICE timetable)
        {
            _timetable = timetable;
        }
        public async Task<IActionResult> Add()
        {
            List<TimeTableModel> lstDepartment = new List<TimeTableModel>();
            int DEPT_ID = 0;
            lstDepartment = await _timetable.Bind_DepartmentService(DEPT_ID);
            lstDepartment.Insert(0, new TimeTableModel { DEPT_ID = 0, DEPT_NAME = "Please Select Department" });
            ViewBag.Department = lstDepartment;
            return View();
        }
        public async Task<JsonResult> Branch_Bind(int DEPT_ID)
        {
            var subcatList = await _timetable.Bind_BranchService(DEPT_ID);
            List<SelectListItem> scalist = new List<SelectListItem>();
            foreach (TimeTableModel dr in subcatList)
            {
                scalist.Add(new SelectListItem { Text = dr.BRANCH_NAME, Value = dr.BRANCH_ID.ToString() });
            }
            var jsonres = JsonConvert.SerializeObject(scalist);
            return Json(jsonres);
        }
        public async Task<JsonResult> Semister_Bind(int NO_OF_YEAR)
        {
            var subcatList = await _timetable.Bind_SemisterService(NO_OF_YEAR);
            List<SelectListItem> scalist = new List<SelectListItem>();
            foreach (TimeTableModel dr in subcatList)
            {
                scalist.Add(new SelectListItem { Text = dr.SEMISTER_NAME, Value = dr.SEMISTER_ID .ToString() });
            }
            var jsonres = JsonConvert.SerializeObject(scalist);
            return Json(jsonres);
        }
        public async Task<JsonResult> Year_Bind(int DEPT_ID)
        {
            var subcatList = await _timetable.Bind_DepartmentService(DEPT_ID);
            var jsonres = JsonConvert.SerializeObject(subcatList);
            return Json(jsonres);
        }
        [HttpPost]
        public async Task<JsonResult> SaveUpdate(TimeTableModel se)
        {
            if (se.listPeriod != null)
            {
                se.XMLNODE = ConvertDtToXml(se.listPeriod);
                int data = await _timetable.InsertService(se);
                return Json(data);
            }
            else
            {
                return Json(4);
            }
        }
        private string ConvertDtToXml<T>(List<T> items)
        {
            DataTable dt = ToDataTable(items);
            dt.TableName = "Timetable";
            System.IO.StringWriter stringWriter = new StringWriter();
            dt.WriteXml(stringWriter);
            string xmlFormat = stringWriter.ToString();
            return xmlFormat;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeePages.Models;

namespace EmployeePages.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }

        private readonly EmployeesEntities _emps = new EmployeesEntities();
        public ViewResult EmployeeList()
        {
            if (_emps != null)
            {
                List<udReadAllEmployee_Result> vals = _emps.udReadAllEmployee().ToList();
                return View(vals);
            }
            return View();
        }

        public ViewResult Details(Employee employee)
        {
            EmployeePages.Models.udReadEmployeeDetails_Result vals = _emps.udReadEmployeeDetails(employee.ID).FirstOrDefault();
            return View(vals);
        }

        public ViewResult Edit(Employee employee)
        {
            EmployeePages.Models.udReadEmployeeDetails_Result vals = _emps.udReadEmployeeDetails(employee.ID).FirstOrDefault();
            return View(vals);
        }

        public ViewResult Create()
        {

            List<string> Departments = _emps.udReadCVDepartment().ToList();
            List<string> Permissions = _emps.udReadCVPermissions().ToList();
            List<string> Titles = _emps.udReadCVTitle().ToList();

            List<SelectListItem> selectDept = new List<SelectListItem>();
            List<SelectListItem> selectPerm = new List<SelectListItem>();
            List<SelectListItem> selectTitle = new List<SelectListItem>();
            foreach (string dep in Departments)
            {
                //Adding every record to list  
                selectDept.Add(new SelectListItem { Text = dep, Value = dep });
            }
            foreach (string perm in Permissions)
            {
                //Adding every record to list  
                selectDept.Add(new SelectListItem { Text = perm, Value = perm });
            }

            foreach (string title in Titles)
            {
                //Adding every record to list  
                selectDept.Add(new SelectListItem { Text = title, Value = title });
            }


            ViewBag.Departments = selectDept;
            ViewBag.Permissions = selectPerm;
            ViewBag.Title = selectTitle;   
            return View();
        }

        public ViewResult Changes(Employee employee)
        {
            List<EmployeePages.Models.udReadChanges_Result> vals = _emps.udReadChanges(employee.ID).ToList();
            return View(vals);
        }


        public List<udReadAllEmployee_Result> Sort(string sortBy, bool sortAscending =true)
        {
            List<udReadAllEmployee_Result> vals = null;
           
            if (sortAscending)
            {
                vals = _emps.udReadAllEmployee()
                       .OrderBy(r => r.GetType().GetProperty(sortBy).GetValue(r, null))
                       .ToList();
            }
            else
            {
                vals = _emps.udReadAllEmployee()
                       .OrderByDescending(r => r.GetType().GetProperty(sortBy).GetValue(r, null))
                       .ToList();
            }
            return vals;
        }

        public object Filter(string column, string text)
        {
            //var vals = _emps.udReadAllEmployee().ToList().Where(r => r.GetType().GetProperty(column).GetValue(r, null).Contains(text)).ToList();
            var vals = _emps.udReadAllEmployee().ToList().Where(r => r.FirstName.Contains(text)).ToList();

            return vals;
        }
    }

    

}
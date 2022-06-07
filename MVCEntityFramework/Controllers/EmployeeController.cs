using MVCEntityFramework.Data;
using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEntityFramework.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext _applicationDBContext;
        private ICollection<Employee> _listEmployees;

        public EmployeeController()
        {
            _applicationDBContext = new ApplicationDBContext();            
        }
        // GET: Employee
        public ActionResult Index()
        {
            _listEmployees = _applicationDBContext.Employees.ToList();
            if (_listEmployees.Count > 0)
            {
                return View(_listEmployees);                
            }            
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee requestEmployee)
        {
            Employee employee = null;
            if (ModelState.IsValid)
            {
                try
                {
                    employee = _applicationDBContext.Employees.Add(requestEmployee);
                    _applicationDBContext.SaveChanges();
                    if (employee != null)
                    {
                        _listEmployees = _applicationDBContext.Employees.ToList();
                        return View("Index", _listEmployees);
                    }                        
                }
                catch(Exception ex)
                {
                    return Content("Error Occurred while inserting the employee.");
                }                
            }
            return View();
            
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            try
            {
                if (_applicationDBContext.Employees.Any(x => x.EmpId == id))
                {
                    Employee employee = _applicationDBContext.Employees.FirstOrDefault(x => x.EmpId == id);
                    return View(employee);
                }
            }
            catch(Exception ex)
            {
                return Content("Error while fetching employee record.");
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            Employee updateEmployee = _applicationDBContext.Employees.Where(emp => emp.EmpId == employee.EmpId).FirstOrDefault();
            if (updateEmployee != null)
            {
                updateEmployee.EmpFirstName = employee.EmpFirstName;
                updateEmployee.EmpLastName = employee.EmpLastName;
                updateEmployee.EmpEmail = employee.EmpEmail;
                updateEmployee.Salary = employee.Salary;
                _applicationDBContext.Entry(updateEmployee).State = System.Data.Entity.EntityState.Modified;
                _applicationDBContext.SaveChanges();
                //_listEmployees = _applicationDBContext.Employees.ToList();
                //return View("Index", _listEmployees);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Employee deleteEmployee = _applicationDBContext.Employees.Where(emp => emp.EmpId == id).FirstOrDefault();
            if(deleteEmployee != null)
            {
                return View(deleteEmployee);
            }
            return Content("Employee not found.");
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int? id)
        {
            try
            {
                Employee deleteEmployee = _applicationDBContext.Employees.Find(id);
                if (deleteEmployee != null)
                {
                    _applicationDBContext.Employees.Remove(deleteEmployee);
                    _applicationDBContext.SaveChanges();
                    _listEmployees = _applicationDBContext.Employees.ToList();
                    return View("Index", _listEmployees);
                }                
            }
            catch(Exception ex)
            {
                return Content("Error occurred while deleting the record.");
            }
            return View();
        }

        


    }
}
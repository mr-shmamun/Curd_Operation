using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalCurdOparetion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalCurdOparetion.Controllers
{
 
    public class EmployeeController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        public EmployeeController(EmployeeContext _db)
        {
            db = _db;
        }
        


        // GET: Employee
        public IActionResult Index()
        {

            List<Employee> data = db.employees.ToList();

            return View(data);
        }

        // GET: Employee/Details/5
        public IActionResult Details(int id)
        {
            Employee data = db.employees.Find(id);
            return View(data);
        }

        // GET: Employee/Create
        public IActionResult Create()
        { 
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee emp)
        {
            try
            {
                if (emp != null)
                {
                    db.employees.Add(emp);
                    db.SaveChanges();
                }

              

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(emp);
            }
        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            Employee data = db.employees.Find(id);
            return View(data);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee emp)
        {
            try
            {
                if (emp != null)
                {
                    db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(emp);
            }
        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int id)
        {
            Employee data = db.employees.Find(id);
            return View(data);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Employee employee)
        {
            Employee emp = db.employees.Find(id);
            try
            {
                if (emp != null)
                {
                    db.employees.Remove(emp);
                    db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(emp);
            }
        }
    }
}
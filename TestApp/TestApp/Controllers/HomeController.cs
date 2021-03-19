using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static List<Employee> employees = new List<Employee>()
        {
            new Employee() { EmployeeId = 101, FirstName = "Venkat", LastName = "Ch", City = "Allentown", State = "PA", Gender = "Male" },
            new Employee() { EmployeeId = 102, FirstName = "Siva", LastName = "Ch", City = "New York", State = "NY", Gender = "Male" },
            new Employee() { EmployeeId = 103, FirstName = "Ram", LastName = "Ch", City = "Allentown", State = "PA", Gender = "Male" },
            new Employee() { EmployeeId = 104, FirstName = "Name1", LastName = "Ch", City = "New York", State = "NY", Gender = "Male" },
            new Employee() { EmployeeId = 105, FirstName = "Name2", LastName = "Ch", City = "Allentown", State = "PA", Gender = "Female" },
            new Employee() { EmployeeId = 106, FirstName = "Name3", LastName = "Ch", City = "New York", State = "NY", Gender = "Male" },
            new Employee() { EmployeeId = 107, FirstName = "Name4", LastName = "Ch", City = "Allentown", State = "PA", Gender = "Male" }
        };

        static int employeeId = 108;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("FirstName", "LastName", "City", "State", "Gender")] Employee employee)
        {
            employees.Add(employee);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddEmployee()
        {
            var employee = new Employee();
            employee.StateList = GetStates();
            employee.CityList = GetCities();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee([Bind("FirstName", "LastName", "City", "State", "Gender")] Employee employee)
        {
            employee.EmployeeId = employeeId;
            employees.Add(employee);
            employeeId++;
            return RedirectToAction("Index", "Home", null);
        }

        public IActionResult UpdateEmployee(int id)
        {
            var employee = employees.Where(o => o.EmployeeId == id).FirstOrDefault();
            employee.StateList = GetStates();
            employee.CityList = GetCities();

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEmployee(int id,[Bind("FirstName", "LastName", "City", "State", "Gender")] Employee employee)
        {
            var employeeRemove = employees.Where(o => o.EmployeeId == id).FirstOrDefault();
            employees.Remove(employeeRemove);
            employees.Add(employee);
            return RedirectToAction("Index", "Home", null);
        }

        public IActionResult DeleteEmployee(int id)
        {
            var employeeRemove = employees.Where(o => o.EmployeeId == id).FirstOrDefault();
            employees.Remove(employeeRemove);
            return RedirectToAction("Index", "Home", null);
        }

        public static SelectList GetCities()
        {
            List<SelectListItem> tempList = new List<SelectListItem>();

            var city1 = new SelectListItem()
            {
                Text = "Allentown",
                Value = "Allentown"
            };
            var city2 = new SelectListItem()
            {
                Text = "New York",
                Value = "New York"
            };

            tempList.Add(city1);
            tempList.Add(city2);

            return new SelectList(tempList, "Value", "Text");

        }

        public static SelectList GetStates()
        {
            List<SelectListItem> tempList = new List<SelectListItem>();

            var state1 = new SelectListItem()
            {
                Text = "PA",
                Value = "PA"
            };
            var state2 = new SelectListItem()
            {
                Text = "NY",
                Value = "NY"
            };

            tempList.Add(state1);
            tempList.Add(state2);

            return new SelectList(tempList, "Value", "Text");
        }

    }
}

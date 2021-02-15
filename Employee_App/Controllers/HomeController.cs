using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee_APP.Data;
using Employee_App.Data.Domain;
using Employee_APP.Data.Repository;
using Employee_App.Repository;
using Employee_App.Repository.Repositories;
using Employee_APP.Repository.Repositories;
using Employee_App.Repository.ViewModels;

namespace Employee_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;

        private readonly IDepartmentRepository _departmentRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController()
        {
            _context = new ApplicationDBContext();

            _departmentRepository = new DepartmentRepository(_context);
            _clientRepository = new ClientRepository(_context);
            _employeeRepository = new EmployeeRepository(_context);
        }

        // GET: Home
        public ActionResult Index()
        {
            var query = _departmentRepository.GetAllDepartments().GroupBy(d => d.Dep_Name);

            var countData = _departmentRepository.GetDepartmentClientCount().FirstOrDefault();
            var MaxMinData = _employeeRepository.GetMaxMin();

            ViewBag.MaxCount = countData.res_num;
            ViewBag.MaxCountName = countData.Dep_Name;
            ViewBag.MaxSalary = MaxMinData.Select(e => e.salary_max).SingleOrDefault();
            ViewBag.MinSalary = MaxMinData.Select(e => e.salary_min).SingleOrDefault();
            return View(query);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.Department_ID = new SelectList(_departmentRepository.GetSelectListDepartmants().ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeVM empClient, string Department_ID)
        {
            if (ModelState.IsValid)
            {
                int result;
                var department = int.TryParse(Department_ID, out result);
                _employeeRepository.AddEmployee(empClient, result);
                return RedirectToAction("Index");
            }
            ViewBag.Department_ID = new SelectList(_departmentRepository.GetSelectListDepartmants().ToList(), "Id", "Name");

            return View(empClient);
        }

        public ActionResult CreateClient()
        {
            ViewBag.Employee_ID = new SelectList(_employeeRepository.GetAllEmployees().Select(e => new
            {
                ID = e.Id,
                Name = e.Full_Name
            }), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(ClientVM empClient, string Employee_ID)
        {
            if (ModelState.IsValid)
            {
                int result;
                var department = int.TryParse(Employee_ID, out result);
                //_employeeRepository.AddEmployee(empClient, result);
                _clientRepository.AddClient(empClient, result);
                return RedirectToAction("Index");
            }

            ViewBag.Employee_ID = new SelectList(_employeeRepository.GetAllEmployees().Select(e => new
            {
                ID = e.Id,
                Name = e.Full_Name
            }), "Id", "Name");

            return View(empClient);
        }

        public ActionResult Details(int id)
        {
            var data = _employeeRepository.GetByID(id).Select(e=>new
            {
                Full_Name = e.Full_Name,
                Email = e.Email,
                Address = e.Address,
                Phone = e.Phone,
                Salary = e.Salary,
                Department = e.Department
            }).SingleOrDefault();
            var empObj = new EmployeeDetailsVM
            {
                Full_Name = data.Full_Name,
                Email = data.Email,
                Address = data.Address,
                Phone = data.Phone,
                Salary = data.Salary,
                Department = data.Department
            };
            return View(empObj);
        }

        public ActionResult DepartmentDetails(int id)
        {
            var data = _departmentRepository.GetDetailedDepartment(id).GroupBy(d => d.DepartmentName);

            //var empObj = new DepartmentVM
            //{
            //    Name = data.Name,
            //    EmployeeDetails = data.Employee
            //};
            return View(data);
        }

        public JsonResult Search(string search_str, string search_by)
        {
            int result;
            int.TryParse(search_by, out result);

            if (result == 1)
            {
                var resData = _employeeRepository.GetAllEmployees().Where(e => e.Full_Name.Contains(search_str)).Select(e => new
                {
                    ID = e.Id,
                    Name = e.Full_Name,
                    Search_By = result
                }).ToList();
                return Json(resData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var resData = _departmentRepository.GetSelectListDepartmants().Where(e => e.Name.Contains(search_str)).Select(e => new
                {
                    ID = e.Id,
                    Name = e.Name,
                    Search_By = result
                }).ToList();
                return Json(resData, JsonRequestBehavior.AllowGet);
            }

        }

    }
}
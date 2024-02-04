using Employee_Data_Management_System.DAL;
using Employee_Data_Management_System.Models;
using Employee_Data_Management_System.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Data_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();
            if (employees != null)
            {
                foreach(var employee in employees)
                {
                    var EmployeeViewModel = new EmployeeViewModel()
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        DOB = employee.DOB,
                        Experience = employee.Experience,
                        Salary = employee.Salary
                    };
                    employeeList.Add(EmployeeViewModel);
                }
                return View(employeeList);
            }
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeData) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        DOB = employeeData.DOB,
                        Experience = employeeData.Experience,
                        Salary = employeeData.Salary
                    };
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee has been saved successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Opps, There is eroor in the data!";
                    return View();
                }

            }catch (Exception ex)
            {
                TempData["exceptionMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id) 
        {
            try
            {
                var emp = _context.Employees.SingleOrDefault(x => x.Id == Id);

                if (emp != null)
                {
                    var employeeView = new EmployeeViewModel()
                    {
                        Id = emp.Id,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        DOB = emp.DOB,
                        Experience = emp.Experience,
                        Salary = emp.Salary
                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = "Employee Not Found!";
                    return RedirectToAction("Index");
                }
            }
           catch (Exception ex) 
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model) 
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new Employee()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DOB = model.DOB,
                        Experience = model.Experience,
                        Salary = model.Salary
                    };
                    _context.Employees.Update(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Congratulations, Employee data has been updated successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Opps!, Data is Invalid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var emp = _context.Employees.SingleOrDefault(x => x.Id == Id);

                if (emp != null)
                {
                    var employeeView = new EmployeeViewModel()
                    {
                        Id = emp.Id,
                        FirstName = emp.FirstName,
                        LastName = emp.LastName,
                        DOB = emp.DOB,
                        Experience = emp.Experience,
                        Salary = emp.Salary
                    };
                    return View(employeeView);
                }
                else
                {
                    TempData["errorMessage"] = "Employee Not Found!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(EmployeeViewModel model)
        {
            try
            {
                var employee = _context.Employees.SingleOrDefault(x => x.Id == model.Id);

                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Employee has been deleted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Employee Not Found!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}

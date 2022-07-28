using Microsoft.AspNetCore.Mvc;
using Task1.Models;
using Task1.Repositries;
using log4net;
using Task1.Filters;

namespace Task1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        IEmployeeRepo _repository;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRepo repository) //DI
        {
            _logger = logger;
            _repository = repository;
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult Index()
        {
            _logger.LogInformation("Index Action is Processed");
            List<Employee> obj = _repository.GetAllEmp();
            //obj[10].Ename = "Tim"; This Line Causes exception to occur
            return View(obj);
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation("Create Action[GET] is Processed");
            return View();
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _logger.LogInformation("Create Action[POST] is Processed");
            _repository.AddEmp(obj);
            return RedirectToAction("Index");
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Details Action is Processed");
            Employee obj = _repository.GetEmpById(id);
            return View(obj);
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Edit Action[GET] is Processed");
            Employee emp = _repository.GetEmpById(id);
            return View(emp);
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _logger.LogInformation("Edit Action[POST] is Processed");
            _repository.UpdateEmp(obj);
            return RedirectToAction("Index");
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete Action[GET] is Processed");
            Employee emp = _repository.GetEmpById(id);
            return View(emp);
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _logger.LogInformation("Delete Confirmation is Processed");
            _repository.DeleteEmp(id);
            return RedirectToAction("Index");
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpGet]
        public IActionResult GetEmpsByDeptno()
        {
            _logger.LogInformation("Get Employee by Deptno Action[GET] is Processed");
            return View();
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpPost]
        public IActionResult GetEmpsByDeptno(int dno)
        {
            _logger.LogInformation("Get Employee by Deptno Action[POST] is Processed");
            List<Employee> li = _repository.GetByDno(dno);
            return View(li);
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpGet]
        public IActionResult GetEmpsByJob()
        {
            _logger.LogInformation("Get Employee by Job Action[GET] is Processed");
            return View();
        }

        [TypeFilter(typeof(CustomExceptionFilter))]
        [HttpPost]
        public IActionResult GetEmpsByJob(string job)
        {
            _logger.LogInformation("Get Employee by Job Action[POST] is Processed");
            List<Employee> li = _repository.GetByJob(job);
            return View(li);
        }
    }
}

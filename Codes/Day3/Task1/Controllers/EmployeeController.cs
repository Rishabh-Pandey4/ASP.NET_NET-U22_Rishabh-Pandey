using Microsoft.AspNetCore.Mvc;
using Task1.Models;
using Task1.Repositries;

namespace Task1.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepo _repository;

        public EmployeeController(IEmployeeRepo repository) //DI
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            List<Employee> obj = _repository.GetAllEmp();
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _repository.AddEmp(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Employee obj = _repository.GetEmpById(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = _repository.GetEmpById(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _repository.UpdateEmp(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee emp = _repository.GetEmpById(id);
            return View(emp);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _repository.DeleteEmp(id);
            return RedirectToAction("Index");
        }
    }
}

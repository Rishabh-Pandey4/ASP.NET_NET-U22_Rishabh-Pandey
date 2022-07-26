using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task1.Models;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public EmployeeManager context = new EmployeeManager();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(context.GetAllEmp());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Emp obj)
        {
            if (ModelState.IsValid == true)
            {
                context.AddEmp(obj);
                return RedirectToAction("Index");

            }
            else
            {

                ViewBag.RequestType = Request.Method;
                ViewBag.ErrorMessage = "Invalid data";
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            Emp obj = context.GetEmpById(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Emp obj = context.GetEmpById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Emp obj)
        {
            if (ModelState.IsValid == true)
            {
                context.UpdateEmp(obj);
                return RedirectToAction("Index");

            }
            else
            {

                ViewBag.RequestType = Request.Method;
                ViewBag.ErrorMessage = "Invalid data";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(context.GetEmpById(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_Confirmation(int id)
        {
            context.DeleteEmp(id);
            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using HR.Domain.DTOs;
using HR.Domain.Entities;
using HR.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HR.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _departmentService.Add(departmentDto);
                    _departmentService.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) { }
            }

            return View(departmentDto);
        }
    }
}

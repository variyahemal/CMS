using CMS.Services;
using CMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CMS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_service.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _service.GetById(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel vm)
        {
            _service.Update(vm);
            return View(vm);
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var viewModel = _service.GetById(Id);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel vm)
        {
            _service.Insert(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            _service.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}

using CMS.Services.IServices;
using CMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMS.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        public PostsController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_postService.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.category = new SelectList(_categoryService.GetAll(), "Id", "Title");
            var viewModel = _postService.GetById(Id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(PostViewModel vm)
        {
            var CreateDate = DateTime.Now;
            _postService.Update(vm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            ViewBag.category = new SelectList(_categoryService.GetAll(), "Id", "Title");
            var viewModel = _postService.GetById(Id);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.category = new SelectList(_categoryService.GetAll(), "Id", "Title");
            PostViewModel vm = new PostViewModel();
            vm.CreatedDate = DateTime.Now;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(PostViewModel vm)
        {
            _postService.Insert(vm);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            _postService.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
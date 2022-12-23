using CMS.Services.IServices;
using CMS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            return View(_postService.GetAll(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var category = _postService.GetById(Id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(PostViewModel vm)
        {
            _postService.Update(vm);
            return View(vm);
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            var viewModel = _postService.GetById(Id);
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
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
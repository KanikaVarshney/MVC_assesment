using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagement.Models;

namespace TrainingManagement.Controllers
{
    public class BatchController : Controller 
    {
        //InterfaceBatch _repo;
        //public BatchController(InterfaceBatch repo)
        //{
        //    _repo = repo;           
        //}
        //public IActionResult Index2()
        //{

        //    return View(_repo.GetBatches());
        //}
        //public IActionResult Create()
        //{
        //    // ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Role)));
        //    // ViewBag.Managers = new SelectList(Enum.GetValues(typeof(Manager)));
        //    ViewData["Courses"] = new SelectList(_repo.GetCourses(), "CourseId", "CourseName");

        //    return View();

        //}
        //[HttpPost]
        //public IActionResult Create(Batch batch)
        //{
        //    //var t = _repo.GetUsers();

        //    _repo.Create(batch);
        //    return RedirectToAction("Index2");
        //}
        InterfaceBatch _repo;
        InterfaceCourse _repo1;
        public BatchController(InterfaceBatch repo, InterfaceCourse repo1)
        {
            _repo = repo;
            _repo1 = repo1;
        }
        public IActionResult Index()
        {
            return View(_repo.GetBatches());
        }

        public IActionResult ShowBatches()
        {
            return View(_repo.GetBatches());
        }
        public IActionResult Details(int id)
        {
            return View(_repo.GetBatchById(id));
        }
        public IActionResult Edit(int id)
        {
            Batch obj = _repo.GetBatchById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(int id, Batch batch)
        {
            _repo.Edit(id, batch);
            return RedirectToAction("index");
        }
        public IActionResult Create()
        {
            ViewData["Courses"] = new SelectList(_repo1.GetCourses(), "CourseId", "CourseName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Batch batch)
        {
            _repo.Create(batch);
            return RedirectToAction("index");
        }
    }
}

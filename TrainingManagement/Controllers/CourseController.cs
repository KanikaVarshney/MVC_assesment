using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static TrainingManagement.Models.User;
using TrainingManagement.Models;

namespace TrainingManagement.Controllers
{
    public class CourseController : Controller
    {
        InterfaceCourse _repo;
        public CourseController(InterfaceCourse repo)
        {
            _repo = repo;
        }
        public IActionResult Index1()
        {

            return View(_repo.GetCourses());
        }
        public IActionResult GetCourses()
        {
            return View(_repo.GetCourses());
        }
        public IActionResult Create()
        {
           // ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Role)));
           // ViewBag.Managers = new SelectList(Enum.GetValues(typeof(Manager)));
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            //var t = _repo.GetUsers();

            _repo.Create(course);
            return RedirectToAction("Index1");
        }
        public IActionResult Edit(int id)
        {
           // ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Role)));

            //ViewBag.Managers = new SelectList(Enum.GetValues(typeof(Manager)));
            Course obj = _repo.GetCourseById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(int id, Course course )
        {
            Course obj = _repo.GetCourseById(id);
            if (obj != null)
                _repo.Edit(id, course);
            return RedirectToAction("Index1");

        }



        public IActionResult Delete(int id)
        {
           Course obj = _repo.GetCourseById(id);
            return View(obj);
        }



        [HttpPost]
        public IActionResult Deleted(int CourseId)
        {
            _repo.Delete(CourseId);
            return RedirectToAction("Index1");
        }

        public IActionResult Details(int id)
        {
            Course obj = _repo.GetCourseById(id);
            return View(obj);
        }

    }
}

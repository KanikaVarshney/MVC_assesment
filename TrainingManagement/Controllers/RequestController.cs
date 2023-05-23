using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingManagement.Models;

namespace TrainingManagement.Controllers
{
    public class RequestController : Controller
    {
        InterfaceRequest _repo;
        public RequestController(InterfaceRequest repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {

            return View(_repo.GetRequest());
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Request request)
        {
            //var t = _repo.GetUsers();

            _repo.Create(request);
            return RedirectToAction("Index");
        }
    }
}

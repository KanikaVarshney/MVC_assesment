using Microsoft.AspNetCore.Mvc;
using TrainingManagement.Repository;
using TrainingManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static TrainingManagement.Models.User;

namespace TrainingManagement.Controllers
{
    public class TrainingController : Controller
    {
        InterfaceUser _repo;
        public TrainingController(InterfaceUser repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {

            return View(_repo.GetUsers());
        }
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Role)));
            //ViewBag.Managers = new SelectList(Enum.GetValues(typeof(Manager)));
            ViewData["Managers"] =
                   new SelectList(_repo.GetUsers().Where(x => (int)x.UserRole == 1).ToList(),
                   "UserId", "UserName"

                   ); 
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            //var t = _repo.GetUsers();

            _repo.Create(user);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
             ViewBag.Roles = new SelectList(Enum.GetValues(typeof(Role)));

            //ViewBag.Managers = new SelectList(Enum.GetValues(typeof(Manager)));
            ViewData["ManagerId"] =
                   new SelectList(_repo.GetUsers().Where(x => (int)x.UserRole == 1).ToList(),
                   "UserId", "UserName"

                   );
            return View();
            User obj = _repo.GetUserById(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            User obj = _repo.GetUserById(id);
            if (obj != null)
                _repo.Edit(id,user);
            return RedirectToAction("Index");

        }
        


        public IActionResult Delete(int id)
        {
            User obj = _repo.GetUserById(id);
            return View(obj);
        }



        [HttpPost]
        public IActionResult Deleted(int UserId)
        {
            _repo.Delete(UserId);
            return RedirectToAction("index");
        }

        public IActionResult Details(int id)
        {
           User obj = _repo.GetUserById(id);
            return View(obj);
        }

        public IActionResult LoginSucessfully()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Authenticate the user
            var user = _repo.GetUserByUsernameAndPassword(username, password);

            if (user != null)
            {
                
               
                if ((int)user.UserRole == 1) // Replace with your logic to determine the role ID
                {
                    return RedirectToAction("Index"); // Redirect to the Manager's page
                }
                else if ((int)user.UserRole == 2) // Replace with your logic to determine the role ID
                {
                    return RedirectToAction("LoginSucessfully"); // Redirect to the Employee's page
                }

                /*return RedirectToAction("LoginSucessfully");*/

            }

            // Authentication failed
            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }


    }
}

using Class49.Web.Models;
using Class49.data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Class49.Web.Controllers
{
    public class HomeController : Controller
    {
        string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=People;Integrated Security=True";
        public IActionResult Index()
        {
            PersonDatabase db = new(connectionString);
            IndexViewModel vm = new(db.GetAll());
            return View(vm);
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(List<Person> people)
        {
            PersonDatabase db = new(connectionString);
            db.AddPeople(people);
            return Redirect("/home/index");
        }

    }
}
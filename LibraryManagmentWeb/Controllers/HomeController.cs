using LibraryManagmentWeb.Database;
using LibraryManagmentWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagmentWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Privacy()
		{
			return View();
		}
		[HttpGet]
		public IActionResult SignUp()
		{
			
			return View();
		}
		[HttpPost]
		public IActionResult SignIn(Librarian librarian)
		{
			LibrarianBase _librarian = new ();
			var status = _librarian.Librarians.FirstOrDefault(e => e.UserName == librarian.UserName &&
			e.Password == librarian.Password);
			if (status == null)
			{
				ViewBag.LoginStatus = 0;
			}
			else
			{
				return RedirectToAction("Welcome Again!", "Home", new { employee = status });
			}
			return View(librarian);
		}



		[HttpPost]
		public IActionResult Register(Librarian librarian)
		{
			LibrarianBase _librarian = new();

			if (ModelState.IsValid)
			{
				_librarian.Librarians.Add(librarian);
				return RedirectToAction("SuccessPage", "Home", new { employee = librarian });
			}

			return View(librarian);
		}









		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

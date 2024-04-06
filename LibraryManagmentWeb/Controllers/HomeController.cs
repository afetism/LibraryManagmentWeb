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
		public IActionResult SignIn(Librarian Librarian)
		{
			JsonHandler<Librarian> _librarian = new JsonHandler<Librarian>("Librarian.json");
			Librarian _ = new("a", "a", "a", "a");
			_librarian.Values.Add(_);
			Librarian status=null;
            foreach (var item in _librarian.Values)
            {
                if(item.UserName ==Librarian.UserName && item.Password ==Librarian.Password)
				{
					status = item;break;
				}
					

			}
            if (status == null)
			{
				ViewBag.LoginStatus = 0;
			}
			else
			{
				

				return RedirectToAction("MainMenu", "Home", new { librarian = status });
			}
			return View(Librarian);
		}


		[HttpPost]
		public IActionResult SignUp(Librarian Librarian)
		{
			JsonHandler<Librarian> _libr = new("Librarian.json");
			Librarian _ = new("b", "b", "b", "b");
			_libr.Values.Add(_);



			if (ModelState.IsValid)
			{
				_libr.Values.Add(Librarian);
				_libr.SaveData();
				return RedirectToAction("MainMenu", "Home", new { librarian = Librarian });
			}

			return View(Librarian);
		}

		
		public IActionResult MainMenu(Librarian librarian)
		{
			return View(librarian);
		}






		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

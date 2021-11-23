using DevSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DevSearch.Repository;

namespace DevSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private IRepository<Favorite> _repository = null;

		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
			_repository = new Repository<Favorite>();
		}

        [HttpGet]
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Index(Favorite favorite)
		{
			try
			{
				_repository.Insert(favorite);
				_repository.Save();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(favorite);
			}

		}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

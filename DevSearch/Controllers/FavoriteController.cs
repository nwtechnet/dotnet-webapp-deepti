using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevSearch.Repository;
using DevSearch.Models;

namespace DevSearch.Controllers
{
	public class FavoriteController : Controller
	{
		private IRepository<Favorite> _repository = null;

		public FavoriteController()
		{
			_repository = new Repository<Favorite>();
		}

		// GET: FavoriteController
		public ActionResult Index()
		{
			var favorites = _repository.GetAll();
			return View(favorites);
		}

		// GET: FavoriteController/Details/5
		public ActionResult Details( int id )
		{
			var favorite = _repository.GetById(id);
			return View(favorite);
		}

		// GET: FavoriteController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FavoriteController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Favorite favorite)
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

		// GET: FavoriteController/Edit/5
		public ActionResult Edit( int id )
		{
			var favorite = _repository.GetById(id);
			return View(favorite);
		}

		// POST: FavoriteController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Favorite favorite)
		{
			if (ModelState.IsValid)
			{
				_repository.Update(favorite);
				_repository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				return View(favorite);
			}

			//try
			//{
			//	return RedirectToAction(nameof(Index));
			//}
			//catch
			//{
			//	return View();
			//}
		}

		// GET: FavoriteController/Delete/5
		[HttpGet]
		public ActionResult Delete( int id )
		{
			var favorite = _repository.GetById(id);
			return View(favorite);
		}

		// POST: FavoriteController/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			var favorite = _repository.GetById(id);
			_repository.Delete(id);
			_repository.Save();
			return RedirectToAction("Index");
		}
	}
}

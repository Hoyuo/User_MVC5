using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace User.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Page1()
		{
			if (Request.IsAuthenticated)
			{
				return View();
			}
			return RedirectToAction("Index");

		}

		public ActionResult Page2()
		{
			return View();
		}

		public ActionResult Page3()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login()
		{
			FormsAuthentication.SetAuthCookie("TEST", false);
			return RedirectToAction("Page1", "Home");
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}

		public ActionResult MorePosts(int? count)
		{
			count = count ?? 3;
			return PartialView(count);
		}
	}
}
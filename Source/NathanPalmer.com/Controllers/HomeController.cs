using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NathanPalmer.com.Core.Domain;

namespace NathanPalmer.com.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IPostRepository postRepository;

        public HomeController(IPostRepository PostRepository)
        {
            postRepository = PostRepository;
        }

        public ActionResult Index()
        {
            ViewData["Title"] = "Home";
            ViewData.Model = postRepository.GetRecent(10);

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

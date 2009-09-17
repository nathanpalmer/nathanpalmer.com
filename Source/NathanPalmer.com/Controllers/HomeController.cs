using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NathanPalmer.com.Core.Domain;
using NathanPalmer.com.Core.Domain.Model;

namespace NathanPalmer.com.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly ITagRepository tagRepository;

        public HomeController(IPostRepository PostRepository, ITagRepository TagRepository)
        {
            postRepository = PostRepository;
            tagRepository = TagRepository;
        }

        public ActionResult Index()
        {
            

            //for (int i = 0; i < 10; i++)
            //{
            //    //var tag = tagRepository.GetByName("test1");
            //    //if (tag == null)
            //    //{
            //    //    tag = new Tag {Name = "test1"};
            //    //    tagRepository.Save(tag);
            //    //}

            //    var post = new Post();
            //    post.Subject = "Test 1";
            //    post.Body = "Body";                
            //    //post.Tags.Add(tag);
            //    post.Tags.Add(new Tag {Name = "test1"});
            //    postRepository.Save(post);
            //}

            ViewData["Title"] = "Home";
            ViewData.Model = postRepository.GetRecent(10);

            return View();
        }

        public ActionResult Generate()
        {
            for (int i = 0; i < 10; i++)
            {
                //var tag = tagRepository.GetByName("test1");
                //if (tag == null)
                //{
                //    tag = new Tag {Name = "test1"};
                //    tagRepository.Save(tag);
                //}

                var post = new Post();
                post.Subject = "Test 1";
                post.Body = "Body";
                //post.Tags.Add(tag);
                post.Tags.Add(new Tag { Name = "test1" });
                post.Tags.Add(new Tag { Name = "test2" });
                post.Tags.Add(new Tag { Name = "test3" });
                postRepository.Save(post);
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

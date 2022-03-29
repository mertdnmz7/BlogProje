using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogProje.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userProfile = new UserProfileManager();
        BlogManager bm = new BlogManager(new EfBlogDal());
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var profileValues = userProfile.GetAuthorByMail(p);
            return PartialView(profileValues);
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }

        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            List<SelectListItem> yazarlar = (from x in c.Authors.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AuthorName,
                                                 Value = x.AuthorID.ToString()
                                             }).ToList();
            ViewBag.yazarlar = yazarlar;
            ViewBag.values = values;

            
            return View(blog);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            bm.TUpdate(b);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            List<SelectListItem> yazarlar = (from x in c.Authors.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AuthorName,
                                                 Value = x.AuthorID.ToString()
                                             }).ToList();
            ViewBag.yazarlar = yazarlar;
            ViewBag.values = values;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.TAdd(b);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");

        }
    }
}
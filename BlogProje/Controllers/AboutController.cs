using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProje.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutContet = abm.GetList();
            return View(aboutContet);
        }
        public PartialViewResult Footer()
        {
            var aboutcontentList1= abm.GetList();
            return PartialView(aboutcontentList1);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autman = new AuthorManager(new EfAuthorDal());
            var authorList = autman.GetList();
            return PartialView(authorList);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutList = abm.GetList();
            return View(aboutList);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.AboutUpdate(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}
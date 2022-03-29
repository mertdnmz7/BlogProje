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
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager cm = new ContactManager(new EfContactDal());
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult AddContact(Contact p)
        {
            cm.TAdd(p);
            return View();
        }

        public ActionResult SendBox()
        {
            var messageList = cm.GetList();
            return View(messageList);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetByID(id);
            return View(contact);
        }
    }
}
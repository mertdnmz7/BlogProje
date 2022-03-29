using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager(new EfBlogDal());
        CommentManager cm = new CommentManager(new EfCommentDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {
            var bloglist = bm.GetList().ToPagedList(page,4);
            return PartialView(bloglist);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost() // Öne çıkan postlar
        {
            //1.Post
            var postTitle1 = bm.GetList().OrderByDescending(z=>z.BlogID).Where(x => x.CategoryID == 1).Select(s => s.BlogTitle).FirstOrDefault();

            var postImage1= bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(s => s.BlogImage).FirstOrDefault();

            var blogdate1= bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(s => s.BlogDate).FirstOrDefault();
            var blogpostid1= bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(s => s.BlogID).FirstOrDefault();

            //Viewbag
            ViewBag.postTitle = postTitle1;
            ViewBag.postImage = postImage1;
            ViewBag.blogDate = blogdate1;
            ViewBag.blogpostid1 = blogpostid1;

            //2.Post
            var postTitle2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(s => s.BlogTitle).FirstOrDefault();

            var postImage2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(s => s.BlogImage).FirstOrDefault();

            var blogdate2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(s => s.BlogDate).FirstOrDefault();
            var blogpostid2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(s => s.BlogID).FirstOrDefault();

            //Viewbag
            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.blogDate2 = blogdate2;
            ViewBag.blogpostid2 = blogpostid2;

            //3.Post
            var postTitle3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(s => s.BlogTitle).FirstOrDefault();

            var postImage3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(s => s.BlogImage).FirstOrDefault();

            var blogdate3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(s => s.BlogDate).FirstOrDefault();
            var blogpostid3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(s => s.BlogID).FirstOrDefault();

            //Viewbag
            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.blogDate3 = blogdate3;
            ViewBag.blogpostid3 = blogpostid3;

            //4.Post
            var postTitle4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(s => s.BlogTitle).FirstOrDefault();

            var postImage4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(s => s.BlogImage).FirstOrDefault();

            var blogdate4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(s => s.BlogDate).FirstOrDefault();
            var blogpostid4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(s => s.BlogID).FirstOrDefault();

            //Viewbag
            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.blogDate4 = blogdate4;
            ViewBag.blogpostid4 = blogpostid4;

            //5.Ortadaki Ana Post
            var postTitle5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(s => s.BlogTitle).FirstOrDefault();

            var postImage5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(s => s.BlogImage).FirstOrDefault();

            var blogdate5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(s => s.BlogDate).FirstOrDefault();
            var blogpostid5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(s => s.BlogID).FirstOrDefault();

            //Viewbag
            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.blogDate5 = blogdate5;
            ViewBag.blogpostid5 = blogpostid5;
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost() 
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails() // bloga ait veri...
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id) // routeconfig 'te id tanımlı oldugu için id yaptık.
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = bm.GetBlogByCategory(id);

            // Viewbag ile Kategori Adını taşıdım.
            var BlogCategoryName = bm.GetBlogByCategory(id).Select(y=>y.Category.CategoryName).FirstOrDefault();

            ViewBag.CategoryName = BlogCategoryName;

            // Viewbag ile kategorinin açıklamasını taşıdım.
            var BlogCategoryExp = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryExplation).FirstOrDefault();

            ViewBag.CategoryExp = BlogCategoryExp;

            return View(BlogListByCategory);
        }
        public ActionResult AdminBlogList()
        {
            var bloglist = bm.GetList();
            return View(bloglist);
        }
        // Farklı 2 tema kullanımı...
        public ActionResult AdminBlogList2()
        {
            var bloglist = bm.GetList();
            return View(bloglist);
        }

        [Authorize(Roles ="A")] // adminlere yetki verilmesi.
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
            return RedirectToAction("AdminBlogList");
        }

        public ActionResult DeleteBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            bm.TDelete(blog);
            return RedirectToAction("AdminBlogList");
        }
        
        public ActionResult UpdateBlog(int id)
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

            Blog blog = bm.GetByID(id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog b)
        {
            bm.TUpdate(b);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            
            var commentList = cm.CommentByBlog(id);
            return View(commentList);
        }

        public ActionResult AuthorBlogList(int id)
        {
            var blogs = bm.GetBlogByAuthor(id);
            return View(blogs);
        }

    }
}
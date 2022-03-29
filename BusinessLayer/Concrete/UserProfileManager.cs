using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repoUser = new Repository<Author>();
        Repository<Blog> repouserBlog = new Repository<Blog>();
        public List<Author> GetAuthorByMail(string p)
        {
            return repoUser.List(x => x.Mail == p);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repouserBlog.List(x => x.AuthorID == id);
        }
        public void EditAuthor(Author p)
        {
            Author author = repoUser.Find(x => x.AuthorID == p.AuthorID);
            author.AboutShort = p.AboutShort;
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;

            repoUser.Update(author);
        }
    }
}

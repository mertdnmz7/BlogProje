using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager: IAuthorServices
    {
        Repository<Author> repoAuthor = new Repository<Author>();

        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        //Yazarın  id degerine göre edit sayfasına taşıma   (ESKİ YÖNTEM)
        //public Author FindAuthor(int id)
        //{
        //    return repoAuthor.Find(x => x.AuthorID == id);
        //}

        public List<Author> GetList()
        {
            return _authorDal.List();
        }

        public void AuthorAdd(Author author)
        {
            _authorDal.Insert(author);
        }

        public Author GetByID(int id)
        {
            return _authorDal.GetByID(id);
        }

        public void AuthorDelete(Author author)
        {
            _authorDal.Delete(author);
        }

        public void AuthorUpdate(Author author)
        {
            _authorDal.Update(author);
        }
    }
}

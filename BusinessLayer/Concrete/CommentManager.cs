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
    public class CommentManager:ICommentServices
    {
        ICommentDal _commentDal;//field...

        Repository<Comment> repocomment = new Repository<Comment>();

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> CommentByBlog(int id)
        {
            return _commentDal.List(x => x.BlogID == id); 
        }

        public List<Comment> CommentByStatusTrue()
        {
            return _commentDal.List(x => x.CommentStatus == true);
        }
        public List<Comment> CommentStatusFalse()
        {
            return _commentDal.List(x => x.CommentStatus == false);
        }

        public void CommentAdd(Comment c)
        {
            //if (c.CommentText.Length <= 4 || c.CommentText.Length > 301 || c.UserName == "" || c.Mail == "" || c.UserName.Length <= 4)
            //    return -1;
            repocomment.Insert(c);
        }

        public void CommentStatusChangeToFalse(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentID == id);
            comment.CommentStatus = false;
            _commentDal.Update(comment);
        }

        public void CommentStatusChangeToTrue(int id)
        {
            Comment comment = _commentDal.Find(x => x.CommentID == id);
            comment.CommentStatus = true;
            _commentDal.Update(comment);
        }

        public List<Comment> GetList()
        {
            return _commentDal.List();
        }

        public Comment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void CommentDelete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void CommentUpdate(Comment comment)
        {
            throw new NotImplementedException();
        }

        // public int CommentStatus
    }
}

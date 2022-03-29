using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;


namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal: Repository<About>, IAboutDal
    {
    }
}

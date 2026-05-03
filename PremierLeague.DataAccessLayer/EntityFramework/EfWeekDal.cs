using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DataAccessLayer.Repository;
using PremierLeague.EntityLayer.Entities;


namespace PremierLeague.DataAccessLayer.EntityFramework
{
    public class EfWeekDal : GenericRepository<Week>, IWeekDal
    {
        public EfWeekDal(Context context) : base(context)
        {
        }
    }
}

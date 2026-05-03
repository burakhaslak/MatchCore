using PremierLeague.DataAccessLayer.Abstract;
using PremierLeague.DataAccessLayer.Concrete;
using PremierLeague.DataAccessLayer.Repository;
using PremierLeague.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.DataAccessLayer.EntityFramework
{
    public class EfSeasonDal : GenericRepository<Season>, ISeasonDal
    {
        public EfSeasonDal(Context context) : base(context)
        {
        }
    }
}

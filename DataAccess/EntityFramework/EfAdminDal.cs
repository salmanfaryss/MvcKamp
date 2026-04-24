using DataAcces.Repository.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfAdminDal:GenericRepository<Admin>,IAdminDal
    {
    }
}

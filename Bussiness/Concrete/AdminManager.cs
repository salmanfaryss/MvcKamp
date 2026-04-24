using Bussiness.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TDelete(Admin p)
        {
            _adminDal.Delete(p);
        }

        public Admin TGetAdmin(int id)
        {
           return _adminDal.GetById(id);
        }

        public List<Admin> TGetList()
        {
           return _adminDal.GetList();
        }

        public void TInsert(Admin p)
        {
            _adminDal.Insert(p);
        }

        public void TUpdate(Admin p)
        {
           _adminDal.Update(p);
        }
    }
}

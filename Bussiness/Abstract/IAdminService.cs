using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IAdminService
    {
        List<Admin> TGetList();
        void TInsert(Admin p);
        void TUpdate(Admin p);
        void TDelete(Admin p);
        Admin TGetAdmin(int id);

    }
}

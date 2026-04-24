using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IContactService
    {
        List<Contact> TGetList();
        void TInsert(Contact p);
        void TUpdate(Contact p);
        void TDelete(Contact p);
        Contact TGetByID(int id);
    }
}

using Bussiness.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(Contact p)
        {
           _contactDal.Delete(p);
        }

        public Contact TGetByID(int id)
        {
            return _contactDal.GetById(id);
        }

        public List<Contact> TGetList()
        {
            return _contactDal.GetList();
        }

        public void TInsert(Contact p)
        {
           _contactDal.Insert(p);
        }

        public void TUpdate(Contact p)
        {
            _contactDal.Update(p);
        }
    }
}

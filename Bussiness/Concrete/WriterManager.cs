using Bussiness.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void TDelete(Writer p)
        {
            _writerDal.Delete(p);
        }

        public Writer TGetByID(int id)
        {
           return _writerDal.GetById(id);
        }

        public List<Writer> TGetList()
        {
           return _writerDal.GetList();
        }

        public void TInsert(Writer p)
        {
           _writerDal.Insert(p);
        }

        public void TUpdate(Writer p)
        {
           _writerDal.Update(p);
        }
    }
}

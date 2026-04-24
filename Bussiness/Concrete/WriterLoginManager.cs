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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer TGetWriter(string username, string password)
        {
          return _writerDal.Get(x => x.WriterEmail == username && x.WriterPassword == password);
        }
    }
}

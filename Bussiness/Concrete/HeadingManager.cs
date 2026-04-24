using Bussiness.Abstract;
using DataAcces.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager( IHeadingDal heading)
        {
            _headingDal = heading;
        }

        public List<Heading> TGetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public List<Content> List(Expression<Func<Content, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Heading p)
        {
            p.Status = false;
            _headingDal.Update(p);
        }

        public Heading TGetById(int id)
        {
         return  _headingDal.GetById(id);
        }

        public List<Heading> TGetList()
        {
            return _headingDal.GetList();
        }

        public void TInsert(Heading p)
        {
            _headingDal.Insert(p);
        }

        public void TUpdate(Heading p)
        {
            //p.Status = true;
            _headingDal.Update(p);
        }
    }
}

using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IHeadingService
    {
        List<Heading> TGetList();
        void TInsert(Heading p);
        void TUpdate(Heading p);
        void TDelete(Heading p);
        Heading TGetById(int id);
        List<Heading> TGetListByWriter(int id);

        List<Content> List(Expression<Func<Content, bool>> filter);
    }
}

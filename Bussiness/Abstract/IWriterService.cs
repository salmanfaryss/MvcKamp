using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IWriterService
    {
        List<Writer> TGetList();
        void TInsert(Writer p);
        void TUpdate(Writer p);
        void TDelete(Writer p);
        Writer TGetByID(int id);

        //List<T> List(Expression<Func<T, bool>> filter);
    }
}

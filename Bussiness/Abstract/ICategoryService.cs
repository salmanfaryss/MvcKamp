using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
     public interface ICategoryService
    {
        List<Category> TGetList();
        void TInsert(Category p);
        void TUpdate(Category p);
        void TDelete(Category p);
        Category TGetById(int id);

        //List<T> List(Expression<Func<T, bool>> filter);
    }
}

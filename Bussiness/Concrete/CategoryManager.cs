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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(Category p)
        {
            _categoryDal.Delete(p);
        }

        public Category TGetById(int id)
        {
          return  _categoryDal.GetById(id);
        }

        public void TInsert(Category p)
        {
           _categoryDal.Insert(p);
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TUpdate(Category p)
        {
            _categoryDal.Update(p);
        }
    }
}

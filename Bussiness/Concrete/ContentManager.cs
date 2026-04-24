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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public void TDelete(Content p)
        {
            _contentDal.Delete(p);
        }

        public Content TGetById(int id)
        {
            return _contentDal.GetById(id);
        }

        public List<Content> TGetContentListByHeading(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> TGetList()
        {
           return _contentDal.GetList();
        }

        public List<Content> TGetListByWrier(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        public void TInsert(Content p)
        {
           _contentDal.Insert(p);
        }

        public void TUpdate(Content p)
        {
           _contentDal.Update(p);
        }
    }
}

using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IContentService
    {
        List<Content> TGetList();
        List<Content> TGetListByWrier(int id);
        List<Content>TGetContentListByHeading(int id);
        void TInsert(Content p);
        void TUpdate(Content p);
        void TDelete(Content p);
        Content TGetById(int id);
    }
}

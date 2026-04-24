using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IAboutService
    {
        List<About>TGetList();
        void TInsert(About p);
        void TUpdate(About p);
        void TDelete(About p);
    }
}

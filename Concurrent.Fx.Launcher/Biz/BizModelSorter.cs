using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz
{
    class BizModelSorter : IModelSorter<BizModel>
    {
        public IEnumerable<BizModel> Sort(IEnumerable<BizModel> original)
        {
            return original;
        }
    }
}

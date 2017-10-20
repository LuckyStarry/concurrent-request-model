using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Baz
{
    class BazAdapter : Adapter<BazResult>
    {
        public override BazResult CreateExceptionResult(Exception exception)
        {
            return new BazResult { Exception = exception };
        }

        public override BazResult CreateOperationCanceledResult(OperationCanceledException exception)
        {
            return new BazResult { Exception = exception };
        }
    }
}

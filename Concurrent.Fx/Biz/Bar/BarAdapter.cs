using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Bar
{
    class BarAdapter : Adapter<BarResult>
    {
        public override BarResult CreateExceptionResult(Exception exception)
        {
            return new BarResult { Exception = exception };
        }

        public override BarResult CreateOperationCanceledResult(OperationCanceledException exception)
        {
            return new BarResult { Exception = exception };
        }
    }
}

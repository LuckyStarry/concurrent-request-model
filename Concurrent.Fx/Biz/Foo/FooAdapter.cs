using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Foo
{
    class FooAdapter : Adapter<FooResult>
    {
        public override FooResult CreateExceptionResult(Exception exception)
        {
            return new FooResult { Exception = exception };
        }

        public override FooResult CreateOperationCanceledResult(OperationCanceledException exception)
        {
            return new FooResult { Exception = exception };
        }
    }
}

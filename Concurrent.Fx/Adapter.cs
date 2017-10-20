using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public abstract class Adapter<TResult> : IAdapter<TResult>
        where TResult : IResult
    {
        public abstract TResult CreateExceptionResult(Exception exception);
        public abstract TResult CreateOperationCanceledResult(OperationCanceledException exception);

        IResult IAdapter.CreateExceptionResult(Exception exception)
        {
            return this.CreateExceptionResult(exception);
        }

        IResult IAdapter.CreateOperationCanceledResult(OperationCanceledException exception)
        {
            return this.CreateOperationCanceledResult(exception);
        }
    }
}

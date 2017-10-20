using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public interface IAdapter
    {
        IResult CreateExceptionResult(Exception exception);
        IResult CreateOperationCanceledResult(OperationCanceledException exception);
    }

    public interface IAdapter<TResult> : IAdapter
        where TResult : IResult
    {
        new TResult CreateExceptionResult(Exception exception);
        new TResult CreateOperationCanceledResult(OperationCanceledException exception);
    }
}

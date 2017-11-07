using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public interface IAgent<TPayload, TModel>
    {
        IResult<TModel> Send(TPayload payload);
        Task<IResult<TModel>> SendAsync(TPayload payload, CancellationToken cancellationToken);
    }
}

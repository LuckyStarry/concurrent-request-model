using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public abstract class Agent<TPayload, TModel> : IAgent<TPayload, TModel>
    {
        public abstract IResult<TModel> Send(TPayload payload);
        public virtual async Task<IResult<TModel>> SendAsync(TPayload payload, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var task = Task.Run(() => this.Send(payload), cancellationToken);
                task.Wait(cancellationToken);
                return task.Result;
            });
        }
    }
}
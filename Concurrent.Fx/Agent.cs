using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public abstract class Agent<TResult> : IAgent
        where TResult : IResult
    {
        public abstract TResult Send(Payload payload);
        public virtual async Task<TResult> SendAsync(Payload payload, CancellationToken cancellationToken)
        {
            return await Task.Run(() => this.Send(payload), cancellationToken);
        }

        public abstract IAdapter<TResult> GetAdapter();

        IResult IAgent.Send(Payload payload)
        {
            return this.Send(payload);
        }

        async Task<IResult> IAgent.SendAsync(Payload payload, CancellationToken cancellationToken)
        {
            return await this.SendAsync(payload, cancellationToken);
        }

        IAdapter IAgent.GetAdapter()
        {
            return this.GetAdapter();
        }
    }
}
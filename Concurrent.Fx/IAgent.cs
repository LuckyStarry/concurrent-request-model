using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public interface IAgent
    {
        IResult Send(Payload payload);
        Task<IResult> SendAsync(Payload payload, CancellationToken cancellationToken);

        IAdapter GetAdapter();
    }
}

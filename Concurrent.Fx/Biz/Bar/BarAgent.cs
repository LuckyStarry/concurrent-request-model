using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Bar
{
    public class BarAgent : Agent<BarResult>
    {
        public override IAdapter<BarResult> GetAdapter()
        {
            return new BarAdapter();
        }

        public override BarResult Send(Payload payload)
        {
            new FakeRequest().Process(5);
            return new BarResult { };
        }

        public override async Task<BarResult> SendAsync(Payload payload, CancellationToken cancellationToken)
        {
            await new FakeRequest().ProcessAsync(5, cancellationToken);
            return new BarResult { };
        }
    }
}

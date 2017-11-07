using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Bar
{
    public class BarAgent : BizAgent
    {
        public override IResult<BizModel> Send(BizPayload payload)
        {
            new FakeRequest().Process(5);
            return new BizResult { };
        }

        public override async Task<IResult<BizModel>> SendAsync(BizPayload payload, CancellationToken cancellationToken)
        {
            await new FakeRequest().ProcessAsync(5, cancellationToken);
            return new BizResult { };
        }
    }
}

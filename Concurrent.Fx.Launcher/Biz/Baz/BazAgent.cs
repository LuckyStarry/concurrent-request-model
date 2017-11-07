using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Baz
{
    public class BazAgent : BizAgent
    {
        public override IResult<BizModel> Send(BizPayload payload)
        {
            new FakeRequest().Process(1);
            return new BizResult { };
        }
    }
}

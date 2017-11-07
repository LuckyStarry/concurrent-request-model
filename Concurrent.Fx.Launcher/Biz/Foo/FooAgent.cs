using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Foo
{
    public class FooAgent : BizAgent
    {
        public override IResult<BizModel> Send(BizPayload payload)
        {
            new FakeRequest().Process(8);
            return new BizResult { };
        }
    }
}

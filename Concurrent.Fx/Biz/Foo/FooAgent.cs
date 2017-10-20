using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Foo
{
    public class FooAgent : Agent<FooResult>
    {
        public override IAdapter<FooResult> GetAdapter()
        {
            return new FooAdapter();
        }

        public override FooResult Send(Payload payload)
        {
            new FakeRequest().Process(3);
            return new FooResult();
        }
    }
}

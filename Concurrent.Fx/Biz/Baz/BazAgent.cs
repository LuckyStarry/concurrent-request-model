using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Baz
{
    public class BazAgent : Agent<BazResult>
    {
        public override IAdapter<BazResult> GetAdapter()
        {
            return new BazAdapter();
        }

        public override BazResult Send(Payload payload)
        {
            new FakeRequest().Process(1);
            return new BazResult { IsSuccess = true };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz
{
    class BizCommand : Command<BizPayload, BizModel>
    {
        public BizCommand(BizAgent agent, BizContext context, string name)
            : base(agent, context, name)
        {
        }
    }
}

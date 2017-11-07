using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz
{
    public class BizContext : IContext<BizPayload, BizModel>
    {
        public BizPayload Payload { set; get; }

        public IDictionary<string, IEnumerable<BizModel>> Lists { get; } = new Dictionary<string, IEnumerable<BizModel>>();

        public IDictionary<string, Exception> Exceptions { get; } = new Dictionary<string, Exception>();
    }
}

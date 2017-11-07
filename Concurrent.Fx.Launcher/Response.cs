using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class Response
    {
        public IEnumerable<Biz.BizModel> Models { set; get; }
    }
}

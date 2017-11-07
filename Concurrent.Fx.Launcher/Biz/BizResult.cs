using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz
{
    public class BizResult : IResult<BizModel>
    {
        public List<BizModel> Models { set; get; }

        public IEnumerable<BizModel> GetRecords()
        {
            return this.Models ?? new List<BizModel>();
        }
    }
}

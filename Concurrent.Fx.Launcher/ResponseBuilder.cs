using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class ResponseBuilder : IResponseBuilder
    {
        private readonly Biz.BizContext context;

        public ResponseBuilder(Biz.BizContext context)
        {
            this.context = context;
        }

        public IModelSorter<Biz.BizModel> Sorter { set; get; } = new Biz.BizModelSorter();

        public Response Build()
        {
            var list = this.Sorter.Sort(this.context.Lists.SelectMany(item => item.Value));
            return new Response { Models = list };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class Invoker
    {
        public Response Execute(Biz.BizContext context, string[] names)
        {
            var builder = new Biz.BizCommandBuilder(context, Biz.BizCommandFactory.Instance);
            foreach (var name in names)
            {
                builder.Add(name);
            }
            var engine = new Engine();
            engine.Execute(builder);

            var response = new ResponseBuilder(context);
            return response.Build();
        }

        public async Task<Response> ExecuteAsync(Biz.BizContext context, CancellationToken cancellationToken, string[] names)
        {
            var builder = new Biz.BizCommandBuilder(context, Biz.BizCommandFactory.Instance);
            foreach (var name in names)
            {
                builder.Add(name);
            }
            var engine = new Engine();
            await engine.ExecuteAsync(builder, cancellationToken);

            var response = new ResponseBuilder(context);
            return response.Build();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class Command<TPayload, TModel> : ICommand
    {
        private readonly IAgent<TPayload, TModel> agent;
        private readonly IContext<TPayload, TModel> context;
        private readonly string name;

        public Command(IAgent<TPayload, TModel> agent, IContext<TPayload, TModel> context, string name)
        {
            this.agent = agent;
            this.context = context;
            this.name = name;
        }

        public void Execute()
        {
            try
            {
                var result = this.agent.Send(this.context.Payload);
                this.context.Lists[this.name] = result.GetRecords();
            }
            catch (Exception exception)
            {
                this.context.Exceptions[this.name] = exception;
            }
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                Logger.Record($"Command [{ this.name }] Executing");
                var result = await this.agent.SendAsync(this.context.Payload, cancellationToken);
                Logger.Record($"Command [{ this.name }] Executed");
                this.context.Lists[this.name] = result.GetRecords();
            }
            catch (Exception exception)
            {
                Logger.Record($"Command [{ this.name }] Exception: { exception.Message }");
                this.context.Exceptions[this.name] = exception;
            }
        }
    }
}
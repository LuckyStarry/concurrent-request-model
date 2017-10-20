using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class Command : ICommand
    {
        private readonly IAgent agent;
        private readonly Payload payload;
        private readonly Records records;

        public Command(IAgent agent, Payload payload, Records records)
        {
            this.agent = agent;
            this.payload = payload;
            this.records = records;
        }

        public void Execute()
        {
            Logger.Record($"Agent [{ this.agent.GetType() }] Begin");
            try
            {
                this.FillRecords(this.agent.Send(this.payload));
                Logger.Record($"Agent [{ this.agent.GetType() }] Success");
            }
            catch (Exception exception)
            {
                var adapter = this.agent.GetAdapter();
                this.FillRecords(adapter.CreateExceptionResult(exception));
                Logger.Record($"Agent [{ this.agent.GetType() }] Exception { exception.Message }");
            }
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Logger.Record($"Agent [{ this.agent.GetType() }] Begin");
            try
            {
                this.FillRecords(await this.agent.SendAsync(this.payload, cancellationToken));
                Logger.Record($"Agent [{ this.agent.GetType() }] Success");
            }
            catch (OperationCanceledException operationCanceledException)
            {
                var adapter = this.agent.GetAdapter();
                this.FillRecords(adapter.CreateOperationCanceledResult(operationCanceledException));
                Logger.Record($"Agent [{ this.agent.GetType() }] Canceled { operationCanceledException.Message }");
            }
            catch (Exception exception)
            {
                var adapter = this.agent.GetAdapter();
                this.FillRecords(adapter.CreateExceptionResult(exception));
                Logger.Record($"Agent [{ this.agent.GetType() }] Exception { exception.Message }");
            }
        }

        private void FillRecords(IResult result)
        {
            result.Fill(this.records);
        }
    }
}
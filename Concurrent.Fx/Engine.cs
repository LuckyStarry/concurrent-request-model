using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class Engine
    {
        public void Execute(ICommandBuilder builder)
        {
            var commands = builder.Build();
            this.Executer.Execute(commands);
        }

        public async Task ExecuteAsync(ICommandBuilder builder, CancellationToken cancellationToken)
        {
            var commands = builder.Build();
            await this.Executer.ExecuteAsync(commands, cancellationToken);
        }

        public IExecuter Executer { get; } = new Executer();
    }
}

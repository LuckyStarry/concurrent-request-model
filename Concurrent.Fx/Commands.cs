using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class Commands : ICommand
    {
        private readonly IEnumerable<ICommand> commands;

        public Commands(IEnumerable<ICommand> commands)
        {
            this.commands = new List<ICommand>(commands);
        }

        public void Execute()
        {
            foreach (var command in this.commands)
            {
                command.Execute();
            }
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var tasks = this.commands.Select(command => command.ExecuteAsync(cancellationToken));
            await Task.WhenAll(tasks);
        }
    }
}

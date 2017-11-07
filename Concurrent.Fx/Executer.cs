using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    class Executer : IExecuter
    {
        public void Execute(IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }

        public async Task ExecuteAsync(IEnumerable<ICommand> commands, CancellationToken cancellationToken)
        {
            var tasks = commands.Select(command => command.ExecuteAsync(cancellationToken));
            await Task.WhenAll(tasks);
        }
    }
}

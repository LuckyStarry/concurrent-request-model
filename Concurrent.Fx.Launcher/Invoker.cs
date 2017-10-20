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
        private Commands CreateCommands(Payload payload, Records records, params string[] commandNames)
        {
            var builder = new CommandsBuilder();
            foreach (var commandName in commandNames?.Distinct())
            {
                builder.Add(CommandFactory.Create(commandName, payload, records));
            }
            return builder.Build();
        }

        public Records Execute(Payload payload, params string[] commandNames)
        {
            var records = new Records();
            var commands = this.CreateCommands(payload, records, commandNames);
            commands.Execute();
            return records;
        }

        public async Task<Records> ExecuteAsync(Payload payload, CancellationToken cancellationToken, params string[] commandNames)
        {
            var records = new Records();
            var commands = this.CreateCommands(payload, records, commandNames);
            await commands.ExecuteAsync(cancellationToken);
            return records;
        }
    }
}

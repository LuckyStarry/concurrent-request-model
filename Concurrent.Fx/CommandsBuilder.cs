using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class CommandsBuilder
    {
        private readonly IList<ICommand> commands = new List<ICommand>();
        public CommandsBuilder Add(ICommand command)
        {
            this.commands.Add(command);
            return this;
        }

        public Commands Build()
        {
            return new Commands(this.commands);
        }
    }
}

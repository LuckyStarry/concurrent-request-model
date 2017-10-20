using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    static class CommandFactory
    {
        public static ICommand Create(string commandName, Payload payload, Records records)
        {
            if (agents.ContainsKey(commandName))
            {
                return new Command(agents[commandName], payload, records);
            }
            return null;
        }

        public static void Register(string commandName, IAgent agent)
        {
            agents[commandName] = agent;
        }

        private static IDictionary<string, IAgent> agents = new Dictionary<string, IAgent>();
    }
}

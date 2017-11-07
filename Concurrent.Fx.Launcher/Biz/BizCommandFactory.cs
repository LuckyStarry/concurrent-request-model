using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz
{
    class BizCommandFactory
    {
        private static volatile BizCommandFactory instance = null;
        private static object syncLock = new object();
        public static BizCommandFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new BizCommandFactory();
                        }
                    }
                }
                return instance;
            }
        }

        private BizCommandFactory()
        {
            this.agents = new Dictionary<string, BizAgent>();
        }

        public ICommand Create(string name, BizContext context)
        {
            var agent = this.agents[name];
            return new BizCommand(agent, context, name);
        }

        public void Register(string name, BizAgent agent)
        {
            agents[name] = agent;
        }

        public IDictionary<string, BizAgent> agents;
    }
}

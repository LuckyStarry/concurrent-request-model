using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz
{
    class BizCommandBuilder : ICommandBuilder
    {
        private readonly BizContext context;
        private readonly BizCommandFactory factory;

        public BizCommandBuilder(BizContext context, BizCommandFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }

        private IList<string> names = new List<string>();

        public BizCommandBuilder Add(string name)
        {
            this.names.Add(name);
            return this;
        }

        public IEnumerable<ICommand> Build()
        {
            foreach (var name in this.names)
            {
                yield return this.factory.Create(name, this.context);
            }
        }
    }
}

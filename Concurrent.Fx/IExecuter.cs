using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public interface IExecuter
    {
        void Execute(IEnumerable<ICommand> commands);
        Task ExecuteAsync(IEnumerable<ICommand> commands, CancellationToken cancellationToken);
    }
}

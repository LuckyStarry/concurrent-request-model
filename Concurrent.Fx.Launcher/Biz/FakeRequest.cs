using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz
{
    class FakeRequest
    {
        public void Process(int seconds)
        {
            for (var i = 0; i < seconds; i++)
            {
                Thread.Sleep(1000);
            }
        }

        public async Task ProcessAsync(int seconds, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                for (var i = 0; i < seconds * 10; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Thread.Sleep(100);
                }
            });
        }
    }
}

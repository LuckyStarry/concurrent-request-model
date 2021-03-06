﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public interface ICommand
    {
        void Execute();
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}

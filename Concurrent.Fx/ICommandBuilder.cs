﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public interface ICommandBuilder
    {
        IEnumerable<ICommand> Build();
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public interface IModelSorter<T>
    {
        IEnumerable<T> Sort(IEnumerable<T> original);
    }
}

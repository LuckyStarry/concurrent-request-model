﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concurrent.Fx
{
    public interface IResult<TModel>
    {
        IEnumerable<TModel> GetRecords();
    }
}
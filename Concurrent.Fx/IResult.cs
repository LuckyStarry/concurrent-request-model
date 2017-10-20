using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concurrent.Fx
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
        Exception Exception { get; }

        void Fill(Records records);
    }
}
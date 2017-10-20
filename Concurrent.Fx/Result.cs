using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public abstract class Result : IResult
    {
        public bool IsSuccess { set; get; }

        public string Message { set; get; }

        public Exception Exception { set; get; }

        public abstract void Fill(Records records);
    }
}

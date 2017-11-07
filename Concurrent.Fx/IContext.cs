using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concurrent.Fx
{
    public interface IContext<TPayload, TModel>
    {
        TPayload Payload { get; }
        IDictionary<string, IEnumerable<TModel>> Lists { get; }
        IDictionary<string, Exception> Exceptions { get; }
    }
}
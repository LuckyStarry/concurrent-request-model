using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Foo
{
    public class FooResult : Result
    {
        public override void Fill(Records records)
        {
            if (this.IsSuccess)
            {
                records.Foo = new FooRecord { Message = "Success" };
            }
            else
            {
                if (this.Exception != null)
                {
                    records.Foo = new FooRecord { Message = $"ERROR! { this.Exception.Message }" };
                }
                else
                {
                    records.Foo = new FooRecord { Message = $"FAILED! { this.Message }" };
                };
            }
        }
    }
}

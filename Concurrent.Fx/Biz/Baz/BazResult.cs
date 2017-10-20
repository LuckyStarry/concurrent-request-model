using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Baz
{
    public class BazResult : Result
    {
        public override void Fill(Records records)
        {
            if (this.IsSuccess)
            {
                records.Baz = new BazRecord { Message = "Success" };
            }
            else
            {
                if (this.Exception != null)
                {
                    records.Baz = new BazRecord { Message = $"ERROR! { this.Exception.Message }" };
                }
                else
                {
                    records.Baz = new BazRecord { Message = $"FAILED! { this.Message }" };
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx.Biz.Bar
{
    public class BarResult : Result
    {
        public override void Fill(Records records)
        {
            if (this.IsSuccess)
            {
                records.Bar = new BarRecord { Message = "Bar Success" };
            }
            else
            {
                if (this.Exception != null)
                {
                    records.Bar = new BarRecord { Message = $"Bar ERROR! { this.Exception.Message }" };
                }
                else
                {
                    records.Bar = new BarRecord { Message = $"Bar FAILED! { this.Message }" };
                };
            }
        }
    }
}

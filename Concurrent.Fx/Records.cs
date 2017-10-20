using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    public class Records
    {
        public Biz.Bar.BarRecord Bar { get; set; }
        public Biz.Foo.FooRecord Foo { get; set; }
        public Biz.Baz.BazRecord Baz { get; set; }
        public Biz.Qux.QuxRecord Qux { get; set; }
        //When you need append more record(s), just write here
    }
}

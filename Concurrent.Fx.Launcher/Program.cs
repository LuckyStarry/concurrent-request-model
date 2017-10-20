using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrent.Fx
{
    class Program
    {
        const string CMD_FOO = "foo";
        const string CMD_BAR = "bar";
        const string CMD_BAZ = "baz";

        static void Main(string[] args)
        {
            try
            {
                //Register Type
                CommandFactory.Register(CMD_FOO, new Biz.Foo.FooAgent());
                CommandFactory.Register(CMD_BAR, new Biz.Bar.BarAgent());
                CommandFactory.Register(CMD_BAZ, new Biz.Baz.BazAgent());

                //Composite Commands
                var invoker = new Invoker();
                var payload = new Payload();
                var commands = new string[] { CMD_FOO, CMD_BAR, CMD_BAZ };
                // Run synchronously
                //   invoker.Execute(payload, commands);

                // Run asynchronously
                var cancelcancelTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
                var records = invoker.ExecuteAsync(payload, cancelcancelTokenSource.Token, commands).Result;

                Logger.Record("Invoke Success");
                Logger.Record(JsonConvert.SerializeObject(records));
            }
            catch (Exception exception)
            {
                Logger.Record("Invoke Exception");
                Logger.Record(exception);
            }
            finally
            {
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}

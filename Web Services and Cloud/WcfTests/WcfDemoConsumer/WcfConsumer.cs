using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfDemoConsumer.ServiceReferenceTest;

namespace WcfDemoConsumer
{
    class WcfConsumer
    {
        static void Main()
        {
            TestServiceClient client = new TestServiceClient();

            var input = new Input()
                        {
                            X = 5,
                            Y = 3
                        };

            var result = client.Sum(input);

            Console.WriteLine(result);
        }
    }
}

using Samples.Examples.Factory;
using System;

namespace Samples
{
    public class StartExample
    {
        static void Main(string[] args)
        {
            new AbstractFactoryExample().Run();
            Console.ReadLine();
        }

    }
}

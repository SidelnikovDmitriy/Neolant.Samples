using Common.AbstractBase.Interfaces;
using System;

namespace Examples.PatternDetails
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}

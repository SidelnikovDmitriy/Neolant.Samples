using Common;
using Common.AbstractBase.Interfaces;
using Examples.PatternDetails;

namespace Examples.SOLID.SingleResponsibility
{
    public class SingleResponsibility : BaseExample
    {
        public SingleResponsibility() : base("(S) Принцип единственной обязанности", "SOLID Principles")
        {
        }

        public override void Run()
        {
            IPrinter printer = new ConsolePrinter();
            Report report = new Report();
            report.Text = "Hello Wolrd";
            report.Print(printer);
        }


    }
    
}

using Pattern.Details;
using System;

namespace Examples.Patterns
{
    public class CarFactoryGenerator
    {
        /// <summary>
        /// Возвращает произвольную 
        /// фаборику
        /// </summary>
        /// <returns></returns>
        public static CarFactory GetRandomFactory()
        {
            var youLucky = new Random().Next(0, 100) < 30;

            if (youLucky)
                return new PorscheAutomobilHolding();

            return new AutoVaz();
        }

    }
}

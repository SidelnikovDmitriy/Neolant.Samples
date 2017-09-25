using Common;
using Pattern.Details;
using System;
using System.Collections.Generic;

namespace Examples.Patterns
{
    public class BuilderExample : BaseExample
    {

        public BuilderExample() :
            base("Builder (Строитель)")
        {
        }

        public override void Run()
        {
            var builders = new List<BuilderBase>()
            {
                new ConcreteBuildingBuilder(),
                new WoodenBuildingBuilder(),
                new YourBuildingBuilder()
            };

            //билдеры
            foreach (var builder in builders)
            {
                //застройщик
                var builderFactory = new BuildingFactory(builder);
                //застройщик построил здание
                var building = builderFactory.Create();
                //показываю
                Show(building);
            }

        }
        /// <summary>
        /// Показываем здание
        /// </summary>
        /// <param name="building"></param>
        private void Show(Building building)
        {
            Console.WriteLine(building);
        }
    }
}

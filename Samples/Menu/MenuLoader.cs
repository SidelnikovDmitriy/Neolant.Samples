using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Examples;

namespace Samples.Menu
{
    public class MenuLoader : IMenuItemsLoader
    {

        /// <summary>
        /// Загрузка пунктов меню
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BaseExample> GetMenuItems()
        {

            Example.Init();

            var tempMenu = new List<BaseExample>();


            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            //запоняем меню динамически
            foreach (var assembly in assemblies)
            {
                //выбираем классы с типом BaseExample
                var types = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(BaseExample))).ToArray();

                foreach (var type in types)
                {
                    var instance = Activator.CreateInstance(type) as BaseExample;

                    if (instance == null) continue;

                    tempMenu.Add(instance);
                }
            }

            return tempMenu.OrderBy(i => i.Group).ToList();
        }
    }
}

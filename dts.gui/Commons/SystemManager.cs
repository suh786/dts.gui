﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;

namespace dts.gui.Commons
{
    public static class SystemManager
    {
        private static CompositionContainer _container;

        static SystemManager()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(SystemManager).Assembly));
            // catalog.Catalogs.Add(new DirectoryCatalog("C:\\Users\\SomeUser\\Documents\\Visual Studio 2010\\Projects\\SimpleCalculator3\\SimpleCalculator3\\Extensions"));


            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);
        }

        public static void InjectServices(object obj)
        {
            try
            {
                _container.ComposeParts(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}

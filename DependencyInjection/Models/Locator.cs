using SingletonToDependencyInjection.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Models
{
    public class Locator : LocatorBase
    {
        private static Locator? _instance;

        internal static Locator Instance
        {
            get
            {
                return _instance ?? (_instance = new Locator());
            }
        }

        public IService1 Service1
        {
            get
            {
                return Container.GetService<IService1>();
            }
        }

        public Service2 Service2
        {
            get
            {
                return Container.GetService<Service2>();
            }
        }

        public Service3 Service3
        {
            get
            {
                return Container.GetService<Service3>();
            }
        }

        private Locator()
        {
        }

        protected override void ConfigureService()
        {
            Container.Register<IService1, Service1>();
            Container.Register<Service2>();
            Container.Register<Service3>();
        }
    }
}

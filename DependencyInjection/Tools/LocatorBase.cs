using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Tools
{
    public abstract class LocatorBase
    {
        private readonly ISimpleIOC _container;

        protected ISimpleIOC Container
        {
            get
            {
                return _container;
            }
        }

        protected LocatorBase()
        {
            _container = new SimpleIOC();
            ConfigureService();
        }

        protected abstract void ConfigureService();
    }
}

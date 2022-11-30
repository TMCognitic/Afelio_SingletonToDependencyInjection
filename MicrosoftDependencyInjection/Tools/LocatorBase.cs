using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Tools
{
    public abstract class LocatorBase
    {
        private readonly IServiceProvider _container;

        public IServiceProvider Container
        {
            get
            {
                return _container;
            }
        }

        protected LocatorBase()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureService(services);
            _container = services.BuildServiceProvider();
        }

        protected abstract void ConfigureService(IServiceCollection services);
    }
}

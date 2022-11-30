using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Tools
{
    public interface ISimpleIOC
    {
        void Register<TService>();
        void Register<TService, TConcrete>()
            where TConcrete : TService;
        void Register<TService>(Func<TService> builder);
        void Register<TService, TConcrete>(Func<TConcrete> builder)
            where TConcrete : TService;

        TService GetService<TService>();
        //object GetService(Type serviceType);
    }
}

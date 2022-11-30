using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Tools
{
    internal class SimpleIOC : ISimpleIOC
    {
        //Dictionnaire d'instances
        private readonly IDictionary<Type, object?> _instances;
        //Dictionnaire builders
        private readonly IDictionary<Type, Func<object>> _builders;
        //Dictionnaire Mapping
        private readonly IDictionary<Type, Type> _mappers;

        public SimpleIOC()
        {
            _instances = new Dictionary<Type, object?>();
            _builders = new Dictionary<Type, Func<object>>();
            _mappers = new Dictionary<Type, Type>();
        }

        public void Register<TService>()
        {
            _instances.Add(typeof(TService), null);
        }

        public void Register<TService, TConcrete>() 
            where TConcrete : TService
        {
            Register<TService>();
            _mappers.Add(typeof(TService), typeof(TConcrete));
        }

        public void Register<TService>(Func<TService> builder)
        {
            if (builder is null)
                throw new ArgumentNullException(nameof(builder));

            Register<TService>();
            _builders.Add(typeof(TService), () => builder()!);
        }

        public void Register<TService, TConcrete>(Func<TConcrete> builder)
            where TConcrete : TService
        {
            Register<TService>();
            _builders.Add(typeof(TService), () => builder()!);
        }

        public TService GetService<TService>()
        {
            Type serviceType = typeof(TService);
            if (!_instances.ContainsKey(serviceType))
                throw new InvalidOperationException("Register your service before use it...");


            return (TService)(_instances[serviceType] ??= GetService(serviceType));
        }

        private object GetService(Type serviceType)
        {
            if (_instances.ContainsKey(serviceType) && _instances[serviceType] is not null)
            {
                return _instances[serviceType]!;
            }

            Type concreteService = serviceType;

            if(_builders.ContainsKey(serviceType))
            {
                return _builders[concreteService].Invoke();
            }

            if(_mappers.ContainsKey(concreteService))
            {
                concreteService = _mappers[concreteService];
            }

            ConstructorInfo? constructorInfo = concreteService.GetConstructors().SingleOrDefault();

            if(constructorInfo is not null)
            {
                object[] parameters = constructorInfo.GetParameters()
                                                     .Select(p => GetService(p.ParameterType))
                                                     .ToArray();

                return constructorInfo.Invoke(parameters);
            }

            PropertyInfo? propertyInfo = concreteService.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);

            if(propertyInfo is not null)
            {
                MethodInfo? getMethod = propertyInfo.GetMethod;
                
                if(propertyInfo.GetMethod is null)
                {
                    throw new InvalidOperationException("");
                }

                object? value = propertyInfo.GetMethod.Invoke(null, null);

                if(value is null)
                {
                    throw new InvalidOperationException($"The singleton of '{concreteService.FullName}' return a null value");
                }

                return value;
            }

            FieldInfo? fieldInfo = concreteService.GetField("Instance", BindingFlags.Public | BindingFlags.Static);

            if (fieldInfo is not null)
            {
                object? value = fieldInfo.GetValue(null);

                if (value is null)
                {
                    throw new InvalidOperationException($"The singleton of '{concreteService.FullName}' return a null value");
                }

                return value;
            }

            throw new InvalidOperationException($"Can't resolve the type '{concreteService.FullName}'");
        }
    }
}

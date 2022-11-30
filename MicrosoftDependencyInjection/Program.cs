
using Microsoft.Extensions.DependencyInjection;
using SingletonToDependencyInjection.Models;

IService1? service1 = Locator.Instance.Service1;
IService1? service1bis = Locator.Instance.Service1;

Service2? service2 = Locator.Instance.Service2;
Service2? service2bis = Locator.Instance.Service2;

Service3? service3 = Locator.Instance.Service3;
Service3? service3bis = Locator.Instance.Service3;

Console.WriteLine(ReferenceEquals(service1, service1bis));
Console.WriteLine(ReferenceEquals(service2, service2bis));
Console.WriteLine(ReferenceEquals(service3, service3bis));


Locator.Instance.Container.CreateScope()


using SingletonToDependencyInjection.Models;

Service1 service1 = Locator.Instance.Service1;
Service1 service1bis = Locator.Instance.Service1;

Console.WriteLine(ReferenceEquals(service1, service1bis));

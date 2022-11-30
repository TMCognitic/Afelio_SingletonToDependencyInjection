
using SingletonToDependencyInjection.Models;

Service1 service1 = Service1.Instance;
Service1 service1bis = Service1.Instance;

Console.WriteLine(ReferenceEquals(service1, service1bis));

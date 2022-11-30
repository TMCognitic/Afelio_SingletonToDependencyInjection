using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Models
{
    public class Service1 : IService1
    {
        public void M1()
        {
            Console.WriteLine("M1 de Service 1");
        }
    }
}

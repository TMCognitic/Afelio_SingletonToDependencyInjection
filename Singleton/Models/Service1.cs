using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Models
{
    public class Service1
    {
        public static Service1 Instance = new Service1();

        private Service1()
        {

        }
    }
}

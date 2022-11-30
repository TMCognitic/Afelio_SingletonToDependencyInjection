using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Models
{
    public class Service3
    {
        private static Service3? _instance;

        public static Service3 Instance
        {
            get
            {
                return _instance ??= new Service3();
            }
        }

        private Service3()
        {
        }
    }
}

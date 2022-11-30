using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Models
{
    public class Service2
    {
        private static Service2? _instance;

        internal static Service2 Instance
        {
            get
            {
                return _instance ?? (_instance = new Service2());
            }
        }

        private Service2() 
        {
        }
    }
}

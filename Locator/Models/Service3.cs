using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Models
{
    public class Service3
    {
        private readonly Service1 _service;

        public Service3(Service1 service)
        {
            _service = service;
        }
    }
}

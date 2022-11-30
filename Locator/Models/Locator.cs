using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonToDependencyInjection.Models
{
    public class Locator
    {
        private static Locator? _instance;

        internal static Locator Instance
        {
            get
            {
                return _instance ?? (_instance = new Locator());
            }
        }

        private Service1? _service1;
        private Service2? _service2;
        private Service3? _service3;

        public Service1 Service1
        {
            get
            {
                return _service1 ??= new Service1();
            }
        }

        public Service2 Service2
        {
            get
            {
                return _service2 ??= new Service2();
            }
        }

        public Service3 Service3
        {
            get
            {
                return _service3 ??= new Service3(Service1);
            }
        }

        private Locator()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gniazdowy
{
    class Task
    {
        public int id { get; set; }
        private static int nextId = 1;

        public int start { get; set; }
        public int stop { get; set; }

        public Task()
        {
            id = nextId++;
        }
    }
}

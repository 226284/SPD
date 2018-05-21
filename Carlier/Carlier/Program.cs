using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlier
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Carlier carlier = new Carlier();

                Console.WriteLine(carlier.Carlier_Run());
                Console.WriteLine();

                Console.ReadKey();
            }
        }
    }
}

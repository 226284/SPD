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
            File file = new File();
            Schrage schrage = new Schrage(file);
            PreSchrage preSchrage = new PreSchrage(file);
            int a, b, c;
            int U, LB, UB;

            //Console.WriteLine(schrage.SchrageRun());
            //Console.WriteLine(preSchrage.PreSchrageRun());
            //Console.ReadKey();

            U = schrage.SchrageRun(); //permutacja pi
        }
    }
}

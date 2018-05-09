using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlier
{
    class Carlier
    {
        public List<Task> permutacje;
        public int a, b, c;
        public int U, LB, UB;

        public File file;

        public Carlier()
        {
            file = new File();
        }

        public int Carlier_Run()
        {
            int cmax = 0;

            Schrage schrage = new Schrage(file);
            U = schrage.SchrageRun(); //permutacja pi
            b = schrage.b; //znajdowanie b
            c = schrage.c;

            // znajdowanie a
            int a = b;



            Console.WriteLine("a:{0} b:{1} c:{2}", a, b, c);
            PreSchrage preSchrage = new PreSchrage(file);


            return cmax;
        }

    }
}

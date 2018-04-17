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

            // znajdowanie a
            int a = b;
            Task tmp1 = new Task(0, 0, 0);
            Task tmp2 = new Task(0, 0, 0);
            Task tmp3 = new Task(0, 0, 0);

            tmp1 = schrage.Permutacje.Find(x => x.id == a);
            tmp2 = schrage.Permutacje.Find(x => x.id == a - 1);
            tmp3 = schrage.Permutacje.Find(x => x.id == a - 2);
            while ((a >= 2) && ((Math.Max(tmp2.r, tmp3.r + tmp3.p) + tmp2.p) >= tmp1.r))
            {
                a--;
                tmp1 = schrage.Permutacje.Find(x => x.id == a);
                tmp2 = schrage.Permutacje.Find(x => x.id == a - 1);
                tmp3 = schrage.Permutacje.Find(x => x.id == a - 2);
            }
            a--;

            Console.WriteLine("a:{0} b:{1} c:{2}", a, b, c);
            PreSchrage preSchrage = new PreSchrage(file);


            return cmax;
        }

    }
}

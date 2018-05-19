using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlier
{
    class Carlier
    {
        public List<Task> opt; // optymalna permutacja
        public List<Task> act; // aktualna permutacja
        public int a, b, c;
        public int U, LB, UB;
        public int rr, pp, qq;

        public File file;

        public Carlier()
        {
            file = new File();
            act = file.listOfTasks;

            UB = 100000000;
        }

        public int Carlier_Run()
        {
            int cmax = 0;
            int rtmp;
            int qtmp;

            Schrage schrage = new Schrage(act);
            var tmp = schrage.SchrageRun();
            b = schrage.b;

            if (tmp < UB)
            {
                opt = act;
                UB = tmp;
                Console.WriteLine("Checkpoint 1");
            }

            List<Task> tmp_act = new List<Task>();
            foreach (Task t in act)
            {
                tmp_act.Add(t);
            }

            a = Find_a();
            c = Find_c();

            Console.WriteLine("a:{0} b:{1} c:{2}", a, b, c);

            if (c != 0)
            {
                Console.WriteLine("Checkpoint 2");

                rr = 100000000;
                qq = 100000000;
                pp = 0;

                for (int i = c + 1; i <= b; i++)
                { //tu wyznaczamy r', q', p' do nadpisywania
                    if (act[i].r < rr)
                    {
                        rr = act[i].r;
                    }
                    if (act[i].q < qq)
                    {
                        qq = act[i].q;
                    }
                    pp += act[i].p;
                }
                rtmp = act[c].r; //nadpisuje r w zad int
                act[c].r = (Math.Max(rtmp, rr + pp)); //podstawiamy r' w zadaniu interferencyjnym
                PreSchrage preSchrage = new PreSchrage(act);
                if (preSchrage.PreSchrageRun() < UB)
                {
                    Console.WriteLine("Checkpoint 3");

                    Carlier_Run();
                }
                //przywracam aktualną permutację w iteracji
                //Collections.copy(act, act);
                qtmp = act[c].q; //nadpisuje q w zad int
                act[c].q = Math.Max(qtmp, qq + pp); //podstawiamy q' w zadaniu interferencyjnym
                if (new PreSchrage(act).PreSchrageRun() < UB)
                {
                    Console.WriteLine("Checkpoint 4");

                    Carlier_Run();
                }
                //przywracam aktualną permutację w iteracji
                //Collections.copy(act, act);
            }
            return UB;            //algorytm Caliera zwraca optymalna liczbe permutacji
        }

        public int Find_a()
        {
            Task tmp1;
            Task tmp2;
            Task tmp3;

            int a = b;
            tmp1 = act[a];
            tmp2 = act[a - 1];
            tmp3 = act[a - 2];
            while ((a >= 2) && ((Math.Max(tmp2.r, tmp3.r + tmp3.p) + tmp2.p) >= tmp1.r))
            {
                a--;
                tmp1 = act[a];
                tmp2 = act[a - 1];
            }
            a--;
            return a;
        }

        public int Find_c()
        {
            Task tmp1;
            Task tmp2 = act[b];
            int c = 0;
            for (int i = b - 1; i >= a; i--)
            {
                tmp1 = act[i];
                if (tmp1.q < tmp2.q)
                {
                    c = i;
                    return c;
                }
            }
            return c;
        }
    }
}

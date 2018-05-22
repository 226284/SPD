using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlier
{
    class Carlier
    {
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
            int rtmp;
            int qtmp;

            foreach (Task t in act)
            {
                Console.WriteLine(t.ToString());
            }

            Schrage schrage = new Schrage(act); //
            var tmp_cmax = schrage.SchrageRun();
            b = schrage.b;
            Console.WriteLine("Schrage:  " + tmp_cmax);

            act.Clear();
            act = schrage.Permutacje;

            if (tmp_cmax < UB)
            {
                UB = tmp_cmax;
            }

            List<Task> tmp_act = new List<Task>();
            foreach (Task t in act)
            {
                tmp_act.Add(t.Clone());
            }

            a = Find_a();
            c = Find_c();

            Console.WriteLine("a:{0} b:{1} c:{2}", a, b, c);

            if (c != 0)
            {
                rr = 100000000;
                qq = 100000000;
                pp = 0;

                for (int i = c + 1; i <= b; i++)
                { //wyznaczamy r', q', p'
                    if (act[i].r < rr)
                    {
                        rr = act[i].r;
                    }
                    if (act[i].q < qq)
                    {
                        qq = act[i].q;
                    }
                    pp = pp + act[i].p;
                }

                rtmp = act[c].r;
                act[c].r = (Math.Max(rtmp, (rr + pp)));

                ///////////////////////////////////////////////////////////////////
                List<Task> pre = new List<Task>();
                foreach (Task t in act)
                {
                    pre.Add(t.Clone());
                }
                if (new PreSchrage(pre).PreSchrageRun() < UB) // here
                {
                    Carlier_Run(); //rekt
                }
                act.Clear();
                // Przywracanie
                foreach (Task t in tmp_act)
                {
                    act.Add(t.Clone());
                }

                qtmp = act[c].q;
                act[c].q = Math.Max(qtmp, (qq + pp));

                //////////////////////////////////////////
                List<Task> pre2 = new List<Task>();
                foreach (Task t in act)
                {
                    pre2.Add(t.Clone());
                }
                Console.WriteLine("UB: " + UB);
                var tmppp = new PreSchrage(pre2).PreSchrageRun();  //here
                foreach (Task t in act)
                {
                    Console.WriteLine(t.ToString());
                }

                Console.WriteLine("PRE:  " + tmppp.ToString());
                if (tmppp < UB)
                {
                    Console.WriteLine("Checkpoint 4");
                    Carlier_Run(); //rekt
                }
                act.Clear();
                // Przywracanie
                foreach (Task t in tmp_act)
                {
                    act.Add(t.Clone());
                }

            }
            return UB;
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

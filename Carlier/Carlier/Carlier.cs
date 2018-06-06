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
        //public int a=0, b=0, c=0;
        public int UB;
        //public int rr, pp, qq;
        public Schrage schrage;
        public PreSchrage preSchrage;

        public File file;

        public Carlier()
        {
            file = new File();
            act = file.listOfTasks;
           // schrage = new Schrage(act);
            preSchrage = new PreSchrage(act);

            UB = 100000000;
        }

        public int Carlier_Run()
        {

            int nr_c = 0;
            int r_c = 0;
            int p_sum = 0;
            int q_c = 0;
            int r_new_for_c = 1000000;
            int q_new_for_c = 1000000;
            int a=0, b=0, c=-1;
            int U = 0, LB = 0;

            schrage = new Schrage(act); 
            U = schrage.SchrageRun();

            if (U < UB)
            {
                UB = U;
            }

            b = Find_b(a,b,c);
            a = Find_a(a, b, c);
            c = Find_c(a, b, c);

            if (c == -1)
                return UB;

            Console.WriteLine("Schrage:  " + U);

            //foreach (Task t in act)
            //{
            //    Console.WriteLine(t.ToString());
            //}

            //act.Clear();
            //act = schrage.Permutacje;

            //foreach (Task t in act)
            //{
            //    Console.WriteLine(t.ToString());
            //}

            nr_c = act[c].id;
            for(int i = c + 1; i <= b; i++)
            {
                r_new_for_c = Math.Min(r_new_for_c, act[i].r);
                p_sum += act[i].p;
                q_new_for_c = Math.Min(q_new_for_c, act[i].q);
            }
            r_c = act[c].r;
            q_c = act[c].q;

            act[c].r = Math.Max(act[c].r, r_new_for_c + p_sum);
            LB = preSchrage.PreSchrageRun();

            if (LB < UB)
                Carlier_Run();

            for(int i = 0; i < file.numberOfTasks; i++)
            {
                if (nr_c == act[i].id)
                    act[i].r = r_c;
            }

            act[c].q = Math.Max(act[c].q, q_new_for_c + p_sum);

            LB = preSchrage.PreSchrageRun();

            if (LB < UB)
                Carlier_Run();

            for (int i = 0; i < file.numberOfTasks; i++)
            {
                if (nr_c == act[i].id)
                    act[i].q = q_c;
            }

            Console.WriteLine(UB);

            return UB;
        }




        public int Find_a(int a,int b, int c)
        {
            int sumOfA = 0;
            for (a = 0; a <= b; a++)
            {
                sumOfA = 0;
                    for(int i = a; i <= b; i++)
                {
                    sumOfA += act[i].p;
                }

                    if(schrage.cMax == (act[a].r + sumOfA + act[b].q))
                {
                    return a;
                }
            }
            return a;
        }

        public int Find_b(int a, int b, int c)
        {
            b = file.numberOfTasks - 1;

            for (int i = file.numberOfTasks - 1; i > 0; i--)
            {
                if (schrage.cMax == (act[i].C + act[i].q))
                {
                    b = i;
                    break;
                }
            }
            return b;
        }


        public int Find_c(int a, int b, int c)
        {
            c = -1;

            for(int i = b; i >= a; i--)
            {
                if(act[i].q < act[b].q)
                {
                    c = i;
                    break;
                }
            }
            return c;
        }

    }
}

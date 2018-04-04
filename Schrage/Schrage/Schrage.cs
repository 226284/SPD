using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrage
{
    class Schrage
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        SimplePriorityQueue<Task> N = new SimplePriorityQueue<Task>();
        SimplePriorityQueue<Task> G = new SimplePriorityQueue<Task>(new Comparison<float>((i1, i2) => i2.CompareTo(i1)));

        public int Schrage_run(File file)
        {
            foreach (Task t in file.listOfTasks)
            {
                Console.WriteLine(t.r.ToString() + " " + t.p.ToString() + " " + t.q.ToString());
            }

            //przepisywanie zawartości
            foreach (Task t in file.listOfTasks)
            {
                N.Enqueue(t, t.r);
            }

            int time = 0, step = 0, cMax = 0, tTemp = 0;
            while (G.Count != 0 || N.Count != 0)
            {
                Label:
                while (N.Count != 0 && N.First.r <= time)
                {
                    var tmp = N.Dequeue();
                    G.Enqueue(tmp, tmp.q);
                }

                if (G.Count == 0)
                {
                    time = N.First.r;
                    goto Label;
                }

                var x = G.First;

                G.Dequeue();

                step = step + 1;
                //tTemp = time;
                time = time + x.p;
                cMax = Math.Max(cMax, time + x.q);

                if(cMax <= time + x.q)
                {
                    cMax = time + x.q;
                    b = step;
                }
            }

            Console.WriteLine("toooo:");

            Console.WriteLine(cMax);

            return cMax;
        }
    }
}

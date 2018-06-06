using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlier
{
    class PreSchrage
    {
        public SimplePriorityQueue<Task> N = new SimplePriorityQueue<Task>();
        public SimplePriorityQueue<Task> G = new SimplePriorityQueue<Task>(new Comparison<float>((i1, i2) => i2.CompareTo(i1)));
        public int cMax;
        public PreSchrage(List<Task> tasks)
        {
            ListToQueue(tasks);
        }

        public void ListToQueue(List<Task> tasks)
        {
            foreach (Task t in tasks)
            {
                N.Enqueue(t, t.r);
            }
        }

        public int PreSchrageRun()
        {
            //inicjacja wszystkich zmiennych
            int time = 0;
            cMax = 0;
            Task e = new Task(0, 0, 0,0);
            Task l = new Task(0, 0, 0,0);

            while (G.Count != 0 || N.Count != 0)
            {

                Label:
                while (N.Count != 0 && N.First.r <= time)
                {
                    e = N.First;
                    G.Enqueue(e, e.q);
                    N.Dequeue();
                    if (e.q > l.q)
                    {
                        l.p = time - e.r;
                        time = e.r;
                        if (l.p > 0)
                        {
                            G.Enqueue(l, l.q);
                        }
                    }

                }

                if (G.Count == 0)
                {
                    time = N.First.r;
                    goto Label;
                }

                e = G.First;

                G.Dequeue();

                //step = step + 1;
                l = e;
                //tTemp = time;
                time = time + e.p;
                cMax = Math.Max(cMax, time + e.q);
            }
            return cMax;
        }
    }
}

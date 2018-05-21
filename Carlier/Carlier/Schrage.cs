﻿using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlier
{
    class Schrage
    {
        public SimplePriorityQueue<Task> N = new SimplePriorityQueue<Task>();
        public SimplePriorityQueue<Task> G = new SimplePriorityQueue<Task>(new Comparison<float>((i1, i2) => i2.CompareTo(i1)));
        public int b;
        public List<Task> Permutacje;

        public Schrage(List<Task> file)
        {
            ListToQueue(file);
            Permutacje = new List<Task>();
        }

        public void ListToQueue(List<Task> tasks)
        {
            foreach (Task t in tasks)
            {
                N.Enqueue(t, t.r);
            }
        }

        public int SchrageRun()
        {
            //N = file.N;
            int time = 0, step = 0, cMax = 0, tTemp = 0, k = 0;
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

                Task task = G.Dequeue();
                Permutacje.Add(task);
                step = step + 1;
                //tTemp = time;
                time = time + x.p;
                cMax = Math.Max(cMax, time + x.q);

                // wyznaczenie b - końca ścieżki krytyczniej
                if (cMax <= time + x.q)
                {
                    cMax = time + x.q;
                    b = k;
                }
                k++;
            }
            return cMax;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carlier
{
    public class Task
    {
        public int r; //termin dostępności
        public int p; //czas obsługi
        public int q; //czas dostarczenia

        public Task(int R, int P, int Q)
        {
            r = R;
            p = P;
            q = Q;
        }

        public override string ToString()
        {
            return "Task: r:" + r + " p:" + p  + " q:" + q;
        }

        public Task Clone()
        {
            Task task = new Task(0, 0, 0);
            task.r = this.r;
            task.p = this.p;
            task.q = this.q;
            return task;
        }
    }
}

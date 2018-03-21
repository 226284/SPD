using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schrage
{
    class Task
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
    }
}
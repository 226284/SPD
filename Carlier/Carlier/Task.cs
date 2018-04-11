using System;
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
        public int id; //id o pozycji 

        public Task(int R, int P, int Q)
        {
            r = R;
            p = P;
            q = Q;
        }
    }
}

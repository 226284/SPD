using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gniazdowy
{
    public class File
    {
        public int NumberOfOperations; //liczba operacji
        public int[] T; //tablica następników technologicznych
        public int[] M; //tablica następników maszynowych
        public int[] P; //tablica czasów wykonywania się operacji
        public int NumberOfMachines; //liczba maszyn
        public int[] Permutations; //tablica przechowująca kolejność permutacji
    }
}

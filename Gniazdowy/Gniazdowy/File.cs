using System;
using System.Collections.Generic;
using System.IO;
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

        public File()
        {
            //wczytywanie bazy z pliku
            Console.WriteLine("Nr bazy: ");
            int liczba = Int32.Parse(Console.ReadLine());

            using (StreamReader sr = new StreamReader("data" + liczba + ".txt"))
            {
                string tmp = sr.ReadLine();
                string[] bitsTmp = tmp.Split(' ');
                NumberOfOperations = Int32.Parse(bitsTmp[0]);

                T = new int[NumberOfOperations + 1];
                M = new int[NumberOfOperations + 1];
                P = new int[NumberOfOperations + 1];
                //int[] LP = new int[file.NumberOfOperations + 1];

                tmp = sr.ReadLine();
                bitsTmp = tmp.Split(' ');
                for (int j = 1; j <= NumberOfOperations; j++)
                {
                    //Następnicy technologiczni
                    T[j] = Int32.Parse(bitsTmp[j - 1]);
                }

                tmp = sr.ReadLine();
                bitsTmp = tmp.Split(' ');
                for (int j = 1; j <= NumberOfOperations; j++)
                {
                    //Następnicy maszynowi
                    M[j] = Int32.Parse(bitsTmp[j - 1]);
                }

                tmp = sr.ReadLine();
                bitsTmp = tmp.Split(' ');
                for (int j = 1; j <= NumberOfOperations; j++)
                {
                    //Czas wykonywania operacji
                    P[j] = Int32.Parse(bitsTmp[j - 1]);

                }

                //Liczba maszyn
                tmp = sr.ReadLine();
                bitsTmp = tmp.Split(' ');
                NumberOfMachines = Int32.Parse(bitsTmp[0]);

                Permutations = new int[NumberOfOperations + NumberOfMachines + 1];

                tmp = sr.ReadLine();
                bitsTmp = tmp.Split(' ');
                for (int j = 1; j <= NumberOfOperations + NumberOfMachines; j++)
                {
                    //Permutacje
                    Permutations[j] = Int32.Parse(bitsTmp[j - 1]);
                }

                ///////////////////KONIEC WCZYTYWANIA PLIKU//////////////////
            }
        }
    }
}

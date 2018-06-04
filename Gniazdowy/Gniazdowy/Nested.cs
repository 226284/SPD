using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gniazdowy
{
    public class Nested
    {
        public File file;
       public Queue<int> order;
        public int[] PM;
        public int[] PT;
        public int[] LP;

        public int[] tab_order;
        public int cMax;

        public int[] S;
        public int[] C;

        public int k = 1;

        public Nested(File f)
        {
            file = f;
            LP = new int[file.NumberOfOperations + 1];
            PM = new int[file.NumberOfOperations + 1];
            PT = new int[file.NumberOfOperations + 1];
            S = new int[file.NumberOfOperations + 1];
            C = new int[file.NumberOfOperations + 1];

            tab_order = new int[file.NumberOfOperations + 1];
            order = new Queue<int>();
        }

        //Poprzednicy technologiczni i maszynowi
        public void Precursors()
        {
            for (int i = 1; i <= file.NumberOfOperations; i++)
            {
                if (file.M[i] != 0)
                {
                    PM[file.M[i]] = i;
                }
            }

            for (int i = 1; i <= file.NumberOfOperations; i++)
            {
                if (file.T[i] != 0)
                {
                    PT[file.T[i]] = i;
                }
            }
        }

        //Liczba poprzedników LP (złożność n^2 :/)
        public void GetLP()
        {
            for (int i = 1; i <= file.NumberOfOperations; i++)
            {
                LP[i] = 0;
                if (PT[i] != 0)
                {
                    LP[i]++;
                }
                if (PM[i] != 0)
                {
                    LP[i]++;
                }
            }
        }

        //obliczanie kolejności wykonania zadań
        public void GetQueue()
        {
            List<int> qTmp = new List<int>();

            ///////////////////////////////////////////
            for (int i = 1; i <= file.NumberOfOperations; i++)
            {
                if (LP[i] == 0)
                {
                    if (!tab_order.Contains(i))
                    {
                        order.Enqueue(i);
                        tab_order[k] = i;
                        k++;
                        qTmp.Add(i);
                    }

                }
            }
            //Tutaj, jeśli zadanie nie ma poprzedników(lub ma, ale jest znana ich kolejność, i w tabeli LP jest 0)
            //to dodawane jest zadanie do tablicy kolejnośći, kolejki order, oraz tymczasowej qTmp
            ///////////////////////////////////////////////
            while (qTmp.Count != 0)
            {
                for (int j = 1; j <= file.NumberOfOperations; j++)
                {
                    if (PT[j] == qTmp.Last() && LP[j] != 0)
                        LP[j]--;
                    if (PM[j] == qTmp.Last() && LP[j] != 0)
                        LP[j]--;
                }
                qTmp.RemoveAt(qTmp.Count - 1);
            }
            //Tutaj, dopóki qTmp z ostatnio znalezionymi zadaniami bez poprzedników, które można ustawić w kolejności, 
            //znajdywane jest dla danego zadania, kogo jest poprzednikiem technologicznym/maszynowym, i dla tego indeksu
            //zostaje obniżona liczba poprzedników
            ///////////////////////////////////////////////
        }

        //obliczanie czasów startu oraz zakończenia zadań
        //Wybiera wartość maksymalną, dla konkretnego zadania, i z jego poprzedników technologicznych/maszynowych wybiera tego, który
        //później kończy i dolicza czas trwania operacji
        public void StartEnd()
        {
            int e;
            while (order.Count != 0)
            {
                e = order.First();
                C[e] = Math.Max(C[PT[e]], C[PM[e]]) + file.P[e];
                order.Dequeue();
                //Niepotrzebne
                //if (PT[e] != 0 && --LP[PT[e]] == 0)
                //{
                //    order.Enqueue(PT[e]);
                //}
                //if (PM[e] != 0 && --LP[PM[e]] == 0)
                //{
                //    order.Enqueue(PM[e]);
                //}
            }

            cMax = C[file.NumberOfOperations];
            for (int i = 1; i <= file.NumberOfOperations; i++)
            {
                S[i] = Math.Max(C[PT[i]], C[PM[i]]);
                if (C[i] > cMax)
                {
                    cMax = C[i];
                }
            }
        }
    }
}

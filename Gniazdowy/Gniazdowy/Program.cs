using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Gniazdowy
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {//tworzenie obiektu typu plik
                File file = new File();
                //deklaracja listy
                //wczytywanie bazy z pliku
                Console.WriteLine("Nr bazy: ");
                int liczba = Int32.Parse(Console.ReadLine());

                using (StreamReader sr = new StreamReader("data" + liczba + ".txt"))
                {
                    string tmp = sr.ReadLine();
                    string[] bitsTmp = tmp.Split(' ');
                    file.NumberOfOperations = Int32.Parse(bitsTmp[0]);

                    file.T = new int[file.NumberOfOperations + 1];
                    file.M = new int[file.NumberOfOperations + 1];
                    file.P = new int[file.NumberOfOperations + 1];
                    int[] LP = new int[file.NumberOfOperations + 1];

                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    for (int j = 1; j <= file.NumberOfOperations; j++)
                    {
                        //Następnicy technologiczni
                        file.T[j] = Int32.Parse(bitsTmp[j - 1]);
                    }

                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    for (int j = 1; j <= file.NumberOfOperations; j++)
                    {
                        //Następnicy maszynowi
                        file.M[j] = Int32.Parse(bitsTmp[j - 1]);
                    }

                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    for (int j = 1; j <= file.NumberOfOperations; j++)
                    {
                        //Czas wykonywania operacji
                        file.P[j] = Int32.Parse(bitsTmp[j - 1]);

                    }

                    //Liczba maszyn
                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    file.NumberOfMachines = Int32.Parse(bitsTmp[0]);

                    file.Permutations = new int[file.NumberOfOperations + file.NumberOfMachines];

                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    for (int j = 0; j < file.NumberOfOperations + file.NumberOfMachines; j++)
                    {
                        //Permutacje

                        file.Permutations[j] = Int32.Parse(bitsTmp[j]);
                    }

                    var T = file.T;
                    var M = file.M;
                    var P = file.P;

                    var PM = new int[file.NumberOfOperations + 1];
                    for (int i = 1; i <= file.NumberOfOperations; i++)
                    {
                        if (M[i] != 0)
                        {
                            PM[M[i]] = i;
                        }
                    }
                    var PT = new int[file.NumberOfOperations + 1];
                    for (int i = 1; i <= file.NumberOfOperations; i++)
                    {
                        if (T[i] != 0)
                        {
                            PT[T[i]] = i;
                        }
                    }

                    // Algorytm gniazdowy

                    // wyznaczenie LP (złożność n^2 :/)
                    for (int i = 1; i <= file.NumberOfOperations; i++)
                    {
                        for (int j = 1; j <= file.NumberOfOperations; j++)
                        {
                            if (T[j] == i)
                            {
                                LP[i] = LP[i] + 1;
                            }
                            if (M[j] == i)
                            {
                                LP[i] = LP[i] + 1;
                            }
                        }
                    }

                    int[] S = new int[file.NumberOfOperations + 1];
                    int[] C = new int[file.NumberOfOperations + 1];
                    int cMax = 0;

                    for (int j = 1; j <= file.NumberOfOperations; j++)
                    {
                        if (LP[j] == 0)
                        {
                            S[j] = 0;
                            C[j] = P[j];
                        }
                    }

                    for (int j = 1; j <= file.NumberOfOperations; j++)
                    {
                        C[j] = Math.Max(C[PT[j]], C[PM[j]]) + P[j];
                        S[j] = C[j] - P[j];
                    }
                    cMax = C.Max();

                    for (int j = 1; j <= file.NumberOfOperations; j++)
                    {
                        Console.WriteLine(S[j] + "  " + C[j]);
                    }
                    Console.WriteLine(cMax);

                    // tworzenie listy
                    //List<Task> data = new List<Task>();

                    //int[] c = new int[file.NumberOfOperations + 1];
                    //int q = file.NumberOfOperations;
                    //int e;
                    //int cmax = 0;
                    //List<int> act = new List<int>();
                    //int count = 0;

                    //for (int i = 1; i <= file.NumberOfOperations; i++)
                    //{
                    //    if (LP[i] == 0)
                    //    {
                    //        act.Add(i);
                    //    }
                    //}

                    //while (q != 0)
                    //{
                    //    e = q;

                    //    c[e] = Math.Max(c[PT[e]], c[PM[e]]) + P[e];

                    //    if (T[e] != 0)
                    //    {
                    //        if (--LP[T[e]] == 0) { q = T[e]; act.Add(e); }
                    //    }
                    //    if (M[e] != 0)
                    //    {
                    //        if (--LP[M[e]] == 0) { q = M[e]; act.Add(e); }
                    //    }
                    //    //Console.WriteLine(cmax);
                    //    cmax = Math.Max(cmax, c[e]);
                    //    if (act.Count == file.NumberOfOperations)
                    //    {
                    //        break;
                    //    }
                    //}

                    // Console.WriteLine(cmax);

                    //foreach (Task t in data)
                    //{
                    //    Console.WriteLine(t.id.ToString() + ": " + t.start.ToString() + " " + t.stop.ToString());
                    //}
                    Console.ReadLine();
                }

            }
        }
    }
}

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

                    file.T = new int[file.NumberOfOperations];
                    file.M = new int[file.NumberOfOperations];
                    file.P = new int[file.NumberOfOperations];
                    int[] LP = new int[file.NumberOfOperations];

                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    for (int j = 0; j < file.NumberOfOperations; j++)
                    {
                        //T
                        file.T[j] = Int32.Parse(bitsTmp[j]);
                    }

                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    for (int j = 0; j < file.NumberOfOperations; j++)
                    {
                        //M
                        file.M[j] = Int32.Parse(bitsTmp[j]);
                    }

                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    for (int j = 0; j < file.NumberOfOperations; j++)
                    {
                        //P
                        file.P[j] = Int32.Parse(bitsTmp[j]);

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
                    var PM = new int[file.NumberOfOperations];
                    for (int i = 0; i < file.NumberOfOperations; i++)
                    {
                        if (M[i] != 0)
                        {
                            PM[M[i]] = i;
                        }
                    }
                    var PT = new int[file.NumberOfOperations];
                    for (int i = 0; i < file.NumberOfOperations; i++)
                    {
                        if (T[i] != 0)
                        {
                            PT[T[i]] = i;
                        }
                    }

                    // Algorytm gniazdowy

                    // wyznaczenie LP (złożność n^2 :/)
                    for (int i = 0; i < file.NumberOfOperations; i++)
                    {
                        for (int j = 0; j < file.NumberOfOperations; j++)
                        {
                            if (T[j] == (i + 1))
                            {
                                LP[i] = LP[i] + 1;
                            }
                            if (M[j] == (i + 1))
                            {
                                LP[i] = LP[i] + 1;
                            }
                        }
                    }

                    // tworzenie listy
                    List<Task> data = new List<Task>();

                    int q = file.NumberOfOperations;
                    int e;
                    int cmax = 0;
                    while (q != 0)
                    {
                        e = q - 1;

                        cmax = Math.Max(PT[e], PM[e]) + P[e];

                        if (T[e] != 0)
                        {
                            if (--LP[T[e]] == 0) { q = T[e]; }
                        }
                        if (M[e] != 0)
                        {
                            if (--LP[M[e]] == 0) { q = M[e]; }
                        }
                        Console.WriteLine(cmax);
                    }

                    Console.WriteLine(cmax);

                    foreach (Task t in data)
                    {
                        Console.WriteLine(t.id.ToString() + ": " + t.start.ToString() + " " + t.stop.ToString());
                    }
                }

            }
        }
    }
}

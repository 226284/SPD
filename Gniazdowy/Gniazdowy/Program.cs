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
                    var permuttuans = file.Permutations;

                }
            }
        }
    }
}

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
                    //int[] LP = new int[file.NumberOfOperations + 1];

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

                    file.Permutations = new int[file.NumberOfOperations + file.NumberOfMachines + 1];

                    tmp = sr.ReadLine();
                    bitsTmp = tmp.Split(' ');
                    for (int j = 1; j <= file.NumberOfOperations + file.NumberOfMachines; j++)
                    {
                        //Permutacje
                        file.Permutations[j] = Int32.Parse(bitsTmp[j-1]);
                    }
                    ///////////////////KONIEC WCZYTYWANIA PLIKU//////////////////

                    Nested nested = new Nested(file);

                    // Algorytm gniazdowy

                    nested.Precursors();

                    nested.GetLP();


                    do {
                        nested.GetQueue();
                    } while (nested.order.Count != nested.file.NumberOfOperations);

                    nested.StartEnd();

                    //WYPISYWANIE
                    for (int j = 1; j <= file.NumberOfOperations; j++)
                    {
                        Console.WriteLine(nested.S[j] + "  " + nested.C[j]);
                    }
                    Console.WriteLine(nested.cMax);

                    Console.ReadLine();
                }

            }
        }


    }
}

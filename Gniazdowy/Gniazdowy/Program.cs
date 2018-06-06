using System;
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
            {
                //tworzenie obiektu typu plik i załadowanie całego pliku
                File file = new File();

                Nested nested = new Nested(file);

                ////////// Algorytm gniazdowy /////////////////
                //Znajdż poprzedników maszynowych i technologicznych
                nested.Precursors();

                //Znajdz LP - liczbę poprzedników
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

using System;
using System.IO;
using System.Collections.Generic;


namespace NEH
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

                try
                {
                    using (StreamReader sr = new StreamReader("NEH" + liczba + ".DAT"))
                    {
                        string tmp = sr.ReadLine();
                        string[] bitsTmp = tmp.Split(' ');
                        file.numberOfTasks = Int32.Parse(bitsTmp[0]);
                        file.numberOfMachines = Int32.Parse(bitsTmp[1]);

                        int[,] taskMachinesTimes = new int[file.numberOfMachines+1, file.numberOfTasks+1];
                        for (int k = 0; k < file.numberOfMachines; k++)
                        {
                            taskMachinesTimes[k, 0] = 0;
                        }

                        for (int j = 0; j < file.numberOfTasks; j++)
                        {
                            taskMachinesTimes[0, j] = 0;
                        }
                        Console.WriteLine("dd" + taskMachinesTimes.GetLength(0) + taskMachinesTimes.GetLength(1));

                        for (int j = 0; j < file.numberOfTasks; j++)
                        {
                            string text = sr.ReadLine();
                            string[] bits = text.Split(' ');

                            for(int k = 0; k < file.numberOfMachines; k++)
                            {
                                taskMachinesTimes[k+1, j+1] = Int32.Parse(bits[k]);
                                Console.Write(bits[k]);
                            }
                            Console.WriteLine();

                        }

                        //for (int j = 0; j < file.numberOfTasks + 1; j++)
                        //{
                        //    for (int k = 0; k < file.numberOfMachines + 1 ; k++)
                        //    {
                        //        Console.Write(taskMachinesTimes[k, j] + "  ");
                        //    }
                        //    Console.WriteLine();
                        //}
                        
                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Problem z odczytaniem pliku");
                    Console.WriteLine(e.Message);
                }
                Console.ReadLine();
            }
        }
    }
}

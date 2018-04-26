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
                List<int> listOfTaskSum = new List<int>();
                //wczytywanie bazy z pliku
                Console.WriteLine("Nr bazy: ");
                int liczba = Int32.Parse(Console.ReadLine());

                //try
                //{
                    using (StreamReader sr = new StreamReader("NEH" + liczba + ".DAT"))
                    {
                        string tmp = sr.ReadLine();
                        string[] bitsTmp = tmp.Split(' ');
                        file.numberOfTasks = Int32.Parse(bitsTmp[0]);
                        file.numberOfMachines = Int32.Parse(bitsTmp[1]);

                   //     int[,] taskMachinesTimes = new int[file.numberOfMachines+1, file.numberOfTasks+1];
                        Task[] tabOfTasks = new Task[file.numberOfTasks + 1];
                        //Stworzyć dwie tablice jednowyiarowe

                        for (int j = 0; j < file.numberOfTasks + 1; j++)
                        {
                        Task task = new Task() { id = j, TimeOnMachineTab = new int[file.numberOfMachines + 1] };
                           tabOfTasks[j] = task ;
                            tabOfTasks[j].TimeOnMachineTab[0] = 0;
                        }

                        for (int k = 0; k < file.numberOfMachines + 1; k++)
                        {
                            tabOfTasks[0].TimeOnMachineTab[k] = 0;
                      //      taskMachinesTimes[k, 0] = 0;
                        }



                        for (int j = 0; j < file.numberOfTasks; j++)
                        {
                            string text = sr.ReadLine();
                            string[] bits = text.Split(' ');

                            for(int k = 0; k < file.numberOfMachines; k++)
                            {
                        //        taskMachinesTimes[k+1, j+1] = Int32.Parse(bits[k]);
                                tabOfTasks[j+1].TimeOnMachineTab[k+1] = Int32.Parse(bits[k]);
                            }
                        }

                        int C = 0;
                        int sum = 0;
                      //posortować zadania od najwiekszej sumy czasu wykonywania zadań dla każdej maszyny
                      //i tak jak na fotce
                        for (int j = 1; j < file.numberOfTasks + 1; j++)
                        {
                            for (int k = 1; k < file.numberOfMachines + 1; k++)
                            {
                        //        C = Math.Max(taskMachinesTimes[k, j - 1], taskMachinesTimes[k - 1, j]) + taskMachinesTimes[k, j];
                      //          sum += taskMachinesTimes[k, j];
                     //       Console.WriteLine(taskMachinesTimes[k, j]);
                            Console.WriteLine(tabOfTasks[j].TimeOnMachineTab[k]);
                            }
                            listOfTaskSum.Add(sum);
                            sum = 0;

                            Console.WriteLine();
                        }
                        listOfTaskSum.Sort();
                        listOfTaskSum.Reverse();
                        int[] tabTaskSum = new int[listOfTaskSum.Count];
                        int it = 0;
                        foreach (var l in listOfTaskSum)
                        {
                            tabTaskSum[it] = l;
                            Console.WriteLine(tabTaskSum[it]);
                            it++;
                        }

                        for (int j = 1; j < file.numberOfTasks + 1; j++)
                        {
                            for (int k = 1; k < file.numberOfMachines + 1; k++)
                            {
                         //       C = Math.Max(taskMachinesTimes[k, j - 1], taskMachinesTimes[k - 1, j]) + taskMachinesTimes[k, j];
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Lista:");

                        Console.WriteLine("Wynik:");
                        Console.WriteLine(C);


                    }
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Problem z odczytaniem pliku");
                //    Console.WriteLine(e.Message);
                //}
                Console.ReadLine();
            }
        }
    }
}

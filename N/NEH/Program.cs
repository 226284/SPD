using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

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

                //try
                //{
                    using (StreamReader sr = new StreamReader("NEH" + liczba + ".DAT"))
                    {
                        string tmp = sr.ReadLine();
                        string[] bitsTmp = tmp.Split(' ');
                        file.numberOfTasks = Int32.Parse(bitsTmp[0]);
                        file.numberOfMachines = Int32.Parse(bitsTmp[1]);

                        Task[] tabOfTasks = new Task[file.numberOfTasks + 1];
      //              Task[] listOfTaskSum = new Task[];

                    for (int j = 0; j < file.numberOfTasks + 1; j++)
                        {
                        Task task = new Task() { id = j, TimeOnMachineTab = new int[file.numberOfMachines + 1] };
                           tabOfTasks[j] = task ;
                            tabOfTasks[j].TimeOnMachineTab[0] = 0;
                        }

                        for (int k = 0; k < file.numberOfMachines + 1; k++)
                        {
                            tabOfTasks[0].TimeOnMachineTab[k] = 0;
                        }



                        for (int j = 0; j < file.numberOfTasks; j++)
                        {
                            string text = sr.ReadLine();
                            string[] bits = text.Split(' ');

                            for(int k = 0; k < file.numberOfMachines; k++)
                            {
                                tabOfTasks[j+1].TimeOnMachineTab[k+1] = Int32.Parse(bits[k]);
                            }
                        }

                    int C = 0;
                    //int Cprev = 0;
                    int Cmax = 0;
                    int[] sum = new int[file.numberOfTasks + 1];
                      //posortować zadania od najwiekszej sumy czasu wykonywania zadań dla każdej maszyny
                      //i tak jak na fotce
                        for (int j = 1; j < file.numberOfTasks + 1; j++)
                        {
                            for (int k = 1; k < file.numberOfMachines + 1; k++)
                            {
                                     sum[j] += tabOfTasks[j].TimeOnMachineTab[k];
                            //Console.Write(tabOfTasks[j].TimeOnMachineTab[k] + " ");
                            }
                            Console.WriteLine();
                        }
                    Array.Sort(sum, tabOfTasks);
                    Array.Reverse(tabOfTasks);
                    foreach (var s in sum)
                    {
                        Console.WriteLine(s);
                    }
                    foreach (var s in tabOfTasks)
                    {
                        Console.WriteLine(s.id);
                    }

                    ArrayList taskTabTmp = new ArrayList();
                    Task tmp1;
                    Task tmp2;

                    int Cmax0 =0, Cmax1=0;
                    //////WYBIERANIE z dwóch pierwszych zadań która kombinacja jest lepsza(ma krótsze cMax)
                    taskTabTmp.Add(tabOfTasks[0]);
                    taskTabTmp.Add(tabOfTasks[1]);
                    for (int j = 1; j < 2; j++)
                    {
                        for (int k = 1; k < file.numberOfMachines + 1; k++)
                        {
                            tmp1 = (Task)taskTabTmp[j - 1];
                            tmp2 = (Task)taskTabTmp[j];
                            C = C + Math.Max(tmp1.TimeOnMachineTab[k], tmp2.TimeOnMachineTab[k - 1]) + tmp2.TimeOnMachineTab[k];
                            Cmax = Math.Max(Cmax, C);
                        }
                        C = 0;
                        Cmax0 = Cmax;
                    }

                    taskTabTmp[0] = tabOfTasks[1];
                    taskTabTmp[1] = tabOfTasks[0];
                    for (int j = 1; j < 2; j++)
                    {
                        for (int k = 1; k < file.numberOfMachines + 1; k++)
                        {
                            tmp1 = (Task)taskTabTmp[j - 1];
                            tmp2 = (Task)taskTabTmp[j];
                            C = C + Math.Max(tmp1.TimeOnMachineTab[k], tmp2.TimeOnMachineTab[k - 1]) + tmp2.TimeOnMachineTab[k];
                            Cmax = Math.Max(Cmax, C);
                        }
                        C = 0;
                        Cmax1 = Cmax;
                    }
                    //Ostateczne wybranie
                    if(Cmax0 > Cmax1)
                    {
                        taskTabTmp[0] = tabOfTasks[0];
                        taskTabTmp[1] = tabOfTasks[1];
                    }
                    
                    //Tutaj trzeba wsadzać kolejne zadanie kolejno na pierwsze,...,ostatnie miejsce w arrayList, i dla każdego sprawdzać Cmax. Na końcu należy wybrać i zapisać tę konfigurację
                    // która daje najmniejsze Cmax. Tak aż do końca zadań. Ostatnie Cmax to będzie odpowiedź.
                    for (int y = 2; y < file.numberOfTasks + 1; y++)
                    {
                        for (int x = 0; x <= taskTabTmp.Count; x++)
                        {
                            taskTabTmp.Insert(x, tabOfTasks[y]);

                            for (int j = 1; j < file.numberOfTasks; j++)
                            {
                                if (taskTabTmp.Count<=j)
                                {
                                    break;
                                }
                                for (int k = 1; k < file.numberOfMachines + 1; k++)
                                {
                                    tmp1 = (Task)taskTabTmp[j - 1];
                                    tmp2 = (Task)taskTabTmp[j];
                                    C = C + Math.Max(tmp1.TimeOnMachineTab[k], tmp2.TimeOnMachineTab[k - 1]) + tmp2.TimeOnMachineTab[k];
                                    Cmax = Math.Max(Cmax, C);
                                }
                                C = 0;
                            }
                            taskTabTmp.RemoveAt(x);
                            //for (int i = 0; i < x; i++)
                            //{
                            //    taskTabTmp[x] = tabOfTasks[i];
                            //}

                            //for (int j = 1; j < x ; j++)
                            //{
                            //    for (int k = 1; k < file.numberOfMachines + 1; k++)
                            //    {
                            //        C = Math.Max(taskTabTmp[j - 1].TimeOnMachineTab[k], taskTabTmp[j].TimeOnMachineTab[k - 1]) + taskTabTmp[j].TimeOnMachineTab[k];
                            //    }
                            //}
                        }
                    }
                    Console.WriteLine("Lista:");

                        Console.WriteLine("Wynik:");
                        Console.WriteLine(Cmax + " "+C);


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

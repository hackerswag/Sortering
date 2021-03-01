using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BubbleSort
{
    class Program
    {
        static void BubbleSort(List<int> mylist)
        {
            for (int i=0; i<mylist.Count; i++) //räknar antal genomgångar
            {
                for(int j = 0; j < mylist.Count-1; j++)//gå igenom listan
                {
                    if (mylist[j] > mylist[j + 1])
                    {
                        int temp = mylist[j];
                        mylist[j] = mylist[j + 1];
                        mylist[j + 1] = temp;
                    }
                }
            }
        }
        static void SelectionSort(List<int> mylist)
        {
            int smallest, temp;
            for (int i = 0; i < mylist.Count - 1; i++)
            {
                smallest = i;
                for (int j = i+1; j < mylist.Count; j++)
                {
                    if (mylist[j] < mylist[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = mylist[smallest];
                mylist[smallest] = mylist[i];
                mylist[i] = temp;
            }
        }
        static void InsertionSort(List<int> mylist)
        {
            for (int i =0; i < mylist.Count - 1; i++)
            {
                for(int j = i + 1;j>0; j--)
                {
                    if (mylist[j-1] > mylist[j])
                    {
                        int temp = mylist[j-1];
                        mylist[j - 1] = mylist[j];
                        mylist[j]=temp;
                            

                    }
                }
            }
        }
        static void Merge(int[] myarray, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(myarray, left, leftArray, 0, middle - left + 1);
            Array.Copy(myarray, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    myarray[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    myarray[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    myarray[k] = leftArray[i];
                    i++;
                }
                else
                {
                    myarray[k] = rightArray[j];
                    j++;
                }
            }
        }

        static void MergeSort(int[] myarray, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(myarray, left, middle);
                MergeSort(myarray, middle + 1, right);

                Merge(myarray, left, middle, right);
            }
        }
        private static void QuickSort(int[] myarray, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(myarray, left, right);

                if (pivot > 1)
                {
                    QuickSort(myarray, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(myarray, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] myarray, int left, int right)
        {
            int pivot = myarray[left];
            while (true)
            {

                while (myarray[left] < pivot)
                {
                    left++;
                }

                while (myarray[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (myarray[left] == myarray[right]) return right;

                    int temp = myarray[left];
                    myarray[left] = myarray[right];
                    myarray[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }
        static void Test(List<int> mylist)
        {
            foreach (int i in mylist)
            {
                Console.Write(i + " ");
            }
        }
        static void TestArray(int[] myarray)
        {
            foreach (int i in myarray)
            {
                Console.Write(i + " ");
            }
        }

        static  void SkapaSlumpLista(List<int> mylist, int size)   
        {
            Random slump = new Random();

            for (int i = 0; i < size; i++) //stort antal slumptal i lista
            {
                mylist.Add(slump.Next(1000000));
            }


        }
        static void Swap(int a, int b)
        {
            int temp = a;
            a = b;
            temp = b;
        }


        static void Main(string[] args)
        {
            List<int> tallista = new List<int>();
            
            //tallista.Add(1); tallista.Add(4); tallista.Add(6); tallista.Add(2);            tallista.Add(8); tallista.Add(11); tallista.Add(22); tallista.Add(3);            tallista.Add(6);

            SkapaSlumpLista(tallista, 100000);

            //Skapa kopia av slumpad lista
            List<int> tallistacop1 = new List<int>(tallista);
            List<int> tallistacop2 = new List<int>(tallista);
            List<int> tallistacop3 = new List<int>(tallista);

            int[] tallistamyarrayay = tallistacop3.ToArray();

            int[] swag = { 1, 4, 6, 7, 2, 7, 1, 6 , 8, 9, 123, 123, 4561, 1236, 123, 232 };

            Stopwatch bubblesort = new Stopwatch();
            Stopwatch insertion = new Stopwatch();
            Stopwatch selection = new Stopwatch();
            Stopwatch merges = new Stopwatch();


            bubblesort.Start();
            //BubbleSort(tallista);           
            bubblesort.Stop();

            insertion.Start();
            //InsertionSort(tallistacop1);
            insertion.Stop();

            selection.Start();
            //SelectionSort(tallistacop2);
            selection.Stop();

            merges.Start();
            MergeSort(swag, 0, swag.Length - 1);
            merges.Stop();

            Console.WriteLine("Bubblesort: " + bubblesort.Elapsed);
            Console.WriteLine("InsertionSort: " + insertion.Elapsed);
            Console.WriteLine("SelectionSort: " + selection.Elapsed);
            Console.WriteLine("MergeSort: + " + merges.Elapsed);


            TestArray(swag);

            //Test(tallista);
;
            //Console.WriteLine("Sorterad " + swag.Elapsed);
            Console.ReadLine();
        }
    }
}

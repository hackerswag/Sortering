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
                for(int j = 0; j < mylist.Count-1; j++) //gå igenom listan
                {
                    if (mylist[j] > mylist[j + 1]) //Byter plats på element
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
            int smallest, temp; //temporär variabel
            for (int i = 0; i < mylist.Count - 1; i++)
            {
                smallest = i;
                for (int j = i+1; j < mylist.Count; j++) //hitta minsta talet i osorterad lista
                {
                    if (mylist[j] < mylist[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = mylist[smallest]; //byt plats på minsta tal med i
                mylist[smallest] = mylist[i];
                mylist[i] = temp;
            }
        }
        static void InsertionSort(List<int> mylist)
        {
            for (int i =0; i < mylist.Count - 1; i++)//Gå igenom lista
            {
                for(int j = i + 1;j>0; j--) //gå igenom listan från i "nedåt"
                {
                    if (mylist[j-1] > mylist[j]) //Jämför elementet med elementet innan, om elementet är mindre byt plats
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

        static void TestHel(int a)
        {
            List<int> tallista = new List<int>();

            SkapaSlumpLista(tallista, a);

            //Skapa kopia av slumpad lista
            List<int> tallistacop1 = new List<int>(tallista);
            List<int> tallistacop2 = new List<int>(tallista);
            List<int> tallistacop3 = new List<int>(tallista);
            List<int> tallistacop4 = new List<int>(tallista);
            List<int> tallistacop5 = new List<int>(tallista);
            int[] tallistamyarray = tallistacop3.ToArray();
            int[] tallistamyarray1 = tallistacop4.ToArray();
            
            //skapa klockor
            Stopwatch bubblesort = new Stopwatch();
            Stopwatch insertion = new Stopwatch();
            Stopwatch selection = new Stopwatch();
            Stopwatch merges = new Stopwatch();
            Stopwatch qs = new Stopwatch();
            Stopwatch df = new Stopwatch();


            bubblesort.Start();
            BubbleSort(tallista);           
            bubblesort.Stop();

            insertion.Start();
            InsertionSort(tallistacop1);
            insertion.Stop();

            selection.Start();
            SelectionSort(tallistacop2);
            selection.Stop();

            merges.Start();
            MergeSort(tallistamyarray, 0, tallistamyarray.Length - 1);
            merges.Stop();

            qs.Start();
            QuickSort(tallistamyarray1, 0, tallistamyarray1.Length - 1);
            qs.Stop();

            df.Start();
            tallistacop5.Sort();
            df.Stop();

            Console.WriteLine("Bubblesort: " + bubblesort.Elapsed);
            Console.WriteLine("InsertionSort: " + insertion.Elapsed);
            Console.WriteLine("SelectionSort: " + selection.Elapsed);
            Console.WriteLine("MergeSort: + " + merges.Elapsed + "  Millisekunder: " + merges.ElapsedMilliseconds);
            Console.WriteLine("QuickSort: + " + qs.Elapsed + "  Millisekunder: " + qs.ElapsedMilliseconds);
            Console.WriteLine("Inbyggd: " + df.Elapsed + "  Millisekunder: " + df.ElapsedMilliseconds);

        }

        static void Main(string[] args)
        {
            TestHel(80000);
            Console.ReadLine();
        }
    }
}

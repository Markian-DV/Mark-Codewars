using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace codewars
{
    class AddBigNumsKata
    {

        public static string Add(string a, string b)
        {

            List<char> A = a.Length >= b.Length ? a.ToCharArray().ToList() : b.ToCharArray().ToList(); //len a>= len b
            List<char> B = b.Length <= a.Length ? b.ToCharArray().ToList() : a.ToCharArray().ToList();
            List<string> Res = new List<string>();
            int NumB; bool next;
            for (int i = A.Count - 1, j = B.Count - 1; i >= 0; i--, j--)
            {
                if (j >= 0) NumB = B[j] - '0';
                else NumB = 0;

                int TmpRes = (A[i] - '0') + NumB;

                if (TmpRes.ToString().Length > 1) next = true;
                else next = false;
                if (!next) Res.Insert(0, TmpRes.ToString());
                else
                {
                    Res.Insert(0, (TmpRes % 10).ToString());
                    AddNext(i, A);
                }


            }
            //Print(A);
            return string.Join("", Res);
        }
        static void AddNext(int index, List<char> A)
        {
            //TODO: implement transfer to the next figure
        }

        //
        static void Print(List<char> A)
        {
            foreach (var item in A)
            {
                Console.Write(item);
            }
            Console.WriteLine();

        }
    }

}

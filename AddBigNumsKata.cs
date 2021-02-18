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
            //len A>= len B
            List<string> A = a.Length >= b.Length ? a.Select(c => c.ToString()).ToList() : b.Select(c => c.ToString()).ToList();
            List<string> B = b.Length <= a.Length ? b.Select(c => c.ToString()).ToList() : a.Select(c => c.ToString()).ToList();
            List<string> Res = new List<string>();
            int NumB, NumA;
            for (int i = A.Count - 1, j = B.Count - 1; i >= 0; i--, j--)
            {
                NumA = int.Parse(A[i]);
                NumB = j >= 0 ? int.Parse(B[j]) : 0;

                if (NumA + NumB < 10) Res.Insert(0, (NumA + NumB).ToString());
                else
                {
                    Res.Insert(0, ((NumA + NumB)%10).ToString());
                    AddOne(i, A, ref i);
                }
            }

            //Print(A);
            return string.Join("", Res);
        }
        static void AddOne(int index, List<string> A,ref int i)
        {
            if(index==0)
            {
                A[0] = "0";
                A.Insert(0, "1");
                i++;
                return;
            }
            if(int.Parse(A[index-1])<9)
            {
                //0
                A[index] = "0";
                A[index - 1] = (int.Parse(A[index - 1]) + 1).ToString();
            }
            else
            {
                A[index]="0";
                AddOne(--index, A,ref i);
            }
        }


    }

}

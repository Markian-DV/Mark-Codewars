using System;
using System.Collections.Generic;
using System.Text;

namespace codewars
{
    public class KataArrayDiff
    {
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = a.Length - 1; j >= 0; j--)
                {
                    if (b[i] == a[j])
                    {
                        int[] tmpArr = new int[a.Length - 1];
                        for (int k = 0, l = 0; k < a.Length; k++, l++)
                        {
                            if (k == j) { l--; continue; }
                            tmpArr[l] = a[k];
                        }
                        a = tmpArr;
                    }
                }
            }

            return a;
        }
    }
}

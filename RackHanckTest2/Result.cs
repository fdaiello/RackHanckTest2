using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RackHanckTest2
{
    internal class Result
    {
        /*
         * Complete the 'palindromeIndex' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */

        public static int palindromeIndex(string s)
        {

            if (s.Length <= 1)
                return -1;

            char[] arr = s.ToCharArray();

            for (int i = 0; i < arr.Length/2; i++)
            {
                if ( arr[i] != arr[arr.Length - 1 - i])
                {
                    // test element to be removed
                    List<char> l1 = new List<char>(s);
                    l1.RemoveAt(i);
                    List<char> l2 = new List<char>(l1);
                    l2.Reverse();
                    if (Enumerable.SequenceEqual(l1,l2))
                    {
                        return i;
                    }
                    l1 = new List<char>(s);
                    l1.RemoveAt(arr.Length - 1 - i);
                    l2 = new List<char>(l1);
                    l2.Reverse();

                    if (Enumerable.SequenceEqual(l1, l2))
                    {
                        return arr.Length - 1 - i;
                    }

                }
            }

            return -1;
        }


        /*
         * Complete the 'anagram' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         * 
         * 
         */

        public static int anagram(string s)
        {
            // Must be even lenght
            if (s.Length%2 !=0)
                return -1;

            // Dictionary
            Dictionary<char, int[]> dic = new Dictionary<char, int[]>();

            // Break string in 2
            string s1 = s.Substring(0,s.Length / 2);
            string s2 = s.Substring(s.Length / 2);

            // Fill dictionary with elements from s1
            foreach ( char c in s1)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c][0]++;
                }
                else
                {
                    dic.Add(c, new int[] { 1, 0 });
                }
            }
            
            // Fill dictionary with elements from s2
            foreach( char c in s2)
            {
                if (dic.ContainsKey(c)) 
                {
                    dic[c][1]++;
                }
                else
                {
                    dic.Add(c, new int[] { 0, 1 });
                }
            }

            // Count differences
            int dif = 0;
            foreach( KeyValuePair<char, int[]> kv in dic)
            {
                dif += Math.Abs(kv.Value[0] - kv.Value[1]);
            }

            return dif / 2;

        }

        public static int getTotalX(List<int> a, List<int> b)
        {

            List<int> primeList = new List<int>();

            // Get Prime numbers for lower element in b
            InsertPrimeNumbers(b.Min(), primeList);

            // Check numbers in primeList that also divide other numbers
            foreach ( int x in b)
            {
                for( int y=0; y<primeList.Count; y++)
                {
                    if ( x%primeList[y] != 0)
                    {
                        primeList.RemoveAt(y);
                    }
                }
            }

            // Check numbers in primeList that all elements in a are factors
            List<int> p2 = new List<int>(primeList);
            for ( int x=0 ; x<p2.Count; x++)
            {
                for( int y=0 ;y<a.Count; y++)
                {
                    if (p2[x]%a[y] != 0)
                    {
                        primeList.RemoveAt(x);
                        break;
                    }
                }
            }

            return primeList.Count;
        }

        public static void InsertPrimeNumbers(int x, List<int> primeList)
        {

            for (int b = 1; b <= x; b++)
            {
                if (x % b == 0)
                {
                    if (!primeList.Contains(b))
                        primeList.Add(b);
                }
            }

        }
    }
}

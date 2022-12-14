namespace KMP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var txt = "ABABDABACDABABCABAB";
            var pat = "ABABCABAB";
            KMPSearch(pat, txt);
        }

        public static void KMPSearch(string pat, string txt)
        {
            var m = pat.Length;
            var n = txt.Length;

            // create lps[] that will hold the longest prefix sufix values for the pattern
            int[] lps = new int[m];
            var j = 0; // index for pat[]

            // process the pattern (calculate lps[] array)
            ComputeLpsArray(pat, m,lps);

            var i = 0; // index for txt[]

            while(i < n)
            {
                if(txt[i] == pat[j])
                {
                    j++;
                    i++;
                }

                if(j == m)
                {
                    Console.WriteLine("Found pattern at index " + (i - j));
                }
                else if(i < n && pat[j] != txt[i]) // mismatch after j matches
                {
                    // Do not match lps[0..lps[j-1]] characters,
                    // they will match anyway
                    if(j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
            }
        }

        public static void ComputeLpsArray(string pat, int m, int[] lps)
        {
            var len = 0;
            int i = 1;
            lps[0] = 0;

            while(i < m)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else if (len != 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = len;
                    i++;
                }
            }
        }
    }
}
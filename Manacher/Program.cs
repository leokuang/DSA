using Microsoft.VisualBasic.CompilerServices;

namespace Manacher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var possibilities = 5;
            var strSize = 20;
            int testTimes = 5000000;

            Console.WriteLine("Test begin");

            for (var i = 0; i < testTimes; i++)
            {
                var str = GetRandomString(possibilities, strSize);

                if (Manacher(str) != Right(str))
                {
                    Console.WriteLine("Oops!");
                }
            }

            Console.WriteLine("Test finish");
        }

        public static int Manacher(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            // "12132" => "#1#2#1#3#2#"
            var str = ManacherString(s);

            // Palindrome radius
            var pArr = new int[str.Length];

            var c = -1;
            var r = -1;

            var max = int.MinValue;

            for (var i = 0; i < str.Length; i++)
            {
                // r is the first invalid position
                pArr[i] = r > i ? Math.Min(pArr[2 * c - i], r - i) : 1;

                while (i + pArr[i] < str.Length && i - pArr[i] > -1)
                {
                    if (str[i + pArr[i]] == str[i - pArr[i]])
                    {
                        pArr[i]++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (i + pArr[i] > r)
                {
                    r = i + pArr[i];
                    c = i;
                }

                max = Math.Max(max, pArr[i]);
            }

            return max - 1;

        }

        private static char[] ManacherString(string str)
        {
            var charArr = str.ToCharArray();
            var res = new char[charArr.Length * 2 + 1];

            var index = 0;
            for (var i = 0; i != res.Length; i++)
            {
                res[i] = (i & 1) == 0 ? '#' : charArr[index++];
            }

            return res;
        }

        // for test
        public static int Right(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var str = ManacherString(s);

            var max = 0;

            for (var i = 0; i < str.Length; i++)
            {
                var l = i - 1;
                var r = i + 1;

                while (l >= 0 && r < str.Length && str[l] == str[r])
                {
                    l--;
                    r++;
                }
                max = Math.Max(max, r - l - 1);
            }
            
            return max / 2;
        }

        // for test
        public static string GetRandomString(int possibities, int size)
        {
            var random = new Random();
            var ans = new char[random.Next(size) + 1];

            for (var i = 0; i < ans.Length; i++)
            {
                ans[i] = (char) (random.Next(possibities) + 'a');
            }

            return new string(ans);

        }
    }
}
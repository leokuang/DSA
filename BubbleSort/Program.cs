namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testTime = 500000;
            var maxSize = 100;
            var maxValue = 100;
            bool succeed = true;

            for (var i = 0; i < testTime; i++)
            {
                var arr1 = GenerateRandomArray(maxSize, maxValue);
                var arr2 = CopyArray(arr1);

                BubbleSort(arr1);
                Comparator(arr2);

                if (!IsEqual(arr1, arr2))
                {
                    succeed = false;
                    break;
                }
            }

            Console.WriteLine(succeed ? "Nice" : "Fucking fucked!");

            var arr = GenerateRandomArray(maxSize, maxValue);
            PrintArray(arr);
            BubbleSort(arr);
            PrintArray(arr);
        }

        public static void BubbleSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }

            // 0 ~ N-1
            // 0 ~ N-2
            // 0 ~ N-3
            for(var e = arr.Length - 1; e > 0; e--)
            {
                for (var i = 0; i < e; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1);
                    }
                }
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

        // for test
        public static void Comparator(int[] arr)
        {
            Array.Sort(arr);
        }

        // for test
        public static int[] GenerateRandomArray(int maxSize, int maxValue)
        {
            var random = new Random();

            var arr = new int[random.Next(maxValue)];

            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(maxValue + 1) - random.Next(maxValue);
            }

            return arr;
        }

        // for test
        public static int[] CopyArray(int[] arr)
        {
            if (arr == null)
            {
                return null;
            }

            int[] res = new int[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i];
            }

            return res;
        }

        public static bool IsEqual(int[] arr1, int[] arr2)
        {
            if ((arr1 == null && arr2 != null) || (arr1 != null && arr2 == null))
            {
                return false;
            }

            if (arr1 == null && arr2 == null)
            {
                return true;
            }

            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            for (var i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static void PrintArray(int[] arr)
        {
            if (arr == null)
            {
                return;
            }

            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
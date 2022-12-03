namespace InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testTime = 500000;
            var maxSize = 100;
            var maxValue = 100;
            var succeed = true;

            for (var i = 0; i < testTime; i++)
            {
                var arr = GenerateRandomArray(maxSize, maxValue);
                var arr1 = CopyArray(arr);
                var arr2 = CopyArray(arr);

                InsertionSort(arr1);
                Comparator(arr2);

                if (!IsEqual(arr1, arr2))
                {
                    succeed = false;
                    for (var j = 0; j < arr.Length; j++)
                    {
                        Console.Write(arr[j] + " ");
                    }
                    Console.WriteLine();
                    break;
                }
            }

            Console.WriteLine(succeed ? "Nice" : "Fucking fucked!");

            var arr3 = GenerateRandomArray(maxSize, maxValue);
            PrintArray(arr3);
            InsertionSort(arr3);
            PrintArray(arr3);
        }

        public static void InsertionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }

            for (var i = 1; i < arr.Length; i++)
            {
                for (var j = i - 1; j >= 0 && arr[j] > arr[j + 1]; j--)
                {
                    Swap(arr, j, j + 1);
                }
            }
        }

        public static void Swap(int[] arr, int i, int j)
        {
            arr[i] = arr[i] ^ arr[j];
            arr[j] = arr[i] ^ arr[j];
            arr[i] = arr[j] ^ arr[i];
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
            var arr = new int[random.Next(maxSize + 1)];

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

            var res = new int[arr.Length];

            for (var i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i];
            }

            return res;
        }

        // for test
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

            for (var i = 0; i < arr1.Length; i++)
            {
                if ((arr1[i] != arr2[i]))
                {
                    return false;
                }
            }

            return true;
        }

        // for test
        public static void PrintArray(int[] arr)
        {
            if (arr == null)
            {
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

    }
}
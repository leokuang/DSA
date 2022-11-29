namespace SelectionSort
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
                int[] arr1 = GenerateRandomArray(maxSize, maxValue);
                int[] arr2 = CopyArray(arr1);

                SelectionSort(arr1);
                Comparator(arr2);

                if (!IsEqual(arr1, arr2))
                {
                    succeed = false;
                    PrintArray(arr1);
                    PrintArray(arr2);
                    break;
                }
            }

            Console.WriteLine(succeed ? "Nice" : "Fucking fucked");

            int[] arr = GenerateRandomArray(maxSize, maxValue);
            PrintArray(arr);
            SelectionSort(arr);
            PrintArray(arr);
        }

        public static void SelectionSort(int[] arr)
        {
            if (arr == null || arr.Length < 2)
            {
                return;
            }
            
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = -1;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    minIndex = i;

                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                        Swap(arr, i, minIndex);
                    }
                }
            }
        }

        private static void Swap(int[] arr, int i, int j)
        {
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }

        private static bool IsEqual(int[] arr1, int[] arr2)
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

        // for test
        public static void Comparator(int[] arr)
        {
            Array.Sort(arr);
        }

        // for test
        public static int[] GenerateRandomArray(int maxSize, int maxValue)
        {
            var random = new Random();
            var randomSize = random.Next(maxSize);
            
            int[] arr = new int[randomSize];

            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(maxValue);
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
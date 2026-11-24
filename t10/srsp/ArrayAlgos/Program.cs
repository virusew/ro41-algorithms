CheckSort([], 0);
CheckSort([5], 0);
CheckSort([1, 2, 3, 4, 5], 4);
CheckSort([5, 4, 3, 2, 1], 10);
CheckSort([3, 1, 3, 2, 3], 9);

var ascending = new int[1000];
for (int i = 0; i < ascending.Length; i++)
    ascending[i] = i + 1;
CheckSort(ascending, 999);

int[] sample = [1, 2, 2, 2, 5, 7];
CheckCount(sample, 2, 3);
CheckCount(sample, 1, 1);
CheckCount(sample, 7, 1);
CheckCount(sample, 3, 0);
CheckCount(sample, 9, 0);

static void CheckSort(int[] a, int expected)
{
    string before = Format(a);
    bool sortedBefore = ArrayAlgos.IsSorted(a);
    int comparisons = ArrayAlgos.BubbleSort(a);
    bool sortedAfter = ArrayAlgos.IsSorted(a);
    bool ok = sortedAfter && comparisons == expected;
    Console.WriteLine($"{before} -> {Format(a)}");
    Console.WriteLine($"IsSorted: {sortedBefore} -> {sortedAfter}; сравнений: {comparisons}, ожидалось: {expected}; {(ok ? "OK" : "FAIL")}");
    if (!ok)
        Environment.ExitCode = 1;
}

static string Format(int[] a) => "{" + string.Join(", ", a) + "}";

static void CheckCount(int[] sample, int x, int expected)
{
    int actual = ArrayAlgos.CountOccurrences(sample, x);
    bool ok = actual == expected;
    Console.WriteLine($"x = {x}: {actual}, ожидалось: {expected}; {(ok ? "OK" : "FAIL")}");
    if (!ok)
        Environment.ExitCode = 1;
}

static class ArrayAlgos
{
    public static bool IsSorted(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i - 1] > a[i])
                return false;
        }
        return true;
    }

    public static int BubbleSort(int[] a)
    {
        int comparisons = 0;
        for (int end = a.Length - 1; end > 0; end--)
        {
            bool swapped = false;
            for (int i = 0; i < end; i++)
            {
                comparisons++;
                if (a[i] > a[i + 1])
                {
                    (a[i], a[i + 1]) = (a[i + 1], a[i]);
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }
        return comparisons;
    }

    public static int CountOccurrences(int[] sortedA, int x)
    {
        int first = FindBound(sortedA, x, false);
        int afterLast = FindBound(sortedA, x, true);
        return afterLast - first;
    }

    private static int FindBound(int[] a, int x, bool strict)
    {
        int lo = 0;
        int hi = a.Length;
        while (lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (a[mid] < x || (strict && a[mid] == x))
                lo = mid + 1;
            else
                hi = mid;
        }
        return lo;
    }
}
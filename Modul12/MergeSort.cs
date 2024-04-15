namespace Sortering;

public static class MergeSort
{

    public static void Sort(int[] array)
    {
        _mergeSort(array, 0, array.Length - 1);
    }

    private static void _mergeSort(int[] array, int l, int h)
    {
        if (l < h)
        {
            int m = (l + h) / 2;
            _mergeSort(array, l, m);
            _mergeSort(array, m + 1, h);
            Merge(array, l, m, h);
        }
    }
//Ikke færdig herunder
    private static void Merge(int[] array, int low, int middle, int high)
    {
        List<int> list = new List<int>();
        int i1 = low;
        int i2 = middle + 1;

        if (high == low) return;

        while (i1 <= middle && i2 <= high)
        {
            if (array[i1] < [i2])
            {

            }
        }
    }

}

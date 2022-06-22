namespace Vector
{
    public static class IntArrayExtension
    {
        public static void Swap(this int[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}

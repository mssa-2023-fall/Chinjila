namespace MergeSortPart
{
    public class MergeSort
    {
        static int[] result;
        public static int[] Divide(int[] input, int left, int right)
        {
            // int[] result = new int[]; ??
           
            int middle = left + (right - left) / 2;
            if (left == right) { return new int[] { input[left] }; }
            return mergeArrays(Divide(input, left, middle), Divide(input, middle + 1, right));

        }

        public static int[] mergeArrays(int[] ary1, int[] ary2)
        {

            int[] solutionAry = new int[ary1.Length + ary2.Length];
            int ind1 = 0;
            int ind2 = 0;

            // iterate through each index in solutionAry
            for (int i = 0; i < solutionAry.Length; i++)
            {
                // if end of ary1 reached add rest of ary2 then leave loop
                if (ind1 >= ary1.Length)
                {
                    while (ind2 < ary2.Length) { solutionAry[i++] = ary2[ind2++]; }
                    break;
                }



                // if end of ary2 reached add rest of ary1 then leave loop
                if (ind2 >= ary2.Length)
                {
                    while (ind1 < ary1.Length) { solutionAry[i++] = ary1[ind1++]; }
                    break;
                }



                // compare and add the lowest number to the solutionAry
                solutionAry[i] = ary1[ind1] < ary2[ind2] ? ary1[ind1++] : ary2[ind2++];



            }



            return solutionAry;
        }


    }
}



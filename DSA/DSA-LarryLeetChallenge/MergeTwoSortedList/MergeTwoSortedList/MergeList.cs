namespace MergeTwoSortedList
{
    public class MergeList
    {
  

        public static List<int> Merge(SortedSet<int> setA, SortedSet<int> setB) { 
            var result = new List<int>();
            int counter = 0;
            (SortedSet<int> outerSet, SortedSet<int> innerSet) = setA.Count < setB.Count ? (setA,setB):(setB, setA);
            foreach (var outerItem in outerSet ) {
                for (int inner = counter; inner < innerSet.Count; inner++)
                {
                    if (outerItem >= innerSet.ToList()[inner])
                    {
                        result.Add(innerSet.ToList()[inner]);
                        counter++;
                    }
                    
                }
                result.Add(outerItem);
            }
            return result;
            
        }
    }
}
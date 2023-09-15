using MergeTwoSortedList;

namespace MergeListTest
{
    [TestClass]
    public class MergeListTest
    {
        [TestMethod]
        public void MergeListWith2DistinctSetAndNoOverLapping()
        {
            SortedSet<int> setA = new() { 10, 12, 14, 16 };
            SortedSet<int> setB = new() { 1, 7, 15, 13 ,9,11};

            SortedSet<int> setC = new (setA.Union(setB));
            List<int> result = MergeList.Merge(setA, setB);

            CollectionAssert.AreEqual(setC, result);
        }
        [TestMethod]
        public void MergeListWith2()
        {
            SortedSet<int> setA = new() { 10};
            SortedSet<int> setB = new() { 1};

            SortedSet<int> setC = new(setA.Union(setB));
            List<int> result = MergeList.Merge(setA, setB);

            CollectionAssert.AreEqual(setC, result);
        }

        [TestMethod]
        public void MergeListWith2OverLapping()
        {
            SortedSet<int> setA = new() { 10, 12, 14, 16 };
            SortedSet<int> setB = new() { 1, 7, 15, 13, 9, 11,12 };
            var expected = setA.ToList<int>().Concat(setB.ToList()).OrderBy(i=>i).ToList();
            
            List<int> result = MergeList.Merge(setA, setB);

            CollectionAssert.AreEqual(expected, result);
        }


    }
}
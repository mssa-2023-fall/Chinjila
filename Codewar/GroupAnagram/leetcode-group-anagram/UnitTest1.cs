namespace leetcode_group_anagram
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] strs =new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            GroupAnagrams(strs);
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //var result = strs.GroupBy(s=>s.Length).ToList();
            var wordGroups = strs.GroupBy(s =>
            {
                var arr = s.ToCharArray();
                Array.Sort(arr);
                return new String(arr);
            }).Select(g =>new List<string>(g)).ToList();

            IList<IList<string>> result = new List<IList<string>>(wordGroups);
         
            return result;
            //.Select(g=> new {Key=g.Key,Values=g}).ToList();
        }
    }
}
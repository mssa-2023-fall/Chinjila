namespace leetcode_group_anagram
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            GroupAnagrams(strs);
        }
        [TestMethod]
        public void TestBase26()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(ConvertNumberTo26Base(i));
            }
        }
        [TestMethod]
        public void TestSuffixGen()
        {
            foreach (var i in GetSuffix())
            {
                Console.WriteLine(i);
                if (i == "aaa") break;
            }
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var wordGroups = strs.GroupBy(s =>
            {
                var arr = s.ToCharArray();
                Array.Sort(arr);
                return new String(arr);
            }).Select(g => new List<string>(g)).ToList();

            IList<IList<string>> result = new List<IList<string>>(wordGroups);

            return result;
        }

        public static string ConvertNumberTo26Base(int n)
        {
            string res = "";
            while (n != 0)
            {
                n--;
                int rem = n % 26;
                res = (char)(rem + 'a') + res;
                n /= 26;
            }
            return res;
        }
        public IEnumerable<string> GetSuffix()
        {
            foreach (var item1 in " abcdefghijklmnopqrstuvwxyz")
            {
                foreach (var item2 in " abcdefghijklmnopqrstuvwxyz")
                {
                    if (item2 == ' ' & item1 != ' ') continue;
                    foreach (var item3 in " abcdefghijklmnopqrstuvwxyz")
                    {
                        if (item3 == ' ' & item2 != ' ') continue;
                        foreach (var item4 in "abcdefghijklmnopqrstuvwxyz")
                        {
                            yield return (item1.ToString() + item2.ToString() + item3.ToString() + item4.ToString()).Trim();
                        }
                    }
                }
            }
        }
    }
}
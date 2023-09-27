using Tree;
using System.Linq;
namespace IsPerfectTree
{
    [TestClass]
    public class Kata
    {
        [TestMethod]
        public void MyTest()
        {
            CollectionAssert.AreEqual(new char[] { 'a' }, Kata.Loneliest("a"));
            CollectionAssert.AreEqual(new char[] { 'g' }, Kata.Loneliest("abc d   ef  g   h i j      "));
            CollectionAssert.AreEqual(new char[] { 'b' }, Kata.Loneliest("a   b   c"));
            CollectionAssert.AreEqual(new char[] { 'z' }, Kata.Loneliest("  abc  d  z    f gk s "));
            CollectionAssert.AreEqual(new char[] { 'b', 'c' }, Kata.Loneliest("a  b  c  de  ").OrderBy(x => x).ToArray());
            CollectionAssert.AreEqual(new char[] { 'a', 'b', 'c' }, Kata.Loneliest("abc").OrderBy(x => x).ToArray());
        }

        public static char[] Loneliest2(string result)
        {
            Dictionary<char, int> dictResult = new();
            string trimmed = result.Trim();
            foreach (char c in trimmed)
            {
                if (c == ' ') continue;
                int spacesAfter = trimmed[(trimmed.IndexOf(c)+1)..^0].TakeWhile(s => s == ' ').Count();
                string reversedTrimmed = new string(trimmed.Reverse().ToArray());
                int spacesBefore = reversedTrimmed[(reversedTrimmed.IndexOf(c)+1)..^0].TakeWhile(s => s == ' ').Count();
                dictResult.Add(c, spacesAfter + spacesBefore);
            }
            int maxCount = dictResult.Values.Max();
            return dictResult.Where(pair => pair.Value == maxCount).Select((item) => item.Key).ToArray();
            //your array of lonely chars

        }
        public static char[] Loneliest(string result)
        {
            string trimmed = result.Trim();
            LinkedList<char> list = new LinkedList<char>(trimmed);
            Dictionary<char, int> dictResult = new();
            var node = list.First;
            while (node!= null)
            {
                if (node.Value == ' ') { node = node.Next; continue; }
                int spaceAfter = 0;
                int spaceBefore = 0;
                var _temp = node;
                while (_temp.Next?.Value == ' ') { spaceAfter++; _temp = _temp.Next; }
                _temp = node;
                while (_temp.Previous?.Value == ' ') { spaceBefore++; _temp = _temp.Previous; }
                
                dictResult.Add(node.Value, spaceAfter + spaceBefore);
                node = node.Next;
            }
            int maxCount = dictResult.Values.Max();
            return dictResult.Where(pair => pair.Value == maxCount).Select((item) => item.Key).ToArray();
        }
    }
}

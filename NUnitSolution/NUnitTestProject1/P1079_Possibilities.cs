
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Text;

namespace NUnitProject1
{
    class P1079_Possibilities
    {
        [Test]
        public void test01()
        {
            Assert.AreEqual(1, findPos("A"));
            Assert.AreEqual(4, findPos("AB"));
            Assert.AreEqual(15, findPos("ABC"));
            Assert.AreEqual(64, findPos("ABCD"));
            Assert.AreEqual(8, findPos("AAB"));
            Assert.AreEqual(188, findPos("AAABBC"));
        }

        public int findPos(string letters)
        {
            ISet<string> strSet = new HashSet<string>();
            fillStrSet_backtracking(letters, strSet, "",letters.Length);
            foreach (var s in strSet) Console.WriteLine(s);
            return strSet.Count - 1;
        }

        public void fillStrSet_backtracking(string remainingLetters, ISet<string> strSet, string path, int len)
        {
            if (!strSet.Contains(path)) {
                strSet.Add(path);
                if(path.Length == len) return; // base case
                for (int i = 0; i < remainingLetters.Length; i++)
                    fillStrSet_backtracking(remainingLetters.Remove(i, 1), strSet, path + remainingLetters[i], len);
            }
        }


        //dynamic programming
        public int findPos_DP(string letters)
        {
            ISet<string> strSet = new HashSet<string>();
            strSet.Add("");
            for(int i = 0; i < letters.Length; i++)
            {
                var letter = letters[i];
                ISet<string> addtionSet = new HashSet<string>();
                foreach (var str in strSet)
                {
                    for(int j = 0; j <= str.Length; j++) // include str.Lenght to append to the end
                    {
                        StringBuilder sb = new StringBuilder(str.ToString());
                        sb.Insert(j,letter);
                        addtionSet.Add(sb.ToString());
                    }
                }
                strSet.UnionWith(addtionSet);
            }
            return strSet.Count - 1; // -1 to exclude the empty string
        }

        public int findPosibilities(string letters)
        {
            ISet<string> strSet = new HashSet<string>();
            findPosibilities_BackTracking(letters, strSet, "", 0);
            foreach (var s in strSet) Console.WriteLine(s);
            return strSet.Count - 1;
        }

        public void findPosibilities_BackTracking(string letters, ISet<string> strSet, string path, int index)
        {
            if (letters.Length == 0)
            {
                strSet.Add(path);
                return;
            }
            for (int i = 0; i < letters.Length; i++)
            {
                string newletters = letters.Remove(i, 1);
                strSet.Add(path);

                // not use letters[i]
                findPosibilities_BackTracking(newletters, strSet, path, index + 1);

                // use the letters[i]
                findPosibilities_BackTracking(newletters, strSet, path + letters[i], index + 1);
            }
        }
    }
}


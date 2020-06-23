using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System;
using NUnit.Framework.Internal;

namespace P1048
{
    class P1048_bfs
    {
        [Test]
        public void test1()
        {
            Assert.AreEqual(4, LongestStrChain(new string[] { "a", "b", "ba", "bca", "bda", "bdca" }));
            Assert.AreEqual(7, LongestStrChain(new string[] { "ksqvsyq", "ks", "kss", "czvh", "zczpzvdhx", "zczpzvh", "zczpzvhx", "zcpzvh", "zczvh", "gr", "grukmj", "ksqvsq", "gruj", "kssq", "ksqsq", "grukkmj", "grukj", "zczpzfvdhx", "gru" }));
            Assert.AreEqual(9, LongestStrChain(new string[]
            { "czgxmxrpx","lgh","bj","cheheex","jnzlxgh","nzlgh","ltxdoxc","bju","srxoatl","bbadhiju","cmpx","xi","ntxbzdr","cheheevx","bdju","sra","getqgxi","geqxi","hheex","ltxdc","nzlxgh","pjnzlxgh","e","bbadhju","cmxrpx","gh","pjnzlxghe","oqlt","x","sarxoatl","ee","bbadju","lxdc","geqgxi","oqltu","heex","oql","eex","bbdju","ntxubzdr","sroa","cxmxrpx","cmrpx","ltxdoc","g","cgxmxrpx","nlgh","sroat","sroatl","fcheheevx","gxi","gqxi","heheex"}
            ));
        }

        public static int LongestStrChain(string[] words)
        {
            if (words == null || words.Length == 0)
                return 0;
            var maxWordLen = 0;
            foreach (var w in words)
            {
                if (w.Length > maxWordLen)
                    maxWordLen = w.Length;
            }
            var lenWords = new Dictionary<int, List<string>>();
            int i;
            for (i = 1; i <= maxWordLen; i++)
            {
                lenWords[i] = new List<string>();
            }
            foreach (var w in words)
            {
                lenWords[w.Length].Add(w);
            }
            ///////////////////////////////////////
            //this is the key point of the solution.
            ///////////////////////////////////////
            var wSet = new Dictionary<string, int>();

            //bfs --------------------------------
            Queue<string> q = new Queue<string>();
            int longestChain = 0;

            for (int j = 1; j <= maxWordLen; j++)
            {
                foreach (var w in lenWords[j])
                {
                    wSet[w] = 1;
                    q.Enqueue(w);
                    longestChain = 1;
                }
            }

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current.Length + 1 <= maxWordLen)
                {
                    foreach (var child in lenWords[current.Length + 1])
                    {
                        if (IsPre(current, child))
                        {
                            wSet[child] = Math.Max(wSet[child], wSet[current] + 1);
                        }
                        else
                        {
                            wSet[child] = Math.Max(wSet[child], 1);
                        }
                        longestChain = Math.Max(longestChain, wSet[child]);
                    }
                }
            }
            return longestChain;

        }

        public static bool IsPre(string a, string b)
        {
            if (a.Length == 0) return true;
            if ((b.Length - a.Length) != 1) return false;

            int i = 0;
            int j = 0;
            bool oneDiff = false;
            while (true)
            {
                if (i == a.Length)
                {
                    break;
                }
                else if (a[i] == b[j])
                {
                    i++;
                    j++;
                    continue;
                }
                else
                {
                    if (oneDiff)
                    {
                        return false;
                    }
                    oneDiff = true;
                    j++;
                }
            }
            if (oneDiff || j == i)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


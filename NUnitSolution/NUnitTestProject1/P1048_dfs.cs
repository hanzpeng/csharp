using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System;

namespace P1048
{
    class P1048_dfs
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
            for (int i = 1; i <= maxWordLen; i++)
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
            //int longestChain = 0;
            var dp = new Dictionary<string, int>();
            int[] maxChainLen = new int[] { 0 };
            for (int i = 1; i <= maxWordLen; i++)
            {
                Dfs("", 1, lenWords, dp, maxWordLen, 0, maxChainLen);
            }
            return maxChainLen[0];

            //// calculate dp1 based on dp for each i
            //for (int i = 1; i <= maxWordLen; i++){
            //    var dp1 = new Dictionary<string, int>();
            //    if (lenWords[i].Count == 0){
            //        // no-op
            //    }else if (dp.Count == 0){
            //        foreach (var w in lenWords[i]){
            //            dp1[w] = 1;
            //        }
            //        longestChain = Math.Max(longestChain, 1);
            //    }else{
            //        foreach (var w in lenWords[i]){
            //            foreach (var k in dp.Keys){
            //                if (IsPre(k, w)){
            //                    var oldVal = 0;
            //                    if (dp1.ContainsKey(w)){
            //                        oldVal = dp1[w];
            //                    }
            //                    dp1[w] = Math.Max(oldVal, dp[k] + 1);
            //                }
            //            }
            //            if (!dp1.ContainsKey(w)){
            //                dp1[w] = 1;
            //            }
            //        }
            //        longestChain = Math.Max(longestChain, dp1.Values.Max());
            //    }
            //    dp = dp1;
            //}
            //return longestChain;
        }

        public static void Dfs(string parent, int index, Dictionary<int, List<string>> lenWords, Dictionary<string, int> wSet, int maxWordLen, int depth, int[] maxChainLen)
        {
            if (index > maxWordLen)
            {
                return;
            }

            if (lenWords[index] == null || lenWords[index].Count == 0)
            {
                Dfs("", index + 1, lenWords, wSet, maxWordLen, 0, maxChainLen);
            }

            foreach (var w in lenWords[index])
            {
                if (wSet.Keys.Contains(w) && wSet[w] >= depth + 1)
                {
                    return;
                }

                if (IsPre(parent, w))
                {
                    maxChainLen[0] = Math.Max(maxChainLen[0], depth + 1);
                    wSet[w] = depth + 1;
                    Dfs(w, index + 1, lenWords, wSet, maxWordLen, depth + 1, maxChainLen);
                }
                else
                {
                    maxChainLen[0] = Math.Max(maxChainLen[0], 1);
                    wSet[w] = 1;
                    Dfs(w, index + 1, lenWords, wSet, maxWordLen, 1, maxChainLen);
                }
            }
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


using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System;

namespace P1048
{
    class P1048_dfs
    {
        [Test]
        public void test1()
        {
            Assert.AreEqual(4,LongestStrChain(new string[]
                    {"a","b","ba","bca","bda","bdca" }
                ));
            Assert.AreEqual(7,LongestStrChain(new string[]
                    { "ksqvsyq", "ks", "kss", "czvh", "zczpzvdhx","zczpzvh", "zczpzvhx", "zcpzvh", "zczvh","gr", "grukmj", "ksqvsq", "gruj", "kssq","ksqsq", "grukkmj", "grukj", "zczpzfvdhx", "gru" }
                ));
        }
        public static int LongestStrChain(string[] words){
            if (words == null || words.Length == 0)
                return 0;
            var maxWordLen = 0;
            foreach (var w in words){
                if (w.Length > maxWordLen)
                    maxWordLen = w.Length;
            }
            var lenWords = new Dictionary<int, List<string>>();
            for (int i = 1; i <= maxWordLen; i++){
                lenWords[i] = new List<string>();
            }
            foreach (var w in words){
                lenWords[w.Length].Add(w);
            }
            ///////////////////////////////////////
            //this is the key point of the solution.
            ///////////////////////////////////////
            var dp = new Dictionary<string,int>();
            int longestChain = 0;
            // calculate dp1 based on dp for each i
            for (int i = 1; i <= maxWordLen; i++){
                var dp1 = new Dictionary<string, int>();
                if (lenWords[i].Count == 0){
                    // no-op
                }else if (dp.Count == 0){
                    foreach (var w in lenWords[i]){
                        dp1[w] = 1;
                    }
                    longestChain = Math.Max(longestChain, 1);
                }else{
                    foreach (var w in lenWords[i]){
                        foreach (var k in dp.Keys){
                            if (isPre(k, w)){
                                var oldVal = 0;
                                if (dp1.ContainsKey(w)){
                                    oldVal = dp1[w];
                                }
                                dp1[w] = Math.Max(oldVal, dp[k] + 1);
                            }
                        }
                        if (!dp1.ContainsKey(w)){
                            dp1[w] = 1;
                        }
                    }
                    longestChain = Math.Max(longestChain, dp1.Values.Max());
                }
                dp = dp1;
            }
            return longestChain;
        }

        public static bool isPre(string a, string b)
        {
            if ((b.Length - a.Length) != 1) return false;
            int i = 0;
            int j = 0;
            bool oneDiff = false;
            while (true){
                if (i == a.Length){
                    break;
                }else if (a[i] == b[j]){
                    i++;
                    j++;
                    continue;
                }else{
                    if (oneDiff){
                        return false;
                    }
                    oneDiff = true;
                    j++;
                }
            }
            if (oneDiff && j == i + 1 || (!oneDiff && j == i)){
                return true;
            }else{
                return false;
            }

            /*
             * this is very slow
            for(int i=0;i<b.Length;i++){
                if(b.Substring(0,i)+b.Substring(i+1,b.Length-i-1) == a){
                    return true;
                }
            }
            return false;
            */
        }
    }
}

